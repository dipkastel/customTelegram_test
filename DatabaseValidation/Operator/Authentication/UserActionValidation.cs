using Database.Config;
using Database.Models.Authentication;
using DatabaseValidation.Operator.Authentication.Interfaces;
using DatabaseValidation.Structure;

namespace DatabaseValidation.Operator.Authentication
{
    public class UserActionValidation : GenericValidation<UserAction>, IUserActionValidation
    {
        public UserActionValidation(DbContextModel context) : base(context)
        {
        }
    }
}