using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Database.Common;
using Database.Common.Interfaces;

namespace Database.Models
{
    public class TesterProfile : Auditable
    {
        


        public User User { get; set; }
        public string UserName { get; set; }
        public string ProfileImageUrl { get; set; }
        public string UserBio { get; set; }
        public string NickName { get; set; }
        public DateTime BirthDay { get; set; }
        public int RelationType{ get; set; }
        public int GenderType { get; set; }
        public long NationalCode { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public bool EmailVerified { get; set; }
        public string PostalCode { get; set; }
        public int CityCode { get; set; }

    }
}
