using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Database.Common;
using Database.Common.Interfaces;

namespace Database.Models
{
    public class GeneralTypes : Auditable
    {

        

        public int Status { get; set; }
        public int TypeModel { get; set; }
        public int TypeKey { get; set; }
        public string TypeName { get; set; }

    }
}
