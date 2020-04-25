using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace alphadinCore.Model.dbModels
{
    public class SchoolQuisQuestionOptionModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Option { get; set; }
        public bool IsCorrect { get; set; }
    }
}
