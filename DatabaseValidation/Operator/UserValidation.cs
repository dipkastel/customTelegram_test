using Database.Config;
using Database.Models;
using DatabaseValidation.Operator.Interfaces;
using DatabaseValidation.Structure;

namespace DatabaseValidation.Operator
{
    public class UserValidation : GenericValidation<User>, IUserValidation
    {
        public UserValidation(DbContextModel context) : base(context)
        {
        }
    }
}
