using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Database.Common;
using Database.Common.Interfaces;

namespace Database.Models
{
    public class UserSocials : Auditable
    {

        

        public int Status { get; set; }
        public User User { get; set; }
        public int SocialType { get; set; }
        public string Address { get; set; }
        public int ActivateTimeId { get; set; }

    }
}
