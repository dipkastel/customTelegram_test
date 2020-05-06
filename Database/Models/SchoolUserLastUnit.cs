using Database.Common.Interfaces;

namespace Database.Models
{
    public class SchoolUserLastUnit : Auditable
    {

        public int CourseId { get; set; }
        public int UnitId { get; set; }
        
        public User OwnerUser { get; set; }
        public SchoolCourse Course { get; set; }
        public SchoolUnit Unit { get; set; }
    }
}