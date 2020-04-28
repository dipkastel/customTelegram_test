using Database.Config;
using Database.Models;
using DatabaseValidation.Operator.Interfaces;
using DatabaseValidation.Structure;

namespace DatabaseValidation.Operator
{
    public class FavoriteTagValidation : GenericValidation<FavoriteTag>, IFavoriteTagValidation
    {
        public FavoriteTagValidation(DbContextModel context) : base(context)
        {
        }
    }
}
