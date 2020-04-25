using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading.Tasks;

namespace alphadinCore.Model
{
    public class UserModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int Status{ get; set; }
        public string MobileNumber { get; set; }
        public string RefreshToken { get; set; }
        public RoleModel Role{ get; set; }
    }
    enum UserStatus { Active = 0, Suspend = 1 }
}
