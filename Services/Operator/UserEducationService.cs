using Database.Config;
using Database.Models;
using DatabaseValidation.Structure;
using Services.Operator.Interfaces;
using Services.Repository;

namespace Services.Operator
{
    public class UserEducationService : GenericRepository<UserEducation>, IUserEducationService
    {
        public UserEducationService(DbContextModel context, IGenericValidation<UserEducation> validation)
            : base(context, validation)
        {

        }
    }
}
