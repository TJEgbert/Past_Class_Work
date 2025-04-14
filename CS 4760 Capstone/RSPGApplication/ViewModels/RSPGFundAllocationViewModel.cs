using RSPGApplication.Models;

namespace RSPGApplication.ViewModels
{
    public class RSPGFundAllocationViewModel
    {
        public RSPGFormModel Form { get; set; }
        public double TotalRequested { get; set; }
        public double AvgRating { get; set; }
        public string UserName { get; set; }
        public string ProjectTitle { get; set; }
        public double TemporaryAllocatedAmount { get; set; } // This is NOT saved in the database



        public RSPGFundAllocationViewModel(RSPGFormModel form, double totalRequested, double avgRating, string userName, string projectTitle)
        {
            Form = form;
            TotalRequested = totalRequested;
            AvgRating = avgRating;
            UserName = userName;
            ProjectTitle = projectTitle;
            TemporaryAllocatedAmount = 0; // Default value
        }
    }
}
