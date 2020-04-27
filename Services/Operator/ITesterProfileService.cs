using Database.Config;
using Database.Models;
using DatabaseValidation.Structure;
using Services.Operator.Interfaces;
using Services.Repository;

namespace Services.Operator
{
    public class TesterProfileService : GenericRepository<TesterProfile>, ITesterProfileService
    {
        public TesterProfileService(DbContextModel context, IGenericValidation<TesterProfile> validation)
            : base(context, validation)
        {

        }
    }
}
