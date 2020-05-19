using System;
using System.Linq;
using FormEngine.Database.Config;
using FormEngine.Database.Models;
using FormEngine.DatabaseValidation.Operator.Interface;
using FormEngine.Services.Operator.Interface;
using FormEngine.Services.Structure;

namespace FormEngine.Services.Operator
{
    public class ElementService : GenericRepository<Element>, IElementService
    {
        private readonly IHtmlGeneratorService _htmlGeneratorService;
        private readonly IElementAttributeService _attributeService;

        public ElementService(FormEngineDbContext context, IElementValidation validation, IHtmlGeneratorService htmlGeneratorService, IElementAttributeService attributeService) : base(context, validation)
        {
            _htmlGeneratorService = htmlGeneratorService;
            _attributeService = attributeService;
        }

        public string GetElementHtml(Guid formId)
        {
            var body = string.Empty;

            var childs = GetChilds(formId);

            if (childs.Any())
            {
                foreach (var child in childs)
                {
                    body += GetElementHtml(child.Id);
                }
            }

            var element = Get(formId).Data;

            var html = GetHtmlElement(element, body);

            return html;
        }

        private string GetHtmlElement(Element element, string body)
        {

            var htmlTag = GetHtmlTag(element.Id);

            var htmlName = GetHtmlName(element);

            var attributes = _attributeService.GetHtmlAttribute(element.Id);

            var elememt = new Model.HtmlElement()
            {
                Tag = htmlTag.Name,
                IsSingleTag = htmlTag.IsSingleTag,
                Id = element.Id.ToString(),
                Name = htmlName,
                Body = body,
                Attributes = attributes,
                Class = element.CssClass
            };

            var html = _htmlGeneratorService.ToHtml(elememt);
            return html;
        }

        private IQueryable<Element> GetChilds(Guid elementId)
        {
            var childs = FindBy(q => q.ParentId == elementId).Data;

            if (childs.Count() <= 1)
                return childs;

            var sortByOrder = true;

            foreach (var child in childs)
            {
                var count = 0;

                if (child.Order <= 0)
                    count++;

                if (count < 2)
                    continue;

                sortByOrder = false;
                break;
            }

            childs = sortByOrder ? childs.OrderBy(q => q.Order) : childs.OrderBy(q => q.CreatedOn);

            return childs;
        }

        private static string GetHtmlName(Element element)
        {
            var quizName = element.ParentId.HasValue ? element.ParentId.Value.ToString() : string.Empty;
            return quizName;
        }

        private HtmlTag GetHtmlTag(Guid elementId)
        {
            var quizTag = GetAllIncluding(e => e.Tag)
                .FirstOrDefault(e => e.Id == elementId)
                ?.Tag;

            quizTag = quizTag ?? new HtmlTag() { IsSingleTag = false, Name = "div" };
            return quizTag;
        }

    }
}