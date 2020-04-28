using Database.Config;
using Database.Models;
using DatabaseValidation.Operator.Interfaces;
using DatabaseValidation.Structure;

namespace DatabaseValidation.Operator
{
    public class UserLanguageValidation : GenericValidation<UserLanguage>, IUserLanguageValidation
    {
        public UserLanguageValidation(DbContextModel context) : base(context)
        {
        }
    }
}
