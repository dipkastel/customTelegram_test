using Database.Config;
using Database.Models;
using DatabaseValidation.Operator.Interfaces;
using DatabaseValidation.Structure;

namespace DatabaseValidation.Operator
{
    public class SchoolQuizQuestionValidation : GenericValidation<SchoolQuizQuestion>, ISchoolQuizQuestionValidation
    {
        public SchoolQuizQuestionValidation(DbContextModel context) : base(context)
        {
        }
    }
}
