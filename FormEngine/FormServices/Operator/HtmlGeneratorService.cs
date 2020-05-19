using System.Linq;
using FormEngine.Services.Operator.Interface;
using HtmlElement = FormEngine.Services.Model.HtmlElement;

namespace FormEngine.Services.Operator
{
    public class HtmlGeneratorService : IHtmlGeneratorService
    {
        public string ToHtml(HtmlElement element)
        {
            var html = string.Empty;

            if (string.IsNullOrWhiteSpace(element.Tag))
            {
                element.Tag = "div";
                element.IsSingleTag = false;
            }

            html += $"<{element.Tag} ";

            if (!string.IsNullOrWhiteSpace(element.Id))
                html += $"id=\"{element.Id}\" ";

            if (!string.IsNullOrWhiteSpace(element.Name))
                html += $"name=\"{element.Name}\" ";

            if (!string.IsNullOrWhiteSpace(element.Class))
                html += $"class=\"{element.Class}\" ";

            if (element.Attributes.Any())
                for (var i = 0; i < element.Attributes.Count; i++)
                    html += $"\"{element.Attributes.Keys.ElementAt(i).Trim('"')}\"=\"{element.Attributes.Values.ElementAt(i).Trim('"')}\" ";

            html += "> ";

            if (element.IsSingleTag)
                return html;

            if (!string.IsNullOrWhiteSpace(element.Body))
                html += $"{element.Body} ";

            html += $"</{element.Tag}>";

            return html;
        }
    }
}