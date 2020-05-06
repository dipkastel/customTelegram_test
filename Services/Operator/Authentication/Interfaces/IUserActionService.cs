using Database.Models.Authentication;
using Services.Repository;

namespace Services.Operator.Authentication.Interfaces
{
    public interface IUserActionService : IGenericRepository<Database.Models.Authentication.UserAction>
    {
        
    }
}