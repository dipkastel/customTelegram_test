using Database.Config;
using Database.Models;
using DatabaseValidation.Operator.Interfaces;
using DatabaseValidation.Structure;
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
    }
}
