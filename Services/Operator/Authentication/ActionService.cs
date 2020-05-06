using Database.Config;
using Database.Models.Authentication;
using DatabaseValidation.Operator.Authentication.Interfaces;
using DatabaseValidation.Structure;
using Services.Operator.Authentication.Interfaces;
using Services.Repository;

namespace Services.Operator.Authentication
{
    public class ActionService : GenericRepository<Action>, IActionService
    {
        public ActionService(DbContextModel context, IActionValidation validation) : base(context, validation)
        {
        }
    }
}