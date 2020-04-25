using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace alphadinCore.Model.dbModels
{
    public class TesterProfileModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public UserModel user { get; set; }
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
        public int cityCode { get; set; }

    }
}
