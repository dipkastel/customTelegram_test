using System.ComponentModel;

namespace FormEngine.Services.Common
{
    public enum HtmlTag
    {
        UnAssigned = 0,

        [Description("Html")]
        Html,

        [Description("Head")]
        Head,

        [Description("Title")]
        Title,

        [Description("Body")]
        Body,

        [Description("Div")]
        Div,

        [Description("iframe")]
        Iframe,

        #region Form

        [Description("Input")]
        Input,

        [Description("Button")]
        Button,
        
        [Description("Submit")]
        Submit,

        [Description("select")]
        Select,
        
        [Description("option")]
        Option,

        #endregion

        #region Text

        [Description("h1")]
        H1,
        
        [Description("h2")]
        H2,
        
        [Description("h3")]
        H3,
        
        [Description("h4")]
        H4,
        
        [Description("h5")]
        H5,
        
        [Description("h6")]
        H6,
        
        [Description("p")]
        P,
        
        [Description("a")]
        A,
        
        [Description("img")]
        Img,
        
        [Description("ul")]
        Ul,
        
        [Description("ol")]
        Ol,
        
        [Description("li")]
        Li,
        
        [Description("br")]
        Br,
        
        [Description("hr")]
        Hr,
        
        [Description("pre")]
        Pre,
        
        [Description("b")]
        B,
        
        [Description("strong")]
        Strong,
        
        [Description("i")]
        I,
        
        [Description("em")]
        Em,
        
        [Description("del")]
        Deleted,

        [Description("article")]
        Article,

        #endregion

    }
}