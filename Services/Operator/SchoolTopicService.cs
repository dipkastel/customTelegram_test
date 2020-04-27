using Database.Config;
using Database.Models;
using DatabaseValidation.Structure;
using Services.Operator.Interfaces;
using Services.Repository;

namespace Services.Operator
{
    public class SchoolTopicService : GenericRepository<SchoolTopic>, ISchoolTopicService
    {
        public SchoolTopicService(DbContextModel context, IGenericValidation<SchoolTopic> validation)
            : base(context, validation)
        {

        }
    }
}
