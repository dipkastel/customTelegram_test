using Database.Config;
using Database.Models;
using DatabaseValidation.Operator.Interfaces;
using DatabaseValidation.Structure;
using Services.Operator.Interfaces;
using Services.Repository;

namespace Services.Operator
{
    public class SchoolCourseCertificateService : GenericRepository<SchoolCourseCertificate>, ISchoolCourseCertificateService
    {
        public SchoolCourseCertificateService(DbContextModel context, ISchoolCourseCertificateValidation validation) : base(context, validation)
        {
        }
    }
}