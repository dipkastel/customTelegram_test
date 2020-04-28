using Database.Config;
using Database.Models;
using DatabaseValidation.Operator.Interfaces;
using DatabaseValidation.Structure;

namespace DatabaseValidation.Operator
{
    public class RoleValidation : GenericValidation<Role>, IRoleValidation
    {
        public RoleValidation(DbContextModel context) : base(context)
        {
        }
    }
}
