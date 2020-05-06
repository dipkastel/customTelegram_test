using Database.Config;
using Database.Models;
using DatabaseValidation.Operator.Interfaces;
using DatabaseValidation.Structure;
using Microsoft.AspNetCore.Http;
using Services.Common.Cryptography;
using Services.Operator.Interfaces;
using Services.Repository;

namespace Services.Operator
{
    public class UserService : GenericRepository<User>, IUserService
    {
        public UserService(DbContextModel context, IUserValidation validation)
            : base(context, validation)
        {

        }

        public string GetUserUniqueKey(string mobileNumber, string userAgent)
        {
            var deviceAgent = MD5.Generate(mobileNumber + userAgent);
            return deviceAgent;
        }


    }
}
