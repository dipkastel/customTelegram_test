using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Database.Common;
using Database.Common.Interfaces;

namespace Database.Models
{
    public class SchoolCourse : Auditable
    {
        


        public string Title { get; set; }
        public int ReadTime { get; set; }
        public ICollection<SchoolQuizCourse> Questions { get; set; }
        public ICollection<SchoolUnit> Units { get; set; }
    }
}
