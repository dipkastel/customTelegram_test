using FormEngine.DatabaseValidation.Operator;
using FormEngine.DatabaseValidation.Operator.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace FormEngine.DatabaseValidation.IOC
{
    public class Di
    {
        public static void Config(IServiceCollection services)
        {
            services.AddTransient<IElementAttributeValidation, ElementAttributeValidation>();
            services.AddTransient<IElementValidation, ElementValidation>();
            services.AddTransient<IFormValidation, FormValidation>();
            services.AddTransient<IHtmlAttributeValidation, HtmlAttributeValidation>();
            services.AddTransient<IHtmlTagValidation, HtmlTagValidation>();
        }
    }
}