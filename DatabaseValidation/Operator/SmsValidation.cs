using Database.Config;
using Database.Models;
using DatabaseValidation.Operator.Interfaces;
using DatabaseValidation.Structure;

namespace DatabaseValidation.Operator
{
    public class SmsValidation : GenericValidation<Sms>, ISmsValidation
    {
        public SmsValidation(DbContextModel context) : base(context)
        {
        }
    }
}
