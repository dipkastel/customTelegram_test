using System.Collections.Generic;
using FormEngine.Database.Common.Interface;

namespace FormEngine.Database.Models.Quiz
{
    public class Question : Auditable
    {
        public string Text { get; set; }
        public int Number { get; set; }


        public int FormId { get; set; }
        public Form Form { get; set; }

        public ICollection<SubQuestion> SubQuestions { get; set; }
    }
}