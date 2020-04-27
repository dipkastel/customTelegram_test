using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Database.Common;
using Database.Common.Interfaces;

namespace Database.Models
{
    public class RoleAccess : Auditable
    {
        

        public Role Role { get; set; }
        public string AccessName { get; set; }
    }
}
