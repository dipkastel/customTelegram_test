using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Database.Common;
using Database.Common.Interfaces;

namespace Database.Models
{
    public class SchoolUnit : Auditable
    {
        


        public string Title { get; set; }
        public string Body { get; set; }
    }
}
