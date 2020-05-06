using Database.Common.Interfaces;

namespace Database.Models.Authentication
{
    public class RoleAction : Auditable
    {
        public int RoleId { get; set; }
        public int ActionId { get; set; }
        
        public Role Role { get; set; }
        public Action Action { get; set; }
    }
}