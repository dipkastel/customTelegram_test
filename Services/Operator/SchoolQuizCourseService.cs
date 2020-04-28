using Database.Config;
using Database.Models;
using DatabaseValidation.Operator.Interfaces;
using DatabaseValidation.Structure;
using Services.Operator.Interfaces;
using Services.Repository;

namespace Services.Operator
{
    public class SchoolQuizCourseService : GenericRepository<SchoolQuizCourse>, ISchoolQuizCourseService
    {
        public SchoolQuizCourseService(DbContextModel context, ISchoolQuizCourseValidation validation)
            : base(context, validation)
        {

        }
    }
}
