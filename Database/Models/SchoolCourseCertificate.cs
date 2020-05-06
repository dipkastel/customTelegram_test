using Database.Common.Interfaces;

namespace Database.Models
{
    public class SchoolCourseCertificate : Auditable
    {
        public int SchoolQuizCourseId { get; set; }



        public User OwnerUser { get; set; }
        public SchoolQuizCourse SchoolQuizCourse { get; set; }
    }
} 