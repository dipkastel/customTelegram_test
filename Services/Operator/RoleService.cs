using Database.Config;
using Database.Models;
using DatabaseValidation.Structure;
using Services.Operator.Interfaces;
using Services.Repository;

namespace Services.Operator
{
    public class RoleService : GenericRepository<Role>, IRoleService
    {
        public RoleService(DbContextModel context, IGenericValidation<Role> validation)
            : base(context, validation)
        {

        }
    }
}
