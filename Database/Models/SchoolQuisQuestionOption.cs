using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Database.Common;
using Database.Common.Interfaces;

namespace Database.Models
{
    public class SchoolQuisQuestionOption : Auditable
    {
        

        public string Option { get; set; }
        public bool IsCorrect { get; set; }
    }
}
