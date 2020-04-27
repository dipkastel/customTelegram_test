using Database.Config;
using Database.Models;
using DatabaseValidation.Structure;
using Services.Operator.Interfaces;
using Services.Repository;

namespace Services.Operator
{
    public class UserSocialsService : GenericRepository<UserSocials>, IUserSocialsService
    {
        public UserSocialsService(DbContextModel context, IGenericValidation<UserSocials> validation)
            : base(context, validation)
        {

        }

    }
}
