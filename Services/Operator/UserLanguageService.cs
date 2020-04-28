using Database.Config;
using Database.Models;
using DatabaseValidation.Operator.Interfaces;
using DatabaseValidation.Structure;
using Services.Operator.Interfaces;
using Services.Repository;

namespace Services.Operator
{
    public class UserLanguageService : GenericRepository<UserLanguage>, IUserLanguageService
    {
        public UserLanguageService(DbContextModel context, IUserLanguageValidation validation)
            : base(context, validation)
        {

        }
    }
}
