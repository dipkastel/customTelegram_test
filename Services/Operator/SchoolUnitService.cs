using System.Linq;
using Database.Config;
using Database.Models;
using DatabaseValidation.Operator.Interfaces;
using DatabaseValidation.Structure;
using Services.Operator.Interfaces;
using Services.Repository;

namespace Services.Operator
{
    public class SchoolUnitService : GenericRepository<SchoolUnit>, ISchoolUnitService
    {
        public SchoolUnitService(DbContextModel context, ISchoolUnitValidation validation)
            : base(context, validation)
        {

        }

        public int GetUnitsCount(int courseId)
        {
            var unitsCount = FindBy(u => u.CourseId == courseId).Data.Count();
            return unitsCount;
        }
    }
}
