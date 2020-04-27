using Database.Config;
using Database.Models;
using DatabaseValidation.Structure;
using Services.Operator.Interfaces;
using Services.Repository;

namespace Services.Operator
{
    public class SchoolQuizCourseService : GenericRepository<SchoolQuizCourse>, ISchoolQuizCourseService
    {
        public SchoolQuizCourseService(DbContextModel context, IGenericValidation<SchoolQuizCourse> validation)
            : base(context, validation)
        {

        }
    }
}
