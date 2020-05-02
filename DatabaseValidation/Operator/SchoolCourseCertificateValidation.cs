using Database.Config;
using Database.Models;
using DatabaseValidation.Operator.Interfaces;
using DatabaseValidation.Structure;

namespace DatabaseValidation.Operator
{
    public class SchoolCourseCertificateValidation : GenericValidation<SchoolCourseCertificate>, ISchoolCourseCertificateValidation
    {
        public SchoolCourseCertificateValidation(DbContextModel context) : base(context)
        {
        }
    }
}