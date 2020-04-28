using Database.Config;
using Database.Models;
using DatabaseValidation.Operator.Interfaces;
using DatabaseValidation.Structure;
using Services.Operator.Interfaces;
using Services.Repository;

namespace Services.Operator
{
    public class SchoolQuisQuestionOptionService : GenericRepository<SchoolQuisQuestionOption>, ISchoolQuisQuestionOptionService
    {
        public SchoolQuisQuestionOptionService(DbContextModel context, ISchoolQuisQuestionOptionValidation validation)
            : base(context, validation)
        {

        }
    }
}
