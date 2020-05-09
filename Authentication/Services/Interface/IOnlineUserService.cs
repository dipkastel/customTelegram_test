using System.Collections.Generic;
using Services.Operator.Interfaces;
using Services.ViewModels.Authentication;

namespace Authentication.Services.Interface
{
    public interface IOnlineUserService
    {
        UserInfo GetUserInfo(string uniqueKey, int userId, string userAgent);
        void Logout(string agent);
    }
}