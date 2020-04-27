using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Database.Common;
using Database.Common.Interfaces;

namespace Database.Models
{
    public class UserFavorite : Auditable
    {
        

        public int Status { get; set; }
        public User User { get; set; }
        public FavoriteTag Tag { get; set; }
    }
}
