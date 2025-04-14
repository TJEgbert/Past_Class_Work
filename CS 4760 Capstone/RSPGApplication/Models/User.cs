using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RSPGApplication.Models
{
    public class User
    {   
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Email name is required")]
        [DisplayName("Email")]
        public string email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DisplayName("Password")]
        public string password { get; set; }

        [Compare(nameof(password), ErrorMessage = "Passwords don't match")]
        public string? confirmPassword { get; set; }

        [Required(ErrorMessage = "First name is required")]
        [DisplayName("First Name")]
        public string firstName { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        [DisplayName("Last Name")]
        public string lastName { get; set; }

        //[Required(ErrorMessage = "College is required")]
        [ForeignKey("College")]
        [DisplayName("College")]
        public int? CollegeId { get; set; } // Foreign key to College model
        public College? College { get; set; } // Navigation property to College

        //[Required(ErrorMessage = "Department is required")]
        [ForeignKey("Department")]
        [DisplayName("Department")]
        public int? DepartmentId { get; set; } // Foreign key to Department model
        public Department? Department { get; set; } // Navigation property to Department

        public string? position { get; set; }

        public bool RSPGMember { get; set; } // True means they are a member

        public bool? isAdmin { get; set; } // True means they are an admin

        public bool? isRSPGChair { get; set; } // True means they are the RSPG Chair 

        public bool? isDean { get; set; } // True means they are the College Dean, one per college

        public bool? isDepChair { get; set; } // True means they are the department chair, one per department
    }
}
