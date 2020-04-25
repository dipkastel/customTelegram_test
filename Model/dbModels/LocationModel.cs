using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace alphadinCore.Model.dbModels
{
    public class LocationModel
    {
        public int Id { get; set; }
        public LocationModel Parent { get; set; }
        public string Name { get; set; }
        public double Latetude { get; set; }
        public double Longtude { get; set; }
        public int Radius { get; set; }
        
        public virtual List<LocationModel> Childs { set; get; }


    }
}
