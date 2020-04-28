using Database.Config;
using Database.Models;
using DatabaseValidation.Operator.Interfaces;
using DatabaseValidation.Structure;

namespace DatabaseValidation.Operator
{
    public class GeneralTypesValidation : GenericValidation<GeneralTypes>, IGeneralTypesValidation
    {
        public GeneralTypesValidation(DbContextModel context) : base(context)
        {
        }
    }
}
