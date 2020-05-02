using Database.Common.Interfaces;

namespace Database.Models
{
    public class SchoolCourseCertificate : Auditable
    {
        public int SchoolQuizCourseId { get; set; }
        public int SchoolCourseId { get; set; }



        public User OwnerUser { get; set; }
        public SchoolQuizCourse SchoolQuizCourse { get; set; }
        public SchoolCourse SchoolCourse { get; set; }
    }
} 