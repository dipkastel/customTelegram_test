using Database.Config;
using Database.Models;
using DatabaseValidation.Structure;
using Services.Operator.Interfaces;
using Services.Repository;

namespace Services.Operator
{
    public class UserFavoriteService : GenericRepository<UserFavorite>, IUserFavoriteService
    {
        public UserFavoriteService(DbContextModel context, IGenericValidation<UserFavorite> validation)
            : base(context, validation)
        {

        }
    }
}
