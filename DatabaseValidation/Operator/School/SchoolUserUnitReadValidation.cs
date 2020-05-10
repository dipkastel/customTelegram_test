using Database.Config;
using Database.Models;
using DatabaseValidation.Operator.School.Interfaces;
using DatabaseValidation.Structure;

namespace DatabaseValidation.Operator.School
{
    public class SchoolUserUnitReadValidation : GenericValidation<SchoolUserUnitRead>, ISchoolUserUnitReadValidation
    {
        public SchoolUserUnitReadValidation(DbContextModel context) : base(context)
        {
        }
    }
}