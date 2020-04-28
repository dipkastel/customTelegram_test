using Database.Config;
using Database.Models;
using DatabaseValidation.Operator.Interfaces;
using DatabaseValidation.Structure;
using Services.Operator.Interfaces;
using Services.Repository;

namespace Services.Operator
{
    public class UserJobService : GenericRepository<UserJob>, IUserJobService
    {
        public UserJobService(DbContextModel context, IUserJobValidation validation)
            : base(context, validation)
        {

        }
    }
}
