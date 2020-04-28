using Database.Config;
using Database.Models;
using DatabaseValidation.Operator.Interfaces;
using DatabaseValidation.Structure;

namespace DatabaseValidation.Operator
{
    public class SchoolTopicValidation : GenericValidation<SchoolTopic>, ISchoolTopicValidation
    {
        public SchoolTopicValidation(DbContextModel context) : base(context)
        {
        }
    }
}
