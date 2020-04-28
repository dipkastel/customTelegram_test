using Database.Config;
using Database.Models;
using DatabaseValidation.Operator.Interfaces;
using DatabaseValidation.Structure;

namespace DatabaseValidation.Operator
{
    public class UserEducationValidation : GenericValidation<UserEducation>, IUserEducationValidation
    {
        public UserEducationValidation(DbContextModel context) : base(context)
        {
        }
    }
}
