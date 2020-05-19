using FormEngine.Database.Common.Interface;
using FormEngine.Database.Config;

namespace FormEngine.DatabaseValidation.Structure
{
    public class GenericValidation<T> : IGenericValidation<T> where T : Auditable
    {
        protected FormEngineDbContext Context;

        public GenericValidation(FormEngineDbContext context)
        {
            Context = context;
        }

        public bool DeleteValidation<T>(T entity, out string validationMessage)
        {
            validationMessage = string.Empty;
            return true;
        }

        public bool InsertValidation<T>(T entity, out string validationMessage)
        {
            validationMessage = string.Empty;
            return true;
        }

        public bool UpdateValidation<T>(T entity, out string validationMessage)
        {
            validationMessage = string.Empty;
            return true;
        }
    }
}