using Database.Config;
using Database.Models;
using DatabaseValidation.Operator.Interfaces;
using DatabaseValidation.Structure;

namespace DatabaseValidation.Operator
{
    public class SchoolCourseValidation : GenericValidation<SchoolCourse>, ISchoolCourseValidation
    {
        public SchoolCourseValidation(DbContextModel context) : base(context)
        {
        }
    }
}
