using Database.Config;
using Database.Models;
using DatabaseValidation.Operator.Interfaces;
using DatabaseValidation.Structure;

namespace DatabaseValidation.Operator
{
    public class SchoolQuizCourseValidation : GenericValidation<SchoolQuizCourse>, ISchoolQuizCourseValidation
    {
        public SchoolQuizCourseValidation(DbContextModel context) : base(context)
        {
        }
    }
}
