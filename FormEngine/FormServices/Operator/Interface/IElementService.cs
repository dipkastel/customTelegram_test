using System;
using FormEngine.Database.Models;
using FormEngine.Services.Structure;

namespace FormEngine.Services.Operator.Interface
{
    public interface IElementService : IGenericRepository<Element>
    {
        string GetElementHtml(Guid formId);
    }
}