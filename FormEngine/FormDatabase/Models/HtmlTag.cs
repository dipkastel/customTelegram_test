using System.Collections.Generic;
using FormEngine.Database.Common.Interface;

namespace FormEngine.Database.Models
{
    public class HtmlTag : Auditable
    {
        public string Name { get; set; }
        public bool IsSingleTag { get; set; }

        public ICollection<Element> Elements { get; set; }
    }
}