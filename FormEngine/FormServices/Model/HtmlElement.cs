using System.Collections.Generic;

namespace FormEngine.Services.Model
{
    public class HtmlElement
    {
        public HtmlElement()
        {
            Tag = "div";
            IsSingleTag = false;
        }

        public HtmlElement(string tag, bool isSingleTag, string id, string name, string @class, IDictionary<string, string> attributes, string body)
        {
            Tag = tag;
            IsSingleTag = isSingleTag;
            Id = id;
            Name = name;
            Class = @class;
            Attributes = attributes;
            Body = body;
        }

        public string Tag { get; set; }
        public bool IsSingleTag { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
        public string Class { get; set; }
        public IDictionary<string, string> Attributes { get; set; }
        public string Body { get; set; }

    }
}