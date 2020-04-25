using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace alphadinCore.Model
{
    public class UserTokenModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int Status { get; set; }
        public UserModel User { get; set; }
        public string Token { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ExpiteDate { get; set; }

    }

   enum TokenStatus {  created=0,Refresh=1  }
}
