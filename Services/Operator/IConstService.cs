using Database.Config;
using Database.Models;
using DatabaseValidation.Structure;
using Services.Operator.Interfaces;
using Services.Repository;

namespace Services.Operator
{
    public class ConstService : GenericRepository<Const>, IConstService
    {
        public ConstService(DbContextModel context, IGenericValidation<Const> validation)
            : base(context, validation)
        {

        }

    }
}
