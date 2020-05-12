using System.Collections.Generic;
using FormEngine.Database.Common.Interface;
using FormEngine.Database.Models.Quiz;

namespace FormEngine.Database.Models
{
    public class Form : Auditable
    {
        public string Title { get; set; }
        public string Description { get; set; }







        public int IntroductionId { get; set; }
        public Introduction.Introduction Introduction { get; set; }

        public ICollection<Question> Questions { get; set; }

    }
}