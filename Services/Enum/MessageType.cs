using System.ComponentModel;

namespace Services.Enum
{
    public enum MessageType
    {
        [Description("خطای نامشخص رخ داده است")]
        None,

        [Description("داده درخواستی با موفقیت بازیابی شد")]
        SingleSuccess,

        [Description("داده های درخواستی با موفقیت بازیابی شد")]
        MultipleSuccess,

        [Description("داده درخواستی یافت نشد")]
        SingleNotFound,

        [Description("داده های درخواستی یافت نشد")]
        MultipleNotFound,

        [Description("دریافت داده درخواستی با خطا مواجه شد")]
        SingleError,

        [Description("دریافت داده های درخواستی با خطا مواجه شد")]
        MultipleError,

        [Description("درخواست با خطا مواجه شد")]
        Error,

        [Description("مشخصه های داده نامعتبر است")]
        InvalidData,

        [Description("درخواست با موفقیت انجام شد")]
        Success
    }
}