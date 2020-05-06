using Database.Config;
using Database.Models.Authentication;
using DatabaseValidation.Operator.Authentication.Interfaces;
using DatabaseValidation.Structure;
using Services.Operator.Authentication.Interfaces;
using Services.Repository;

namespace Services.Operator.Authentication
{
    public class RoleActionService : GenericRepository<RoleAction>, IRoleActionService
    {
        public RoleActionService(DbContextModel context, IRoleActionValidation validation) : base(context, validation)
        {
        }
    }
}