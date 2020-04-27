namespace alphadinCore.Model.controllerModels
{
    public class AccountsModels
    {

    }

    public class AccountSendSmsRequst {
        public string PhoneNumber { get; set; }
    }

    public class AccountLoginRequst {
        public string MobileNumber { get; set; }
        public string SmsKey { get; set; }
    }

    public class RefreshTokenRequst
    {
        public string Token { get; set; }
        public string RefreshKey { get; set; }
    }
}
