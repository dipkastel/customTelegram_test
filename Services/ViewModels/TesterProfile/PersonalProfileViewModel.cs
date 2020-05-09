using System;

namespace Services.ViewModels.TesterProfile
{
    public class PersonalProfileViewModel
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public bool EmailVerified { get; set; }
        public DateTime BirthDay { get; set; }
    }
}