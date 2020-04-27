using Database.Config;
using Database.Models;
using DatabaseValidation.Structure;
using Services.Operator.Interfaces;
using Services.Repository;

namespace Services.Operator
{
    public class SchoolQuizQuestionService : GenericRepository<SchoolQuizQuestion>, ISchoolQuizQuestionService
    {
        public SchoolQuizQuestionService(DbContextModel context, IGenericValidation<SchoolQuizQuestion> validation)
            : base(context, validation)
        {

        }

    }
}
