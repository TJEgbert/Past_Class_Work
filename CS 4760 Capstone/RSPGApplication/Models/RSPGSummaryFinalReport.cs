using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace RSPGApplication.Models
{
    public class RSPGSummaryFinalReport
    {
        [Key]
        public int ReportId { get; set; } // Primary key

        // Foreign key linking to the user who submitted the report
        [ForeignKey("User")]
        [DisplayName("Submitted By")]
        public int UserId { get; set; }
        public User? User { get; set; } // Navigation property

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress]
        [DisplayName("Email *")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Project Director is required")]
        [DisplayName("Project Director *")]
        public string ProjectDirector { get; set; }

        [Required(ErrorMessage = "Project Title is required")]
        [DisplayName("Project Title *")]
        public string ProjectTitle { get; set; }

        [DisplayName("Other Participants")]
        public string? OtherParticipants { get; set; }

        [Required(ErrorMessage = "Award Date is required")]
        [DataType(DataType.Date)]
        [DisplayName("Award Date *")]
        public DateTime? AwardDate { get; set; }

        [Required(ErrorMessage = "Completion Date is required")]
        [DataType(DataType.Date)]
        [DisplayName("Completion Date *")]
        public DateTime? CompletionDate { get; set; }

        [Required(ErrorMessage = "Amount of RSPG Award is required")]
        [Column(TypeName = "decimal(18,2)")]
        [Range(0, double.MaxValue, ErrorMessage = "Amount must be a positive number")]
        [DisplayName("Amount of RSPG Award *")]
        public decimal? AwardAmount { get; set; }

        [Required(ErrorMessage = "Amount of RSPG Award Spent is required")]
        [Column(TypeName = "decimal(18,2)")]
        [Range(0, double.MaxValue, ErrorMessage = "Amount must be a positive number")]
        [DisplayName("Amount of RSPG Award Spent *")]
        public decimal? AmountSpent { get; set; }

        [Required(ErrorMessage = "Type of Proposal is required")]
        [DisplayName("Type of Proposal *")]
        public string ProposalType { get; set; }

        [DisplayName("Purpose of Project")]
        public string? PurposeOfProject { get; set; }

        [DisplayName("Project Outcomes")]
        public string? ProjectOutcomes { get; set; }

        [DisplayName("Evaluation and Dissemination Outcomes")]
        public string? EvaluationDissemination { get; set; }

        // File Uploads
        [DisplayName("Uploaded Appendices (PDF)")]
        public List<string>? AppendicesFilePaths { get; set; } = new();
    }
}
