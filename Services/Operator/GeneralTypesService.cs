using Database.Config;
using Database.Models;
using DatabaseValidation.Structure;
using Services.Operator.Interfaces;
using Services.Repository;

namespace Services.Operator
{
    public class GeneralTypesService : GenericRepository<GeneralTypes>, IGeneralTypesService
    {
        public GeneralTypesService(DbContextModel context, IGenericValidation<GeneralTypes> validation)
            : base(context, validation)
        {

        }
    }
}
