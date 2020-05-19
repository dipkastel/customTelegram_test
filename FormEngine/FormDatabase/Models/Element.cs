using System;
using System.Collections.Generic;
using FormEngine.Database.Common.Interface;

namespace FormEngine.Database.Models
{
    public class Element : Auditable
    {
        public Guid FormId { get; set; }
        public Form Form { get; set; }

        public Guid? ParentId { get; set; }
        public Element Parent { get; set; }

        public int Order { get; set; }
        public string Text { get; set; }
        public string CssClass { get; set; }

        public HtmlTag Tag { get; set; }
        public Guid TagId { get; set; }

        public ICollection<Element> Childs { get; set; }
        public ICollection<ElementAttribute> Attributes { get; set; }

    }
}