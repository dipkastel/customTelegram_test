using Database.Config;
using Database.Models;
using DatabaseValidation.Operator.Interfaces;
using DatabaseValidation.Structure;
using Services.Operator.Interfaces;
using Services.Repository;

namespace Services.Operator
{
    public class TesterProfileService : GenericRepository<TesterProfile>, ITesterProfileService
    {
        public TesterProfileService(DbContextModel context, ITesterProfileValidation validation)
            : base(context, validation)
        {

        }
    }
}
