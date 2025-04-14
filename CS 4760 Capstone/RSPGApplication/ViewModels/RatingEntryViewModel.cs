using RSPGApplication.Models;

namespace RSPGApplication.ViewModels
{
    public class RatingEntryViewModel
    {
        public RSPGFormModel Form { get; set; }
        public string UserName { get; set; }
        public string ProjectTitle { get; set; }
        public string TotalRequested { get; set; }
        public double currentRating { get; set; }

        public RatingEntryViewModel(RSPGFormModel form, string userName, string projectTitle, string totalRequested, double currentRating)
        {
            Form = form;
            UserName = userName;
            ProjectTitle = projectTitle;
            TotalRequested = totalRequested;
            this.currentRating = currentRating;
        }
    }
}
