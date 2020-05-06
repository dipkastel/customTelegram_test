using Database.Config;
using Database.Models.Authentication;
using DatabaseValidation.Operator.Authentication.Interfaces;
using DatabaseValidation.Structure;

namespace DatabaseValidation.Operator.Authentication
{
    public class RoleActionValidation : GenericValidation<RoleAction>, IRoleActionValidation
    {
        public RoleActionValidation(DbContextModel context) : base(context)
        {
        }
    }
}