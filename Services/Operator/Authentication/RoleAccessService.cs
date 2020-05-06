using Database.Config;
using Database.Models.Authentication;
using DatabaseValidation.Operator.Authentication.Interfaces;
using DatabaseValidation.Operator.Interfaces;
using Services.Operator.Authentication.Interfaces;
using Services.Repository;

namespace Services.Operator.Authentication
{
    public class RoleAccessService : GenericRepository<RoleAccess>, IRoleAccessService
    {
        public RoleAccessService(DbContextModel context, IRoleAccessValidation validation)
            : base(context, validation)
        {

        }
    }
}
