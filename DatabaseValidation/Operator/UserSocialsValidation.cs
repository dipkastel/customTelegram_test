using Database.Config;
using Database.Models;
using DatabaseValidation.Operator.Interfaces;
using DatabaseValidation.Structure;

namespace DatabaseValidation.Operator
{
    public class UserSocialsValidation : GenericValidation<UserSocials>, IUserSocialsValidation
    {
        public UserSocialsValidation(DbContextModel context) : base(context)
        {
        }
    }
}
