using System.Collections.Generic;
using Database.Models;
using Services.Repository;

namespace Services.Operator.Interfaces
{
    public interface IUserFavoriteService : IGenericRepository<UserFavorite>
    {
        void DisableAll(int userId);
        void AddRange(List<UserFavorite> userFavorites, int userId);
    }
}
