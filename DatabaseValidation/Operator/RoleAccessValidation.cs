using Database.Config;
using Database.Models;
using DatabaseValidation.Operator.Interfaces;
using DatabaseValidation.Structure;

namespace DatabaseValidation.Operator
{
    public class RoleAccessValidation : GenericValidation<RoleAccess>, IRoleAccessValidation
    {
        public RoleAccessValidation(DbContextModel context) : base(context)
        {
        }
    }
}
