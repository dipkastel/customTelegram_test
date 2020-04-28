using Database.Config;
using Database.Models;
using DatabaseValidation.Operator.Interfaces;
using DatabaseValidation.Structure;

namespace DatabaseValidation.Operator
{
    public class UserFavoriteValidation : GenericValidation<UserFavorite>, IUserFavoriteValidation
    {
        public UserFavoriteValidation(DbContextModel context) : base(context)
        {
        }
    }
}
