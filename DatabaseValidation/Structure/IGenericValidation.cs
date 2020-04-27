using Database.Common;
using Database.Common.Interfaces;

namespace DatabaseValidation.Structure
{
    public interface IGenericValidation<T> where T : Auditable
    {
        bool InsertValidation<T>(T entity, out string message);
        bool UpdateValidation<T>(T entity, out string message);
        bool DeleteValidation<T>(T entity, out string message);
    }
}