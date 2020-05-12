using System.Collections.Generic;
using FormEngine.Database.Common.Interface;

namespace FormEngine.Database.Models.Quiz
{
    public class OptionType : Auditable
    {
        public string Title  { get; set; }
        public string HtmlBody  { get; set; }


        public ICollection<Option> Option { get; set; }
    }
}