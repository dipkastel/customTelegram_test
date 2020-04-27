using Database.Common;
using Database.Common.Interfaces;
using Database.Config;

namespace DatabaseValidation.Structure
{
    public class GenericValidation<T> : IGenericValidation<T> where T : Auditable
    {
        protected DbContextModel Context;

        public GenericValidation(DbContextModel context)
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