using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading.Tasks;
using alphadinCore.Model.dbModels;

namespace alphadinCore.Model
{
    public class UserFavoriteModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int Status { get; set; }
        public UserModel user { get; set; }
        public FavoriteTagModel Tag { get; set; }
    }
}
