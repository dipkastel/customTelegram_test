using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Database.Common;
using Database.Common.Interfaces;

namespace Database.Models
{
    public class UserToken : Auditable
    {
        

        public int Status { get; set; }
        public User User { get; set; }
        public string Token { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ExpiteDate { get; set; }

    }
}
