using Database.Models;
using Microsoft.AspNetCore.Http;
using Services.Repository;

namespace Services.Operator.Interfaces
{
    public interface IUserService : IGenericRepository<User>
    {
        string GetUserUniqKey(string mobileNumber, HttpRequest httpContextRequest);
    }
}
