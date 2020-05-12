using FormEngine.Database.Common.Interface;

namespace FormEngine.Database.Models.Introduction
{
    public class Introduction : Auditable
    {
        public string Body { get; set; }
        public string CustomCss { get; set; }
        
        public int FormId { get; set; }
        public Form Form { get; set; }
    }
}