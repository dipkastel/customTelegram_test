using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Database.Common;
using Database.Common.Interfaces;

namespace Database.Models
{
    public class UserEducation : Auditable
    {
        

        public int Status { get; set; }
        public User User { get; set; }
        public int Grade { get; set; }
        public string Major { get; set; }
        public string Place { get; set; }
        public bool InProgress { get; set; }
    }
}
