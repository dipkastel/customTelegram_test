using FormEngine.Database.Config;
using FormEngine.Database.Models;
using FormEngine.DatabaseValidation.Operator.Interface;
using FormEngine.DatabaseValidation.Structure;

namespace FormEngine.DatabaseValidation.Operator
{
    public class HtmlAttributeValidation : GenericValidation<HtmlAttribute>, IHtmlAttributeValidation
    {
        public HtmlAttributeValidation(FormEngineDbContext context) : base(context)
        {
        }
    }
}