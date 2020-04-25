using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading.Tasks;

namespace alphadinCore.Model
{
    public class RoleAccessModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public RoleModel Role { get; set; }
        public string AccessName { get; set; }
    }
}
