using Database.Config;
using Database.Models;
using DatabaseValidation.Operator.Interfaces;
using DatabaseValidation.Structure;
using Services.Operator.Interfaces;
using Services.Repository;

namespace Services.Operator
{
    public class RoleService : GenericRepository<Role>, IRoleService
    {
        public RoleService(DbContextModel context, IRoleValidation validation)
            : base(context, validation)
        {

        }
    }
}
