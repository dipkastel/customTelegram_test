using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Authentication.Services.Interface;
using Database.Models;
using Database.Models.Authentication;
using Services.Common.Cryptography;
using Services.Operator.Interfaces;
using Services.ViewModels.Authentication;

namespace Authentication.Services
{
    public class OnlineUserService : IOnlineUserService
    {
        private readonly IUserTokenService _tokenService;
        private readonly IUserService _userService;

        /* Declaration */

        public OnlineUserService(IUserTokenService tokenService, IUserService userService)
        {
            _tokenService = tokenService;
            _userService = userService;
            UserInfos = new Dictionary<string, UserInfo>();
            LastFlush = DateTime.Now;
        }

        private Dictionary<string, UserInfo> UserInfos { get; set; }

        private DateTime LastFlush { get; set; }

        /* Methods */

        public UserInfo GetUserInfo(string uniqueKey, int userId, string userAgent)
        {
            var userInfo = UserInfos[uniqueKey];

            if (IsActive(userInfo))
                return userInfo;
            else
            {
                var userToken = _tokenService.GetAllIncluding(ut => ut.User).FirstOrDefault(ut => ut.User.Id == userId);

                if (userToken == null)
                {
                    return null;
                }

                var newUniqueKey = _userService.GetUserUniqueKey(userToken.User.MobileNumber, userAgent);

                if (uniqueKey != newUniqueKey) //Forbidden access 
                {
                    //logout user 
                    RemoveUserInfo(uniqueKey);

                    return null;
                }

                userInfo = new UserInfo()
                {
                    User = userToken.User,
                    UserToken = userToken,
                    ExpireDate = DateTime.Now.AddHours(8),
                    UserActions = new List<UserAction>()
                };

                //TODO: Get ExpireTime from JWT

                AddUser(newUniqueKey, userInfo);
                return userInfo;

            }
        }

        public void RemoveUserInfo(string agent)
        {
            UserInfos.Remove(agent);
        }

        public int GetOnlineUserServiceCount()
        {
            return UserInfos.Count(u => IsActive(u.Value));
        }

        public List<UserInfo> GetOnlineUserService()
        {
            return UserInfos.Where(u => IsActive(u.Value)).Select(u => u.Value).ToList();
        }



        private void AddUser(string uniqueKey, UserInfo userInfo)
        {
            UserInfos.Add(uniqueKey, userInfo);

            if (LastFlush.AddHours(8) < DateTime.Now)
            {
                Flush();
            }
        }

        private bool IsActive(UserInfo userInfo)
        {
            return userInfo?.ExpireDate > DateTime.Now;
        }

        private void Flush()
        {
            foreach (var userInfo in UserInfos.Where(userInfo => !IsActive(userInfo.Value)))
            {
                RemoveUserInfo(userInfo.Key);
            }
        }
    }
}
