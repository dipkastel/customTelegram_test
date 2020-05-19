using FormEngine.Database.Config;
using FormEngine.Database.Models;
using FormEngine.DatabaseValidation.Operator.Interface;
using FormEngine.DatabaseValidation.Structure;

namespace FormEngine.DatabaseValidation.Operator
{
    public class ElementAttributeValidation : GenericValidation<ElementAttribute>, IElementAttributeValidation
    {
        public ElementAttributeValidation(FormEngineDbContext context) : base(context)
        {
        }
    }
}