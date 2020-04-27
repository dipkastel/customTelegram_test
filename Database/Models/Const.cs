using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Database.Common;
using Database.Common.Interfaces;

namespace Database.Models
{
    public class Const : Auditable
    {
        public string Name { get; set; }
        public string Property { get; set; }

    }
}
