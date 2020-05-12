using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Database.Common;
using Database.Common.Interfaces;

namespace Database.Models
{
    public class SchoolUnit : Auditable
    {
        public int CourseId { get; set; }
        public int PageNumber { get; set; }


        public string Title { get; set; }
        public string Body { get; set; }

        public SchoolCourse Course { get; set; }
    }
}
