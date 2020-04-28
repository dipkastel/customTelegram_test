using Database.Config;
using Database.Models;
using DatabaseValidation.Operator.Interfaces;
using DatabaseValidation.Structure;
using Services.Operator.Interfaces;
using Services.Repository;

namespace Services.Operator
{
    public class UserFavoriteService : GenericRepository<UserFavorite>, IUserFavoriteService
    {
        public UserFavoriteService(DbContextModel context, IUserFavoriteValidation validation)
            : base(context, validation)
        {

        }
    }
}
