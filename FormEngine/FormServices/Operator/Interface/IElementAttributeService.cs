using System;
using System.Collections.Generic;
using FormEngine.Database.Models;
using FormEngine.Services.Structure;

namespace FormEngine.Services.Operator.Interface
{
    public interface IElementAttributeService : IGenericRepository<ElementAttribute>
    {
        IDictionary<string, string> GetHtmlAttribute(Guid elementId);
    }
}