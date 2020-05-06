using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Database.Common.Enums;
using Database.Config;
using Database.Models;
using Services.Operator.Interfaces;
using alphadinCore.Common.Helper;
using Microsoft.AspNetCore.Http;
using alphadinCore.Model;
using alphadinCore.Model.NetworkModels;
using System.Text.Json;
using alphadinCore.Model.controllerModels;
using Authentication.Services;
using Authentication.Services.Interface;
using Services.Operator.Authentication.Interfaces;

namespace alphadinCore.Services.Helper
{
   

    public class AuthHelper
    {
        private const int TOKEN_LIFE_TIME = 8; //TOKEN LIFE TIME In hour

        private readonly IOnlineUserService _onlineUserService;
        private readonly IUserService _userService;
        private readonly ISmsService _smsService;
        private readonly IRoleService _roleService;
        private readonly IUserTokenService _userTokenService;

        public AuthHelper(IUserService userService, ISmsService smsService, IUserTokenService userTokenService,IRoleService roleService, IOnlineUserService onlineUserService) {
            this._userService = userService;
            this._smsService = smsService;
            this._userTokenService = userTokenService;
            this._roleService = roleService;
            _onlineUserService = onlineUserService;
        }

        public UserToken Login(AccountLoginRequst loginInfo, HttpContext httpContext, IConfiguration config)
        {
            if (loginInfo.MobileNumber == null || loginInfo.SmsKey == null)
                throw new CustomException("اطلاعات وارد شده معتبر نیست", ErrorsPreFix.AUTH_HELPER + ERROR_LOGIN + "00");

            var uniqueKey = _userService.GetUserUniqueKey(loginInfo.MobileNumber, httpContext.Request.Headers["User-Agent"]);

            _onlineUserService.RemoveUserInfo(uniqueKey);

            var user = _userService.GetAllIncluding(u => u.Role).FirstOrDefault(u => u.MobileNumber == loginInfo.MobileNumber);

            if (user == null || user.Id == 0)
            {
                var newUser = new User()
                {
                    CreatedByUserId = 1,
                    MobileNumber = loginInfo.MobileNumber,
                    Status = (int)UserStatus.Active,
                    Role = _roleService.Find(r => r.Name.ToLower() == "tester").Data,
                    RefreshToken = new Guid().ToString()
                    
                };

                _userService.Add(newUser, 1);
                user = newUser;
            }

            var sms = _smsService.FindBy(s => s.Reciver == user.MobileNumber)
                .Data.OrderByDescending(s => s.SendDate)
                .FirstOrDefault();

            if (sms == null)
                throw new CustomException("کدی برای کاربر ارسال نشده", ErrorsPreFix.AUTH_HELPER + ERROR_LOGIN + "02");

            if (sms.Status != (int) SmsStatus.Success)
                throw new CustomException("کد قبلا استفاده شده", ErrorsPreFix.AUTH_HELPER + ERROR_LOGIN + "03");

            if (loginInfo.SmsKey != sms.Key)
                throw new CustomException("کد دریافت شده معتبر نمی باشد",
                    ErrorsPreFix.AUTH_HELPER + ERROR_LOGIN + "04");

            sms.Status = (int) SmsStatus.Used;
            _smsService.Update(sms, user.Id);

            var userToken = GenerateJsonWebToken(uniqueKey, config, user, loginInfo.RememberMe);

            userToken.Status = (int) UserTokenStatus.Created;
            userToken.User = user;
            _userTokenService.Add(userToken, user.Id);
            
//            _onlineUserService.AddUser(uniqueKey, userToken);

            return userToken;
        }

        public UserToken GenerateJsonWebToken(string deviceAgent, IConfiguration config, User user, bool rememberMe)
        {

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub,user.MobileNumber),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim("uniqueKey", deviceAgent),
                new Claim("rememberMe", rememberMe.ToString()),
                new Claim("userId", user.Id.ToString()),
            };

            var authToken = new JwtSecurityToken(
                issuer: config["Jwt:Issuer"],
                audience: config["Jwt:Issuer"],
                claims,
                expires: DateTime.Now.AddHours(TOKEN_LIFE_TIME),
                signingCredentials: credentials);

            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler
            {
                TokenLifetimeInMinutes = TOKEN_LIFE_TIME * 60
            };

            var encodeToken = jwtSecurityTokenHandler.WriteToken(authToken);

            return new UserToken
            {
                CreateDate = DateTime.Now,
                ExpiteDate = DateTime.Now.AddMinutes(jwtSecurityTokenHandler.TokenLifetimeInMinutes),
                Token = encodeToken
            };
        }

        private User InsertUser(string phoneNumber)
        {
            var user = _userService.Find(a => a.MobileNumber == phoneNumber).Data;
            if (user == null)
            {
                var role = _roleService.Find(t => t.Name == "tester").Data;
                _userService.Add(new User
                {
                    MobileNumber = phoneNumber,
                    Role = role,
                    Status = (int) UserStatus.Active,
                    RefreshToken = Guid.NewGuid().ToString()
                }, 0);
            }
            else
            {
                user.RefreshToken = Guid.NewGuid().ToString();
                _userService.Update(user, user.Id);
            }

            return user;
        }


        private const string ERROR_LOGIN = "00";
        private const string GENERATEJSONWEBTOKEN = "01"; //GENERATE JSON WEB TOKEN
    }
}
