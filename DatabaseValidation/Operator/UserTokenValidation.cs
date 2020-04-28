using Database.Config;
using Database.Models;
using DatabaseValidation.Operator.Interfaces;
using DatabaseValidation.Structure;

namespace DatabaseValidation.Operator
{
    public class UserTokenValidation : GenericValidation<UserToken>, IUserTokenValidation
    {
        public UserTokenValidation(DbContextModel context) : base(context)
        {
        }
    }
}
