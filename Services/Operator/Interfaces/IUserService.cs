using Database.Models;
using Microsoft.AspNetCore.Http;
using Services.Repository;

namespace Services.Operator.Interfaces
{
    public interface IUserService : IGenericRepository<User>
    {
        string GetDeviceAgentCode(string mobileNumber, HttpRequest httpContextRequest);
    }
}
