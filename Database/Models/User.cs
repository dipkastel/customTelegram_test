using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Database.Common;
using Database.Common.Interfaces;
using Database.Models.Authentication;

namespace Database.Models
{
    public class User : Auditable
    {
        public override int Id { get; set; }

        public string MobileNumber { get; set; }
        public string RefreshToken { get; set; }

        public Role Role{ get; set; }
        public ICollection<UserAction> UserActions { get; set; }

    }
}