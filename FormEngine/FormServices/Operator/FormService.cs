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


        public FormService(FormEngineDbContext context, IFormValidation validation) : base(context, validation)
        {
        }

        public string GetFullHtml(Guid formId)
        {
            var html = string.Empty;


            return html;
        }
    }
}