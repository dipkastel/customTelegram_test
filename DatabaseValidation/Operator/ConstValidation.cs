using Database.Config;
using Database.Models;
using DatabaseValidation.Operator.Interfaces;
using DatabaseValidation.Structure;

namespace DatabaseValidation.Operator
{
    public class ConstValidation : GenericValidation<Const>, IConstValidation
    {
        public ConstValidation(DbContextModel context) : base(context)
        {
        }
    }
}
