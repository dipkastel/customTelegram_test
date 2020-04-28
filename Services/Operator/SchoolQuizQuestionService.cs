using Database.Config;
using Database.Models;
using DatabaseValidation.Operator.Interfaces;
using DatabaseValidation.Structure;
using Services.Operator.Interfaces;
using Services.Repository;

namespace Services.Operator
{
    public class SchoolQuizQuestionService : GenericRepository<SchoolQuizQuestion>, ISchoolQuizQuestionService
    {
        public SchoolQuizQuestionService(DbContextModel context, ISchoolQuizQuestionValidation validation)
            : base(context, validation)
        {

        }

    }
}
