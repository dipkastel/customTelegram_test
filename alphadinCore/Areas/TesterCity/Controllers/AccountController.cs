using System;
using System.Linq;
using alphadinCore.Areas.TesterCity.Common;
using alphadinCore.Common.Helper;
using alphadinCore.Model;
using alphadinCore.Model.controllerModels;
using alphadinCore.Model.NetworkModels;
using alphadinCore.Services.Helper;
using Authentication.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Services.Operator.Interfaces;

namespace alphadinCore.Areas.TesterCity.Controllers
{
    [AllowAnonymous]
    public class AccountController : TesterCityController
    {
        private readonly SmsHelper _smsHelper;
        private readonly AuthHelper _authHelper;
        private readonly IConfiguration _config;
        private readonly IUserService _userService;
        private readonly IUserTokenService _tokenService;
        private readonly IOnlineUserService _onlineUserService;

        public AccountController(IConfiguration config, SmsHelper smsHelper, AuthHelper authHelper, IOnlineUserService onlineUserService, IUserService userService, IUserTokenService tokenService) : base(onlineUserService)
        {
            _smsHelper = smsHelper;
            _authHelper = authHelper;
            _onlineUserService = onlineUserService;
            _userService = userService;
            _tokenService = tokenService;
            _config = config;
        }

        [HttpPost]
        public JsonResult GetSms(AccountSendSmsRequst smsRequst)
        {
            var smsResult = _smsHelper.SendAuthSms(smsRequst.PhoneNumber);
            return new JsonResult(smsResult);
        }


        [HttpPost]
        public JsonResult Login(AccountLoginRequst loginInfo)
        {
            var result = _authHelper.Login(loginInfo, HttpContext, _config);
            return new JsonResult(result);

        }

        [HttpPost]
        public JsonResult RefreshToken(RefreshTokenRequst refreshInfo)
        {
            var user = _userService.GetAllIncluding(o => o.Role)
                .FirstOrDefault(o => o.RefreshToken == refreshInfo.RefreshKey);

            if (user == null)
                throw new CustomException("کاربری با این مشخصات یافت نشد",
                    ErrorsPreFix.CONTROLLER_ACOUNT + ERROR_REFRESH_TOKEN + "01");

            //_authHelper.GenerateJsonWebToken(user, _config, _db, UserTokenStatus.Refresh);

            user.RefreshToken = Guid.NewGuid().ToString();

            _userService.Update(user, user.Id);

            var token = _tokenService.FindAll(u => u.User.Id == user.Id).Data
                .OrderByDescending(i => i.CreateDate)
                .FirstOrDefault();

            return new JsonResult(token);
        }

        [HttpPost]
        public RedirectToActionResult Logout()
        {
            //var user = GetUser(HttpContext);
            //var uniqueKey = _userService.GetUserUniqueKey(user.MobileNumber, UserAgent);
            //_onlineUserService.Logout(uniqueKey);
            return RedirectToAction("Login");
        }

        public string ERROR_GET_SMS = "01";
        public string ERROR_LOGIN = "02";
        public string ERROR_REFRESH_TOKEN = "03";
    }
}