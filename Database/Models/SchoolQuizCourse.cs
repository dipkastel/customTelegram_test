﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Database.Common;
using Database.Common.Interfaces;

namespace Database.Models
{
    public class SchoolQuizCourse : Auditable
    {
        

        public SchoolQuizQuestion Question { get; set; }
    }
}
