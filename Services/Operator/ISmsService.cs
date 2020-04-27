using Database.Config;
using Database.Models;
using DatabaseValidation.Structure;
using Services.Operator.Interfaces;
using Services.Repository;

namespace Services.Operator
{
    public class SmsService : GenericRepository<Sms>, ISmsService
    {
        public SmsService(DbContextModel context, IGenericValidation<Sms> validation)
            : base(context, validation)
        {

        }

    }
}
