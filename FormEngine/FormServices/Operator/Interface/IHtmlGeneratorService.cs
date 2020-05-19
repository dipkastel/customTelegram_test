using HtmlElement = FormEngine.Services.Model.HtmlElement;

namespace FormEngine.Services.Operator.Interface
{
    public interface IHtmlGeneratorService
    {
        string ToHtml(HtmlElement element);
    }
}