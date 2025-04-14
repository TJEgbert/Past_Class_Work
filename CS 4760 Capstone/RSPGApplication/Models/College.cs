using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RSPGApplication.Models
{
    public class College
    {
        [Key]
        public int CollegeID { get; set; } // Primary key

        [Required(ErrorMessage = "College name is required")]
        [DisplayName("College Name")]
        public string Name { get; set; } // I beleive this should be a dropdown

        [Required(ErrorMessage = "Address is required")]
        public string Address { get; set; } // Entered manually?

        [DisplayName("Dean ID")]
        public int? DeanID { get; set; } // Nullable
    }
}
