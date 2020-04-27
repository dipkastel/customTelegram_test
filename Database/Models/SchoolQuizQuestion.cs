using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Database.Common;
using Database.Common.Interfaces;

namespace Database.Models
{
    public class SchoolQuizQuestion : Auditable
    {
        


        public int Type { get; set; }
        public string Question { get; set; }
        public string CorrectAnswer { get; set; }
        public ICollection<SchoolQuisQuestionOption> Options { get; set; }

    }
}
