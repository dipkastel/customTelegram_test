using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace alphadinCore.Model.dbModels
{
    public class SchoolQuizQuestionModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int Type { get; set; }
        public string Question { get; set; }
        public string CorrectAnswer { get; set; }
        public ICollection<SchoolQuisQuestionOptionModel> Options { get; set; }

    }

    public enum SchoolQuizQuestionTypes {
    MultipleChoice = 0
    }
}
