using Database.Config;
using Database.Models;
using DatabaseValidation.Operator.Interfaces;
using DatabaseValidation.Structure;
using Services.Operator.Interfaces;
using Services.Repository;

namespace Services.Operator
{
    public class ConstService : GenericRepository<Const>, IConstService
    {
        public ConstService(DbContextModel context, IConstValidation validation)
            : base(context, validation)
        {

        }

    }
}
