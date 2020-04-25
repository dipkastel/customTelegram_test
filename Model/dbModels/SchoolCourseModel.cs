using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace alphadinCore.Model.dbModels
{
    public class SchoolCourseModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Title { get; set; }
        public int ReadTime { get; set; }
        public ICollection<SchoolQuizCourseModel> Questions { get; set; }
        public ICollection<SchoolUnitModel> Units { get; set; }
    }
}
