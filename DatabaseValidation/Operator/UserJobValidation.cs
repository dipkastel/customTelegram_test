using Database.Config;
using Database.Models;
using DatabaseValidation.Operator.Interfaces;
using DatabaseValidation.Structure;

namespace DatabaseValidation.Operator
{
    public class UserJobValidation : GenericValidation<UserJob>, IUserJobValidation
    {
        public UserJobValidation(DbContextModel context) : base(context)
        {
        }
    }
}
