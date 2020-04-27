using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Database.Common;
using Database.Common.Interfaces;

namespace Database.Models
{
    public class SchoolTopic : Auditable
    {
        


        public string ImageUrl { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }
        public ICollection<SchoolCourse> Courses { get; set; }
    }
}
