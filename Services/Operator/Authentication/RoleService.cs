using Database.Config;
using Database.Models.Authentication;
using DatabaseValidation.Operator.Authentication.Interfaces;
using DatabaseValidation.Operator.Interfaces;
using Services.Operator.Authentication.Interfaces;
using Services.Repository;

namespace Services.Operator.Authentication
{
    public class RoleService : GenericRepository<Role>, IRoleService
    {
        public RoleService(DbContextModel context, IRoleValidation validation)
            : base(context, validation)
        {

        }
    }
}
