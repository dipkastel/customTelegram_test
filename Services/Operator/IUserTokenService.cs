using Database.Config;
using Database.Models;
using DatabaseValidation.Structure;
using Services.Operator.Interfaces;
using Services.Repository;

namespace Services.Operator
{
    public class UserTokenService : GenericRepository<UserToken>, IUserTokenService
    {
        public UserTokenService(DbContextModel context, IGenericValidation<UserToken> validation)
            : base(context, validation)
        {
            
        }

    }
}
