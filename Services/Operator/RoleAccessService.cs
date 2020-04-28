using Database.Config;
using Database.Models;
using DatabaseValidation.Operator.Interfaces;
using DatabaseValidation.Structure;
using Services.Operator.Interfaces;
using Services.Repository;

namespace Services.Operator
{
    public class RoleAccessService : GenericRepository<RoleAccess>, IRoleAccessService
    {
        public RoleAccessService(DbContextModel context, IRoleAccessValidation validation)
            : base(context, validation)
        {

        }
    }
}
