using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Database.Models;

namespace Services.Common
{
    public class OnlineUsers
    {

        private static OnlineUsers _onlineUsers;
        private OnlineUsers()
        {
            UserInfos = new Dictionary<string, UserToken>();
        }
        public static OnlineUsers GetInstance()
        {
            return _onlineUsers ?? (_onlineUsers = new OnlineUsers());
        }

        private Dictionary<string, UserToken> UserInfos { get; set; }

        public UserActivityStatus GetUserStatus(string agent)
        {
            var user = UserInfos[agent];

            if (user == null)
            {
                return UserActivityStatus.NotFound;
            }

            if (user.ExpiteDate > DateTime.Now)
            {
                return UserActivityStatus.Online;
            }

            if (user.ExpiteDate.AddDays(5) > DateTime.Now)
            {
                return UserActivityStatus.Expired;
            }

            LogOutUser(agent);
            return UserActivityStatus.NotFound;
        }















        public User GetActiveUserByUserAgent(string agent)
        {
            var userToken = UserInfos[agent];

            if (userToken?.ExpiteDate > DateTime.Now)
                return userToken.User;

            return null;
        }

        public UserToken GetUserByUserAgent(string agent)
        {
            return UserInfos[agent];
        }

        public void AddUser(string agent, UserToken token)
        {
            UserInfos.Add(agent, token);
        }

        public void LogOutUser(string agent)
        {
            UserInfos.Remove(agent);
        }

        public int GetOnlineUsersCount()
        {
            return UserInfos.Count(u => u.Value.ExpiteDate < DateTime.Now);
        }

        public List<User> GetOnlineUsers()
        {
            return UserInfos.Where(u => u.Value.ExpiteDate < DateTime.Now).Select(u => u.Value.User).ToList();
        }

        public bool UserCanRemember(string agent, bool loginInfoRememberMe)
        {
            if (!loginInfoRememberMe) return false;

            return UserInfos[agent].ExpiteDate.AddDays(5) > DateTime.Now;
        }

       
    }


    public enum UserActivityStatus
    {
        Online,
        Expired,
        NotFound
    }

}
