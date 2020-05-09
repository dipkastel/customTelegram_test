using System;
using System.Collections.Generic;
using System.Linq;
using Authentication.Services.Interface;
using Database.Models.Authentication;
using Services.Operator.Interfaces;
using Services.ViewModels.Authentication;

namespace Authentication.Services
{
    public class OnlineUserService : IOnlineUserService
    {
        /* Declaration */

        private readonly IUserTokenService _tokenService;
        private readonly IUserService _userService;
        private readonly UsersHolder _onlineUsers;

        public OnlineUserService(IUserTokenService tokenService, IUserService userService)
        {
            _userService = userService;
            _tokenService = tokenService;
            _onlineUsers = UsersHolder.GetInstance();
        }


        /* Methods */

        public UserInfo GetUserInfo(string uniqueKey, int userId, string userAgent)
        {
            var userInfo = _onlineUsers.Get(uniqueKey);

            return userInfo ?? Login(uniqueKey, userId, userAgent);
        }

        public UserInfo Login(string uniqueKey, int userId, string userAgent)
        {
            var userToken = _tokenService.GetAllIncluding(ut => ut.User).FirstOrDefault(ut => ut.User.Id == userId);

            if (userToken == null)
            {
                return null;
            }

            var newUniqueKey = _userService.GetUserUniqueKey(userToken.User.MobileNumber, userAgent);

            if (uniqueKey != newUniqueKey) //Forbidden access 
            {
                Logout(uniqueKey);

                return null;
            }

            var userInfo = new UserInfo()
            {
                User = userToken.User,
                UserToken = userToken,
                ExpireDate = DateTime.Now.AddHours(8),
                UserActions = new List<UserAction>()
            };

            //TODO: Get ExpireTime from JWT

            _onlineUsers.Add(newUniqueKey, userInfo);
            return userInfo;
        }

        public void Logout(string agent)
        {
            _onlineUsers.Remove(agent);
        }
    }
}
