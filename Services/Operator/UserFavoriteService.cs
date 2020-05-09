using System;
using System.Collections.Generic;
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

        public void DisableAll(int userId)
        {
            var tagsResult = FindAll(uf => uf.OwnerUserId == userId);

            if (!tagsResult.Success || tagsResult.Count <= 0)
            {
                return;
            }

            foreach (var userFavorite in tagsResult.Data)
            {
                Disable(userFavorite.Id, userId);
            }

        }

        public void AddRange(List<UserFavorite> userFavorites, int userId)
        {
            foreach (var userFavorite in userFavorites)
            {
                Add(userFavorite, userId);
            }
        }
    }
}
