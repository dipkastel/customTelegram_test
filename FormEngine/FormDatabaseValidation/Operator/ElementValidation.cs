using FormEngine.Database.Config;
using FormEngine.Database.Models;
using FormEngine.DatabaseValidation.Operator.Interface;
using FormEngine.DatabaseValidation.Structure;

namespace FormEngine.DatabaseValidation.Operator
{
    public class ElementValidation : GenericValidation<Element>, IElementValidation
    {
        public ElementValidation(FormEngineDbContext context) : base(context)
        {
        }
    }
}