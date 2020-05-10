using System.Collections.Generic;
using Database.Models;

namespace Services.ViewModels.School
{
    public class SchoolCourseViewModel
    {
        public int Id { get; }
        public string Title { get; }
        public int ReadTime { get; }
        public ICollection<SchoolUnit> Units { get; }

        public SchoolCourseViewModel(int id, string title, int readTime, ICollection<SchoolUnit> units)
        {
            Id = id;
            Title = title;
            ReadTime = readTime;
            Units = units;
        }
    }
}