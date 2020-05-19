using FormEngine.Database.Config;
using FormEngine.Database.Models;
using FormEngine.DatabaseValidation.Operator.Interface;
using FormEngine.Services.Operator.Interface;
using FormEngine.Services.Structure;

namespace FormEngine.Services.Operator
{
    public class HtmlAttributeService : GenericRepository<HtmlAttribute>, IHtmlAttributeService
    {
        public HtmlAttributeService(FormEngineDbContext context, IHtmlAttributeValidation validation) : base(context, validation)
        {
        }
    }
}