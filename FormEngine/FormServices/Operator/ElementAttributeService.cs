using System;
using System.Collections.Generic;
using FormEngine.Database.Config;
using FormEngine.Database.Models;
using FormEngine.DatabaseValidation.Operator.Interface;
using FormEngine.Services.Operator.Interface;
using FormEngine.Services.Structure;

namespace FormEngine.Services.Operator
{
    public class ElementAttributeService : GenericRepository<ElementAttribute>, IElementAttributeService
    {
        public ElementAttributeService(FormEngineDbContext context, IElementAttributeValidation validation) : base(context, validation)
        {
        }

        public IDictionary<string, string> GetHtmlAttribute(Guid elementId)
        {
            throw new NotImplementedException();
        }

    }
}