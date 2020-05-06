using Database.Common.Interfaces;

namespace Database.Models.Authentication
{
    public class UserAction : Auditable
    {
        public int ActionId { get; set; }


        public User OwnerUser { get; set; }
        public Action Action { get; set; }
    }
}