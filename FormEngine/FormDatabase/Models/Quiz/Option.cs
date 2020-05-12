using FormEngine.Database.Common.Interface;

namespace FormEngine.Database.Models.Quiz
{
    public class Option : Auditable
    {
        public string Text { get; set; }
        public string Placeholder { get; set; }
        public string CustomCss { get; set; }



        public int SubQuestionId { get; set; }
        public SubQuestion SubQuestion { get; set; }

        public int OptionTypeId { get; set; }
        public OptionType OptionType { get; set; }
    }
}