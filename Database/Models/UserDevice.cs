using System;
using System.Collections.Generic;
using System.Text;
using Database.Common.Interfaces;

namespace Database.Models
{
    public class UserDevice : Auditable
    {
        public int DeviceTypeId { get; set; }
        
        
        
        
        
        
        
        public DeviceType DeviceType { get; set; }
    }
}
