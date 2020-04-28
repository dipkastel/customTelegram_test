using Database.Config;
using Database.Models;
using DatabaseValidation.Operator.Interfaces;
using DatabaseValidation.Structure;
using Services.Operator.Interfaces;
using Services.Repository;

namespace Services.Operator
{
    public class SchoolTopicService : GenericRepository<SchoolTopic>, ISchoolTopicService
    {
        public SchoolTopicService(DbContextModel context, ISchoolTopicValidation validation)
            : base(context, validation)
        {

        }
    }
}
