using Database.Config;
using Database.Models;
using DatabaseValidation.Structure;
using Services.Operator.Interfaces;
using Services.Repository;

namespace Services.Operator
{
    public class UserService : GenericRepository<User>, IUserService
    {
        public UserService(DbContextModel context, IGenericValidation<User> validation)
            : base(context, validation)
        {

        }
    }
}
