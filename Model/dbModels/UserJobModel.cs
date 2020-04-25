using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading.Tasks;

namespace alphadinCore.Model
{
    public class UserJobModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int Status { get; set; }
        public UserModel user { get; set; }
        public string CompanyName { get; set; }
        public string JobTitle { get; set; }
        public int SalaryId { get; set; }
        public int CompanyScaleId { get; set; }
        public bool InProgress { get; set; }
    }
}
