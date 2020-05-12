using Database.Models;
using Services.Repository;

namespace Services.Operator.Interfaces
{
    public interface ISchoolUnitService : IGenericRepository<SchoolUnit>
    {
        int GetUnitsCount(int courseId);

    }
}
