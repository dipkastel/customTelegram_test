using System;
using System.Collections.Generic;
using System.Linq;
using Services.ViewModels.Authentication;

namespace Authentication.Holders
{
    
    public class UsersHolder
    {
        private Dictionary<string, UserInfo> UserInfos { get; set; }
        private static UsersHolder Instance { get; set; }
        private DateTime LastFlush { get; set; }

        private UsersHolder()
        {
            UserInfos = new Dictionary<string, UserInfo>();
            LastFlush = DateTime.Now;
        }

        public static UsersHolder GetInstance()
        {
            return Instance ?? (Instance = new UsersHolder());
        }

        public void Remove(string agent)
        {
            UserInfos.Remove(agent);
        }

        public void Add(string agent, UserInfo userInfo)
        {
            UserInfos.Add(agent, userInfo);

            if (LastFlush.AddHours(8) < DateTime.Now)
            {
                Flush();
            }
        }
        
        public UserInfo Get(string uniqueKey)
        {
            UserInfos.TryGetValue(uniqueKey, out var userInfo);

            return IsActive(userInfo) ? userInfo : null;
        }

        public int Count()
        {
            return UserInfos.Count;
        }

        public List<UserInfo> GetAll()
        {
            return UserInfos.Values.ToList();
        }

        public int GetOnlineUserServiceCount()
        {
            return GetAll().Count(userInfo => IsActive(userInfo));
        }




        private bool IsActive(UserInfo userInfo)
        {
            return userInfo?.ExpireDate > DateTime.Now;
        }

        private void Flush()
        {
            foreach (var userInfo in UserInfos.Where(userInfo => !IsActive(userInfo.Value)))
            {
                Remove(userInfo.Key);
            }
            LastFlush = DateTime.Now;
        }

    }
}
