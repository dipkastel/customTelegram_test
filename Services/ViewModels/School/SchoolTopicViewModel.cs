namespace Services.ViewModels.School
{
    public class SchoolTopicViewModel
    {
        public string ImageUrl { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }


        public SchoolTopicViewModel(string imageUrl, string title, string description)
        {
            ImageUrl = imageUrl;
            Title = title;
            Description = description;
        }
    }
}