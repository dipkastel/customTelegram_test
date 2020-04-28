using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using alphadinCore.Common.Controllers;
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
using Microsoft.VisualBasic;
using Services.Common;
using Services.Common.Cryptography;
using Services.Operator.Interfaces;

namespace alphadinCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : BaseController
    {
        private readonly IConfiguration _config;
        private readonly AuthHelper _authHelper;
        private readonly SmsHelper _smsHelper;
        private readonly DbContextModel _db;
        private readonly OnlineUsers _onlineUsers;
        private readonly IUserService _userService;
        
        public AccountController(IConfiguration config, AuthHelper authHelper, DbContextModel db, SmsHelper smsHelper, IUserService userService)
        {
            _config = config;
            _authHelper = authHelper;
            _smsHelper = smsHelper;
            _userService = userService;
            _onlineUsers = OnlineUsers.GetInstance();
            _db = db;
        }

        [HttpPost]
        public JsonResult GetSms(AccountSendSmsRequst smsRequst)
        {
            var smsResult = _smsHelper.SendAuthSms(smsRequst.PhoneNumber, _db);
            return new JsonResult(smsResult);
        }

        [HttpPost]
        public JsonResult Login(AccountLoginRequst loginInfo)
        {
            if (loginInfo.MobileNumber == null || loginInfo.SmsKey == null)
                throw new CustomException("اطلاعات وارد شده معتبر نیست",
                    ErrorsPreFix.CONTROLLER_ACOUNT + ERROR_LOGIN + "01");

            var user = new User();

            var deviceAgent = _userService.GetDeviceAgentCode(loginInfo.MobileNumber, HttpContext.Request);
                
            switch (_onlineUsers.GetUserStatus(deviceAgent))
            {
                case UserActivityStatus.Online:
                {
                    user = _onlineUsers.GetUserByUserAgent(deviceAgent).User;
                    break;
                }
                case UserActivityStatus.Expired:
                {
                    user = _onlineUsers.GetUserByUserAgent(deviceAgent).User;

                    //return RedirectToAction(nameof(RefreshToken), new {new RefreshTokenRequst()
                    //{
                    //    RefreshKey = _onlineUsers.GetUserByUserAgent(t).User.RefreshToken,
                    //    Token = _onlineUsers.GetUserByUserAgent(t).Token
                    //}});

                    break;
                }
                case UserActivityStatus.NotFound:
                {
                    //Login User
                    var tempUser = new User
                    {
                        MobileNumber = loginInfo.MobileNumber
                    };
                    user = _authHelper.AuthenticateUser(tempUser, _db);

                    //TODO: Add user to online users

                    break;
                }
            }
            
            if (!CheckUserAcess(user, out var userCustomException))
            {
                throw userCustomException; 
            }

            var sms = _db.Sms.Where(o => o.Reciver == user.MobileNumber)
                .OrderByDescending(p => p.SendDate)
                .FirstOrDefault();

            if (!CheckSms(loginInfo, sms, out var smsCustomException))
            {
                throw smsCustomException;
            }

            sms.Status = (int)SmsStatus.Used;
            _db.Sms.Update(sms);
            _db.SaveChanges();

            
            _authHelper.GenerateJsonWebToken(user, _config, _db, UserTokenStatus.Created);

            var token = _db.UserTokens.Where(u => u.User.MobileNumber == user.MobileNumber)
                .OrderByDescending(i => i.Id)
                .FirstOrDefault();

            return new JsonResult(token);

        }

        [HttpPost]
        public JsonResult RefreshToken(RefreshTokenRequst refreshInfo)
        {
            var user = _db.Users.Include(o => o.Role)
                .FirstOrDefault(o => o.RefreshToken == refreshInfo.RefreshKey);

            if (user == null)
                throw new CustomException("کاربری با این مشخصات یافت نشد",
                    ErrorsPreFix.CONTROLLER_ACOUNT + ERROR_REFRESH_TOKEN + "01");

            _authHelper.GenerateJsonWebToken(user, _config, _db, UserTokenStatus.Refresh);

            user.RefreshToken = Guid.NewGuid().ToString();

            _db.Users.Update(user);
            _db.SaveChanges();

            var token = _db.UserTokens.Where(u => u.User.MobileNumber == user.MobileNumber)
                .OrderByDescending(i => i.Id)
                .FirstOrDefault();

            return new JsonResult(token);
        }



        private bool CheckSms(AccountLoginRequst input, Sms sms, out CustomException customException)
        {
            customException = new CustomException(string.Empty, string.Empty);

            if (sms == null)
            {
                customException = new CustomException("کدی برای این کاربر ارسال نشده",
                    ErrorsPreFix.CONTROLLER_ACOUNT + ERROR_LOGIN + "03");

                return false;
            }

            if (sms.Status != (int)SmsStatus.Success)
            {
                customException = new CustomException("کد قبلا استفاده شده", ErrorsPreFix.CONTROLLER_ACOUNT + ERROR_LOGIN + "04");

                return false;
            }

            if (input.SmsKey != sms.Key)
            {
                customException = new CustomException("کد دریافت شده معتبر نمی باشد",
                    ErrorsPreFix.CONTROLLER_ACOUNT + ERROR_LOGIN + "05");

                return false;
            }

            return true;
        }

        private bool CheckUserAcess(User user, out CustomException customException)
        {
            customException = new CustomException(string.Empty, string.Empty);

            if (user == null)
            {
                customException = new CustomException("کاربر پیدا نشد", ErrorsPreFix.CONTROLLER_ACOUNT + ERROR_LOGIN + "02");
                return false;
            }

            return true;
        }

        public string ERROR_GET_SMS = "01";
        public string ERROR_LOGIN = "02";
        public string ERROR_REFRESH_TOKEN = "03";
    }
}