using System;
using FormEngine.Database.Common.Interface;

namespace FormEngine.Database.Models
{
    public class ElementAttribute : Auditable
    {
        public Guid ElementId { get; set; }
        public Element Element { get; set; }

        public string Value { get; set; }

        public Guid AttributeId { get; set; }
        public HtmlAttribute Attribute { get; set; }
    }
}