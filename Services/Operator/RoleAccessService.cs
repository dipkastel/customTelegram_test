using Database.Config;
using Database.Models;
using DatabaseValidation.Structure;
using Services.Operator.Interfaces;
using Services.Repository;

namespace Services.Operator
{
    public class RoleAccessService : GenericRepository<RoleAccess>, IRoleAccessService
    {
        public RoleAccessService(DbContextModel context, IGenericValidation<RoleAccess> validation)
            : base(context, validation)
        {

        }
    }
}
