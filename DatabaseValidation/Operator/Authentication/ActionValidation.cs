using Database.Config;
using Database.Models.Authentication;
using DatabaseValidation.Operator.Authentication.Interfaces;
using DatabaseValidation.Structure;

namespace DatabaseValidation.Operator.Authentication
{
    public class ActionValidation : GenericValidation<Action>, IActionValidation
    {
        public ActionValidation(DbContextModel context) : base(context)
        {
        }
    }
}