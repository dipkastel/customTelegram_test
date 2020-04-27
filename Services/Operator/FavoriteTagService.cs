using Database.Config;
using Database.Models;
using DatabaseValidation.Structure;
using Services.Operator.Interfaces;
using Services.Repository;

namespace Services.Operator
{
    public class FavoriteTagService : GenericRepository<FavoriteTag>, IFavoriteTagService
    {
        public FavoriteTagService(DbContextModel context, IGenericValidation<FavoriteTag> validation)
            : base(context, validation)
        {

        }
    }
}
