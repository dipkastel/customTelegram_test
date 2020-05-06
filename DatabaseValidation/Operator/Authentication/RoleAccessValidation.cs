using Database.Config;
using Database.Models.Authentication;
using DatabaseValidation.Operator.Authentication.Interfaces;
using DatabaseValidation.Structure;

namespace DatabaseValidation.Operator.Authentication
{
    public class RoleAccessValidation : GenericValidation<RoleAccess>, IRoleAccessValidation
    {
        public RoleAccessValidation(DbContextModel context) : base(context)
        {
        }
    }
}
