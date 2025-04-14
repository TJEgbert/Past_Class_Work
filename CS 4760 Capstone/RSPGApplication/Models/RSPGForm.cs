using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RSPGApplication.Models
{
    public class RSPGFormModel
    {
        [Key]
        public int RSPGFormId { get; set; } // Primary key

        //[Required(ErrorMessage = "User is required")]
        [ForeignKey("User")]
        [DisplayName("Submitted By")]
        public int UserId { get; set; } // Foreign key to User model
        public User? User { get; set; } // Navigation property to User

        [Required(ErrorMessage = "Project title is required")]
        [DisplayName("Project Title")]
        public string ProjectTitle { get; set; }

        [Required(ErrorMessage = "Project director is required")]
        [DisplayName("Project Director")]
        public string ProjectDirector { get; set; }

        //[Required(ErrorMessage = "College is required")]
        [ForeignKey("College")]
        [DisplayName("College")]
        public int CollegeId { get; set; } // Foreign key to College model
        public College? College { get; set; } // Navigation property to College

        //[Required(ErrorMessage = "Department is required")]
        [ForeignKey("Department")]
        [DisplayName("Department")]
        public int DepartmentId { get; set; } // Foreign key to Department model
        public Department? Department { get; set; } // Navigation property to Department

        [Required(ErrorMessage = "Mail code is required")]
        [DisplayName("Mail Code")]
        public string MailCode { get; set; }

        [Required(ErrorMessage = "Name of department chair is required")]
        [DisplayName("Department Chair Name")]
        public string DepartmentChairName { get; set; }

        [DisplayName("Dean Name")]
        public string? DeanName { get; set; }

        [DisplayName("Program Director Name")]
        public string? ProgramDirectorName { get; set; }

        [DisplayName("Other Participants (Names and Emails)")]
        public string? OtherParticipants { get; set; }

        // File Uploads
        [DisplayName("Uploaded Files")]
        public List<string>? UploadedFiles { get; set; } = new();

        // IRB Section
        [DisplayName("Will this require an animal or human subject?")]
        public bool RequiresIRB { get; set; }

        [DisplayName("IRB Form")]
        public string? IRBForm { get; set; }

        // Submission State
        [DisplayName("Submitted for Review")]
        public bool IsSubmitted { get; set; }

        // Approval Status
        public bool? ApprovalStatus { get; set; } // null = Pending, true = Approved, false = Rejected

        // ChairApproved Status
        public bool? ChairApproved { get; set; } // null = Pending, true = Approved, false = Rejected

        // Average Rating
        public int? AverageRating { get; set; } // null = No Ratings

        // Allocated Amount
        public double? AllocatedAmount { get; set; } // null = Not Allocated

        // The data the form is subbmitted
        public DateTime SubmissionDate { get; set;}

        // Name of the grant
        [Required(ErrorMessage = "Grant type is required")]
        public string? GrantType { get; set; }

        // The semester for the grant
        [Required(ErrorMessage = "Semester is required")]
        public string? Semester { get; set; }
    }
}
