using FormEngine.Database.Config;
using FormEngine.Database.Models;
using FormEngine.DatabaseValidation.Structure;
using FormEngine.Services.Operator.Interface;
using FormEngine.Services.Structure;

namespace FormEngine.Services.Operator
{
    public class HtmlTagService : GenericRepository<HtmlTag>, IHtmlTagService
    {
        public HtmlTagService(FormEngineDbContext context, IGenericValidation<HtmlTag> validation) : base(context, validation)
        {
        }

    }
}