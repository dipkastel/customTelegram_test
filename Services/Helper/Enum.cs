using System.ComponentModel;

namespace Services.Helper
{
    public static class Enum
    {
        public static string Description(this System.Enum x)
        {
            var type = x.GetType();
            var memberInfos = type.GetMember(x.ToString());
            var attributes = memberInfos[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
            var description = ((DescriptionAttribute)attributes[0]).Description ?? string.Empty;
            return description;
        }
    }
}