namespace Services.ViewModels.TesterProfile
{
    public class UserJobViewModel
    {
        public int Id { get; }
        public string CompanyName { get; }
        public string JobTitle { get; }
        public int SalaryId { get; }
        public int CompanyScaleId { get; }
        public bool InProgress { get; }

        public UserJobViewModel(int id, string companyName, string jobTitle, int salaryId, int companyScaleId, bool inProgress)
        {
            Id = id;
            CompanyName = companyName;
            JobTitle = jobTitle;
            SalaryId = salaryId;
            CompanyScaleId = companyScaleId;
            InProgress = inProgress;
        }
    }
}