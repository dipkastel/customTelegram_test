using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading.Tasks;

namespace alphadinCore.Model
{
    public class LanguageModel
    {        public int Id { get; set; }
        public string Name { get; set; }
        public string iso_639 { get; set; }
    }
}
