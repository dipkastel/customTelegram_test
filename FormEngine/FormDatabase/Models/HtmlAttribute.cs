using System.Collections.Generic;
using FormEngine.Database.Common.Interface;

namespace FormEngine.Database.Models
{
    public class HtmlAttribute : Auditable
    {
        public string Name { get; set; }

        public ICollection<ElementAttribute> ElementAttributes { get; set; }
    }
}