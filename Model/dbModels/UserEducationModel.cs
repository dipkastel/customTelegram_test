using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading.Tasks;

namespace alphadinCore.Model
{
    public class UserEducationModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int Status { get; set; }
        public UserModel user { get; set; }
        public int Grade { get; set; }
        public string Major { get; set; }
        public string Place { get; set; }
        public bool InProgress { get; set; }
    }
}
