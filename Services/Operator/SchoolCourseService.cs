using Database.Config;
using Database.Models;
using DatabaseValidation.Operator.Interfaces;
using DatabaseValidation.Structure;
using Services.Operator.Interfaces;
using Services.Repository;

namespace Services.Operator
{
    public class SchoolCourseService : GenericRepository<SchoolCourse>, ISchoolCourseService
    {
        public SchoolCourseService(DbContextModel context, ISchoolCourseValidation validation)
            : base(context, validation)
        {

        }
    }
}
