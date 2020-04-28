using Database.Config;
using Database.Models;
using DatabaseValidation.Operator.Interfaces;
using DatabaseValidation.Structure;

namespace DatabaseValidation.Operator
{
    public class TesterProfileValidation : GenericValidation<TesterProfile>, ITesterProfileValidation
    {
        public TesterProfileValidation(DbContextModel context) : base(context)
        {
        }
    }
}
