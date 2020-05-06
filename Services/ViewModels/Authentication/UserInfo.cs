using System;
using System.Collections;
using System.Collections.Generic;
using Database.Models;
using Database.Models.Authentication;

namespace Services.ViewModels.Authentication
{
    public class UserInfo
    {
        public User User { get; set; }
        public UserToken UserToken { get; set; }
        public DateTime ExpireDate { get; set; }
        public IEnumerable<UserAction> UserActions { get; set; }
    }
}