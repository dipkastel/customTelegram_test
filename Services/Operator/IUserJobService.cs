using Database.Config;
using Database.Models;
using DatabaseValidation.Structure;
using Services.Operator.Interfaces;
using Services.Repository;

namespace Services.Operator
{
    public class UserJobService : GenericRepository<UserJob>, IUserJobService
    {
        public UserJobService(DbContextModel context, IGenericValidation<UserJob> validation)
            : base(context, validation)
        {

        }
    }
}
