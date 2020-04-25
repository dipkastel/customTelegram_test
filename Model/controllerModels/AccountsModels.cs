using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace alphadinCore.Model.controllerModels
{
    public class AccountsModels
    {

    }

    public class accountSendSmsRequst {
        public string phoneNumber { get; set; }
    }
    public class accountLoginRequst {
        public string MobileNumber { get; set; }
        public string smsKey { get; set; }
    }
    public class RefreshTokenRequst
    {
        public string Token { get; set; }
        public string RefreshKey { get; set; }
    }
}
