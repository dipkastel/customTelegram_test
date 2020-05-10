namespace alphadinCore.Model.controllerModels
{
    public class SchoolModels
    {
    }

    public class SchoolGetCoursesInput {
        public int TopicId { get; set; }

    }

    public class SchoolGetUnitsInput
    {
        public int CourseId { get; set; }

    }

    public class SchoolGetLastUnitInput
    {
        public int CourseId { get; set; }

    }

    public class SchoolSetLastUnitInput
    {
        public int CourseId { get; set; }
        public int UnitId { get; set; }

    }
}
