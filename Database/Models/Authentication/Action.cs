using System.Collections.Generic;
using Database.Common.Interfaces;

namespace Database.Models.Authentication
{
    public class Action : Auditable
    {
        public string Name { get; set; }

        public int Type { get; set; }
        public int? ParentId { get; set; }
        public Action Parent { get; set; }



        public ICollection<RoleAction> RoleActions { get; set; }
        public ICollection<UserAction> UserActions { get; set; }
    }
}