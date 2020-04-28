using Database.Config;
using DatabaseValidation.Operator.Interfaces;
using Services.Operator.Interfaces;

namespace Services.Operator
{
    public class LanguageService : ILanguageService
    {
        private readonly DbContextModel _dbContext;
        private readonly ILanguageValidation _validation;

        public LanguageService(ILanguageValidation validation, DbContextModel dbContext)
        {
            _validation = validation;
            _dbContext = dbContext;
        }
    }
}
