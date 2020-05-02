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

namespace alphadinCore.Services.Helper
{
    public class AuthHelper
    {
        private const int TOKEN_LIFE_TIME = 8; //In hour

        private readonly OnlineUsers _onlineUsers;
        private readonly IUserService _userService;
        private readonly ISmsService _smsService;
        private readonly IRoleService _roleService;
        private readonly IUserTokenService _userTokenService;
        public AuthHelper(IUserService userService, ISmsService smsService, IUserTokenService userTokenService,IRoleService roleService) {
            this._userService = userService;
            this._smsService = smsService;
            this._userTokenService = userTokenService;
            this._roleService = roleService;
            _onlineUsers = OnlineUsers.GetInstance();
        }


        public UserToken Login(string mobileNumber, string smsKey, HttpContext httpContext,IConfiguration _config, bool rememberMe = false ) {

            if (mobileNumber == null || smsKey == null)
                throw new CustomException("اطلاعات وارد شده معتبر نیست",ErrorsPreFix.AUTH_HELPER + ERROR_LOGIN + "00");

            var uniqKey = _userService.GetUserUniqKey(mobileNumber, httpContext.Request);
            
            _onlineUsers.LogOutUser(uniqKey);

            User user = _userService
               .GetAllIncluding()
               .Include(i => i.Role)
               .First(p => p.MobileNumber == mobileNumber);

            Sms sms = _smsService
                .FindBy(o => o.Reciver == user.MobileNumber).Data
                .OrderByDescending(p => p.SendDate)
                .FirstOrDefault();

            if(user==null)
            throw new CustomException("کاربر پیدا نشد", ErrorsPreFix.AUTH_HELPER + ERROR_LOGIN + "01");

            
            if(sms ==null)
                throw new CustomException("کدی برای کاربر ارسال نشده", ErrorsPreFix.AUTH_HELPER + ERROR_LOGIN + "02");

            if (sms.Status != (int)SmsStatus.Success)
                throw new CustomException("کد قبلا استفاده شده", ErrorsPreFix.AUTH_HELPER + ERROR_LOGIN + "03");

            if (smsKey != sms.Key)
                throw new CustomException("کد دریافت شده معتبر نمی باشد",ErrorsPreFix.AUTH_HELPER + ERROR_LOGIN + "04");

            sms.Status =(int) SmsStatus.Used;
            _smsService.Update(sms,user.Id);


            UserToken userToken = GenerateJsonWebToken(uniqKey, _config, user, rememberMe);

            userToken.Status = (int)UserTokenStatus.Created;
            userToken.User = user;
            _userTokenService.Add(userToken, user.Id);
            _onlineUsers.AddUser(userToken.Token, userToken);

            return userToken;
        }

        public UserToken GenerateJsonWebToken(String deviceAgent, IConfiguration config,User user, bool rememberMe)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, deviceAgent),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim("User",JsonSerializer.Serialize(user)),
                new Claim("RememberMe", rememberMe.ToString())
            };
            
            var authToken = new JwtSecurityToken(
                issuer: config["Jwt:Issuer"],
                audience: config["Jwt:Issuer"],
                claims,
                expires: DateTime.Now.AddHours(TOKEN_LIFE_TIME),
                signingCredentials: credentials);

            var encodeToken = new JwtSecurityTokenHandler().WriteToken(authToken);

            return new UserToken
            {
                CreateDate = DateTime.Now,
                ExpiteDate = DateTime.Now.AddMinutes(new JwtSecurityTokenHandler().TokenLifetimeInMinutes),
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
                    Status = (int)UserStatus.Active,
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


        private string ERROR_LOGIN = "00";
        private string GENERATEJSONWEBTOKEN = "01";


    }


}
