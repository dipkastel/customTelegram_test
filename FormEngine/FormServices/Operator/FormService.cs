using System;
using FormEngine.Database.Config;
using FormEngine.Database.Models;
using FormEngine.DatabaseValidation.Operator.Interface;
using FormEngine.Services.Operator.Interface;
using FormEngine.Services.Structure;

namespace FormEngine.Services.Operator
{
    public class FormService : GenericRepository<Form>, IFormService
    {
        private readonly IElementService _elementService;

        public FormService(FormEngineDbContext context, IFormValidation validation, IElementService elementService) : base(context, validation)
        {
            _elementService = elementService;
        }

        public string GetFormHtml(Guid formId)
        {
            var formResult = Get(formId);

            if (!formResult.Success || formResult.Data == null)
                return null;

            var form = formResult.Data;

            var body = string.Empty;

            if (string.IsNullOrWhiteSpace(form.Html))
            {
                body = _elementService.GetElementHtml(formId);

                if (string.IsNullOrWhiteSpace(body))
                    return null;

                form.Html = body;
            }

            Update(form, 1);

            return body;
        }
    }
}