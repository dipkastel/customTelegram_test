using Database.Config;
using Database.Models;
using DatabaseValidation.Operator.School.Interfaces;
using DatabaseValidation.Structure;
using Services.Operator.School.Interfaces;
using Services.Repository;

namespace Services.Operator.School
{
    public class SchoolUserUnitReadService : GenericRepository<SchoolUserUnitRead>, ISchoolUserUnitReadService
    {
        public SchoolUserUnitReadService(DbContextModel context, ISchoolUserUnitReadValidation readValidation) : base(context, readValidation)
        {
        }
    }
}