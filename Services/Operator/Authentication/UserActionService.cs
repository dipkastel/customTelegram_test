using Database.Config;
using Database.Models.Authentication;
using DatabaseValidation.Operator.Authentication.Interfaces;
using DatabaseValidation.Structure;
using Services.Operator.Authentication.Interfaces;
using Services.Repository;

namespace Services.Operator.Authentication
{
    public class UserActionService : GenericRepository<UserAction>, IUserActionService
    {
        public UserActionService(DbContextModel context, IUserActionValidation validation) : base(context, validation)
        {
        }
    }
}