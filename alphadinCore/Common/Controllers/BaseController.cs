using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using alphadinCore.Common.Filters;
using Authentication.Services.Interface;
using Database.Models;
using Database.Models.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Operator.Interfaces;
using Services.ViewModels.Authentication;

namespace alphadinCore.Common.Controllers
{

    [TrackMethodsFilter]
    [ResultFixer]
    [ApiController]
    [Route("api/{area:exists}/[controller]/[action]/{id?}")]
    [Route("api/[controller]/[action]/{id?}")]
    public class BaseController : ControllerBase
    {
        private readonly IOnlineUserService _onlineUserService;

        public BaseController(IOnlineUserService onlineUserService)
        {
            _onlineUserService = onlineUserService;
        }

        public string UserAgent => HttpContext.Request.Headers["User-Agent"].ToString();

        public UserInfo GetCurrentUserInfo(HttpContext httpContext)
        {
            var identity = httpContext.User.Identity as ClaimsIdentity;
            var claim = identity.Claims.ToList();

            var userId = int.Parse(claim.First(c => c.Type == "userId").Value);
            var uniqueKey = claim.First(c => c.Type == "uniqueKey").Value;

            return _onlineUserService.GetUserInfo(uniqueKey, userId, UserAgent);
        }

        public User GetUser(HttpContext httpContext)
        {
            var user = GetCurrentUserInfo(httpContext).User;

            if (user == null)
            {
                Unauthorized();
                throw new UnauthorizedAccessException();
            }

            return user;
        }

        public IEnumerable<UserAction> GetUserAccess(HttpContext httpContext)
        {
            return GetCurrentUserInfo(httpContext).UserActions;
        }

        public UserToken GetUserToken(HttpContext httpContext)
        {
            return GetCurrentUserInfo(httpContext).UserToken;
        }

    }
}