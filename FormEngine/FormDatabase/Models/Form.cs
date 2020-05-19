using System;
using System.Collections.Generic;
using FormEngine.Database.Common.Interface;

namespace FormEngine.Database.Models
{
    public class Form : Auditable
    {
        public string Title { get; set; }
        public string Description { get; set; }

        public string CssClass { get; set; }
        public string CustomCss { get; set; }

        public ICollection<Element> Elements { get; set; }

        /// <summary>
        /// Generated Html for cache
        /// </summary>
        public string Html { get; set; }

    }
}