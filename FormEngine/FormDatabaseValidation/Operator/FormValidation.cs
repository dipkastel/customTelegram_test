using FormEngine.Database.Config;
using FormEngine.Database.Models;
using FormEngine.DatabaseValidation.Operator.Interface;
using FormEngine.DatabaseValidation.Structure;

namespace FormEngine.DatabaseValidation.Operator
{
    public class FormValidation : GenericValidation<Form>, IFormValidation
    {
        public FormValidation(FormEngineDbContext context) : base(context)
        {
        }
    }
}