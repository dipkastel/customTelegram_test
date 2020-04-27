using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Database.Common;

namespace Database.Models
{
    public class Location
    {
        [Key]
        public int Id { get; set; }

        public Location Parent { get; set; }
        public string Name { get; set; }
        public double Latetude { get; set; }
        public double Longtude { get; set; }
        public int Radius { get; set; }
        
        public virtual List<Location> Childs { set; get; }


    }
}
