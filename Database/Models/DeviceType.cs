using Database.Common.Interfaces;

namespace Database.Models
{
    public class DeviceType : Auditable
    {
        public string Title { get; set; }
        public string OS { get; set; }
    }
}