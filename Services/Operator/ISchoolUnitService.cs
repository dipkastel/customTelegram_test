using Database.Config;
using Database.Models;
using DatabaseValidation.Structure;
using Services.Operator.Interfaces;
using Services.Repository;

namespace Services.Operator
{
    public class SchoolUnitService : GenericRepository<SchoolUnit>, ISchoolUnitService
    {
        public SchoolUnitService(DbContextModel context, IGenericValidation<SchoolUnit> validation)
            : base(context, validation)
        {

        }
    }
}
