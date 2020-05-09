namespace Services.ViewModels.TesterProfile
{
    public class UserFavoriteViewModel
    {
        public int Id { get; }
        public int TagId { get; }
        public string Category { get; }

        public UserFavoriteViewModel(int id, int tagId, string category)
        {
            Id = id;
            TagId = tagId;
            Category = category;
        }
    }
}