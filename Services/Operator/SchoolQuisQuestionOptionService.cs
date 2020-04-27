using Database.Config;
using Database.Models;
using DatabaseValidation.Structure;
using Services.Operator.Interfaces;
using Services.Repository;

namespace Services.Operator
{
    public class SchoolQuisQuestionOptionService : GenericRepository<SchoolQuisQuestionOption>, ISchoolQuisQuestionOptionService
    {
        public SchoolQuisQuestionOptionService(DbContextModel context, IGenericValidation<SchoolQuisQuestionOption> validation)
            : base(context, validation)
        {

        }
    }
}
