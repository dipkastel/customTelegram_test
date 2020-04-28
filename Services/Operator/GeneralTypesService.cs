using Database.Config;
using Database.Models;
using DatabaseValidation.Operator.Interfaces;
using DatabaseValidation.Structure;
using Services.Operator.Interfaces;
using Services.Repository;

namespace Services.Operator
{
    public class GeneralTypesService : GenericRepository<GeneralTypes>, IGeneralTypesService
    {
        public GeneralTypesService(DbContextModel context, IGeneralTypesValidation validation)
            : base(context, validation)
        {

        }
    }
}
