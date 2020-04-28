using Database.Config;
using Database.Models;
using DatabaseValidation.Operator.Interfaces;
using DatabaseValidation.Structure;

namespace DatabaseValidation.Operator
{
    public class SchoolUnitValidation : GenericValidation<SchoolUnit>, ISchoolUnitValidation
    {
        public SchoolUnitValidation(DbContextModel context) : base(context)
        {
        }
    }
}
