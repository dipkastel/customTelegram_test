using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Database.Common;
using Database.Common.Interfaces;

namespace Database.Models
{
    public class UserJob : Auditable
    {
        

        public int Status { get; set; }
        public User User { get; set; }
        public string CompanyName { get; set; }
        public string JobTitle { get; set; }
        public int SalaryId { get; set; }
        public int CompanyScaleId { get; set; }
        public bool InProgress { get; set; }
    }
}
