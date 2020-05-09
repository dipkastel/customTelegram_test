namespace Services.ViewModels.TesterProfile
{
    public class UserEducationViewModel
    {
        public int Id { get; }
        public int Grade { get; }
        public string Major { get; }
        public string place { get; }
        public bool InProgress { get; }

        public UserEducationViewModel(int id, int grade, string major, string place, bool inProgress)
        {
            Id = id;
            Grade = grade;
            Major = major;
            this.place = place;
            InProgress = inProgress;
        }
    }
}