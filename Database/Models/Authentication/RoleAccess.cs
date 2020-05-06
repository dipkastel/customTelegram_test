using Database.Common.Interfaces;

namespace Database.Models.Authentication
{
    public class RoleAccess : Auditable
    {
        

        public Role Role { get; set; }
        public string AccessName { get; set; }
    }
}
