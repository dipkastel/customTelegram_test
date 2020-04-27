using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using alphadinCore.Common.Filters;
using alphadinCore.Common.Helper;
using alphadinCore.Model;
using alphadinCore.Model.controllerModels;
using alphadinCore.Model.NetworkModels;
using alphadinCore.Model.smsModels;
using alphadinCore.Services.Helper;
using Database.Common.Enums;
using Database.Config;
using Database.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace alphadinCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [TrackMethodsFilter]
    [ResultFixer]
    public class AccountController : ControllerBase
    {
        private IConfiguration config;
        private AuthHelper authHelper;
        private SmsHelper smsHelper;
        private DbContextModel db;
        public AccountController(IConfiguration _config, AuthHelper _authHelper, DbContextModel _db,SmsHelper _smsHelper)
        {
            config = _config;
            authHelper = _authHelper;
            db = _db;
            smsHelper = _smsHelper;
        }

        [Route("getSms")]
        [HttpPost]
        public JsonResult getSms(accountSendSmsRequst input) {
            SendSmsResultModel smsResult =  smsHelper.sendAuthSms(input.phoneNumber,db);
            return new JsonResult(smsResult);
        }

        [Route("Login")]
        [HttpPost]
        public JsonResult Login(accountLoginRequst input)
        {
            if (input.MobileNumber == null || input.smsKey == null)
                throw new CustomException("اطلاعات وارد شده معتبر نیست", ErrorsPreFix.CONTROLLER_ACOUNT+ERROR_LOGIN+"01");
            User login = new User();
            login.MobileNumber = input.MobileNumber;
            var user = authHelper.AuthenticateUser(login, db);
            if (user == null)
                throw new CustomException("کاربر پیدا نشد", ErrorsPreFix.CONTROLLER_ACOUNT + ERROR_LOGIN + "02");
            var sms = db.Sms.Where(o => o.Reciver == user.MobileNumber).OrderByDescending(p => p.SendDate).FirstOrDefault();
            if (sms == null) 
                throw new CustomException("کدی برای این کاربر ارسال نشده", ErrorsPreFix.CONTROLLER_ACOUNT + ERROR_LOGIN + "03");
            if (sms.Status != 0)
                throw new CustomException("کد قبلا استفاده شده", ErrorsPreFix.CONTROLLER_ACOUNT + ERROR_LOGIN + "04");
            if (input.smsKey != sms.Key) 
                throw new CustomException("کد دریافت شده معتبر نمی باشد", ErrorsPreFix.CONTROLLER_ACOUNT + ERROR_LOGIN + "05");

           authHelper.GenerateJSONWebToken(user, config,db,(int)UserTokenStatus.Created);

            sms.Status = 1;
            db.Sms.Update(sms);
            db.SaveChanges();

            var Token = db.UserTokens.Where(u => u.User.MobileNumber == user.MobileNumber).OrderByDescending(i=>i.Id).FirstOrDefault();
            return new JsonResult(Token);
        }

        [Route("RefreshToken")]
        [HttpPost]
        public JsonResult RefreshToken(RefreshTokenRequst input)
        {
            User user = db.Users.Include(o=>o.Role).Where(o => o.RefreshToken == input.RefreshKey).FirstOrDefault();
            if (user == null)
                throw new CustomException("کاربری با این مشخصات یافت نشد", ErrorsPreFix.CONTROLLER_ACOUNT + ERROR_REFRESH_TOKEN + "01");
            authHelper.GenerateJSONWebToken(user, config,db,(int)UserTokenStatus.Refresh);
            user.RefreshToken = Guid.NewGuid().ToString();
            db.Users.Update(user);
            db.SaveChanges();
            var Token = db.UserTokens.Where(u => u.User.MobileNumber == user.MobileNumber).OrderByDescending(i => i.Id).FirstOrDefault();
            return new JsonResult(Token);
        }


        [Authorize(Roles = "tester")]
        [Route("tester")]
        [HttpPost]
        public JsonResult Post()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            IList<Claim> claim = identity.Claims.ToList();
            var userName = claim[0].Value;
            return new JsonResult("Welcome " + userName);
        }

        [Authorize(Roles ="Admin")]
        [Route("Admin")]
        public JsonResult getHasan()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            IList<Claim> claim = identity.Claims.ToList();
            return new JsonResult("hasan ina");
        }



        public string ERROR_GET_SMS = "01";
        public string ERROR_LOGIN = "02";
        public string ERROR_REFRESH_TOKEN = "03";
    }
}