using Database.Config;
using Database.Models;
using DatabaseValidation.Operator.Interfaces;
using DatabaseValidation.Structure;
using Services.Operator.Interfaces;
using Services.Repository;

namespace Services.Operator
{
    public class UserSocialsService : GenericRepository<UserSocials>, IUserSocialsService
    {
        public UserSocialsService(DbContextModel context, IUserSocialsValidation validation)
            : base(context, validation)
        {

        }

    }
}
