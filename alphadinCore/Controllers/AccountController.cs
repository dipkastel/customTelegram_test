using System;
using System.Linq;
using alphadinCore.Common.Controllers;
using alphadinCore.Common.Helper;
using alphadinCore.Model;
using alphadinCore.Model.controllerModels;
using alphadinCore.Model.NetworkModels;
using alphadinCore.Services.Helper;
using Authentication.Services.Interface;
using Database.Config;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace alphadinCore.Controllers
{
    public class AccountController : BaseController
    {
        private readonly SmsHelper _smsHelper;
        private readonly AuthHelper _authHelper;
        private readonly DbContextModel _db;
        private readonly IConfiguration _config;
        
        public AccountController(IConfiguration config, DbContextModel db, SmsHelper smsHelper, AuthHelper authHelper, IOnlineUserService onlineUserService) : base(onlineUserService)
        {
            _smsHelper = smsHelper;
            _authHelper = authHelper;
            _db = db;
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
            var user = _db.Users.Include(o => o.Role)
                .FirstOrDefault(o => o.RefreshToken == refreshInfo.RefreshKey);

            if (user == null)
                throw new CustomException("کاربری با این مشخصات یافت نشد",
                    ErrorsPreFix.CONTROLLER_ACOUNT + ERROR_REFRESH_TOKEN + "01");

            //_authHelper.GenerateJsonWebToken(user, _config, _db, UserTokenStatus.Refresh);

            user.RefreshToken = Guid.NewGuid().ToString();

            _db.Users.Update(user);
            _db.SaveChanges();

            var token = _db.UserTokens.Where(u => u.User.MobileNumber == user.MobileNumber)
                .OrderByDescending(i => i.CreateDate)
                .FirstOrDefault();

            return new JsonResult(token);
        }

        [HttpPost]
        public JsonResult Logout()
        {
            //TODO: Remove user from online users
            return null;
        }

        public string ERROR_GET_SMS = "01";
        public string ERROR_LOGIN = "02";
        public string ERROR_REFRESH_TOKEN = "03";
    }
}