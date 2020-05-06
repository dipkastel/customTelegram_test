using Database.Config;
using Database.Models.Authentication;
using DatabaseValidation.Operator.Authentication.Interfaces;
using DatabaseValidation.Structure;

namespace DatabaseValidation.Operator.Authentication
{
    public class RoleValidation : GenericValidation<Role>, IRoleValidation
    {
        public RoleValidation(DbContextModel context) : base(context)
        {
        }
    }
}
