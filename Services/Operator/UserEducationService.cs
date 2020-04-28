using Database.Config;
using Database.Models;
using DatabaseValidation.Operator.Interfaces;
using DatabaseValidation.Structure;
using Services.Operator.Interfaces;
using Services.Repository;

namespace Services.Operator
{
    public class UserEducationService : GenericRepository<UserEducation>, IUserEducationService
    {
        public UserEducationService(DbContextModel context, IUserEducationValidation validation)
            : base(context, validation)
        {

        }
    }
}
