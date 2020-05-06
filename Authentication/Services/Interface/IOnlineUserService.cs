using System.Collections.Generic;
using Services.ViewModels.Authentication;

namespace Authentication.Services.Interface
{
    public interface IOnlineUserService
    {
        UserInfo GetUserInfo(string uniqueKey, int userId, string userAgent);
        void RemoveUserInfo(string agent);
        int GetOnlineUserServiceCount();
        List<UserInfo> GetOnlineUserService();
    }
}