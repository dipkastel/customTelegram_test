using Database.Config;
using Database.Models;
using DatabaseValidation.Operator.Interfaces;
using DatabaseValidation.Structure;
using Services.Operator.Interfaces;
using Services.Repository;

namespace Services.Operator
{
    public class UserTokenService : GenericRepository<UserToken>, IUserTokenService
    {
        public UserTokenService(DbContextModel context, IUserTokenValidation validation)
            : base(context, validation)
        {
            
        }

    }
}
