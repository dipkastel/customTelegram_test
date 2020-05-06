using System.Collections.Generic;
using Database.Common.Interfaces;

namespace Database.Models.Authentication
{
    public class Role : Auditable
    {
        public string Name { get; set; }

        public ICollection<RoleAction> RoleActions { get; set; }
    }
}
