using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace alphadinCore.Model.dbModels
{
    public class UserSocialsModel
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int Status { get; set; }
        public UserModel user { get; set; }
        public int SocialType { get; set; }
        public string Address { get; set; }
        public int ActivateTimeId { get; set; }

    }
}
