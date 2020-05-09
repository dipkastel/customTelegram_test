namespace Services.ViewModels.TesterProfile
{
    public class UserLanguesViewModel
    {
        public int Id { get; }
        public int LanguageId { get; }
        public int ReadingRate { get; }
        public int WritingRate { get; }
        public int SpeakingRate { get; }

        public UserLanguesViewModel(int id, int languageId, int readingRate, int writingRate, int speakingRate)
        {
            Id = id;
            LanguageId = languageId;
            ReadingRate = readingRate;
            WritingRate = writingRate;
            SpeakingRate = speakingRate;
        }
    }
}