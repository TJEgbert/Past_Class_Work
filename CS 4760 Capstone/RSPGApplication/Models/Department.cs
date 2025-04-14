using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RSPGApplication.Models
{
    public class Department
    {
        [Key]
        public int DeptID { get; set; } // Primary key

        [Required(ErrorMessage = "Department name is required")]
        [DisplayName("Department Name")]
        public string Name { get; set; } // I beleive this should be a dropdown

        [Required(ErrorMessage = "Address is required")]
        public string Address { get; set; } // Entered manually?

        [Required]
        [ForeignKey("College")]
        public int CollegeID { get; set; } // Foreign key for college

        public College College { get; set; } 

        [DisplayName("Chair ID")]
        public int? ChairID { get; set; } // Nullable
    }
}
