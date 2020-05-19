using FormEngine.Services.Operator;
using FormEngine.Services.Operator.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace FormEngine.Services.IOC
{
    public class Di
    {
        public static void Config(IServiceCollection services)
        {
            services.AddTransient<IElementAttributeService, ElementAttributeService>();
            services.AddTransient<IElementService, ElementService>();
            services.AddTransient<IFormService, FormService>();
            services.AddTransient<IHtmlAttributeService, HtmlAttributeService>();
            services.AddTransient<IHtmlGeneratorService, HtmlGeneratorService>();
            services.AddTransient<IHtmlTagService, HtmlTagService>();
        }
    }
}