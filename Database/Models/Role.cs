using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Database.Common;
using Database.Common.Interfaces;

namespace Database.Models
{
    public class Role : Auditable
    {
        


        public string Name { get; set; }
    }
}
