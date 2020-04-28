using Database.Config;
using DatabaseValidation.Operator.Interfaces;
using Services.Operator.Interfaces;

namespace Services.Operator
{
    public class LocationService : ILocationService
    {
        private readonly DbContextModel _dbContext;
        private readonly ILocationValidation _validation;

        public LocationService(ILocationValidation validation, DbContextModel dbContext)
        {
            _validation = validation;
            _dbContext = dbContext;
        }
    }
}
