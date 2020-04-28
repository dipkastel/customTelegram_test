using Database.Config;
using Database.Models;
using DatabaseValidation.Operator.Interfaces;
using DatabaseValidation.Structure;

namespace DatabaseValidation.Operator
{
    public class SchoolQuisQuestionOptionValidation : GenericValidation<SchoolQuisQuestionOption>, ISchoolQuisQuestionOptionValidation
    {
        public SchoolQuisQuestionOptionValidation(DbContextModel context) : base(context)
        {
        }
    }
}
