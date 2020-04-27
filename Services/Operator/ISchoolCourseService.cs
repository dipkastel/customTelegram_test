using Database.Config;
using Database.Models;
using DatabaseValidation.Structure;
using Services.Operator.Interfaces;
using Services.Repository;

namespace Services.Operator
{
    public class SchoolCourseService : GenericRepository<SchoolCourse>, ISchoolCourseService
    {
        public SchoolCourseService(DbContextModel context, IGenericValidation<SchoolCourse> validation)
            : base(context, validation)
        {

        }
    }
}
