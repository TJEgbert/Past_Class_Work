using Microsoft.Identity.Client;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace RSPGApplication.Models
{
    public class Rating
    {
        [Key]
        public int RatingId { get; set; }
        //[Required(ErrorMessage = "User is required")]
        [ForeignKey("User")]
        [DisplayName("Submitted By")]
        public int UserId { get; set; } // Foreign key to User model
        public User? User { get; set; } // Navigation property to User
        [ForeignKey("RSPGForm")]
        [DisplayName("Form Rated")]
        public int RSPGFormId { get; set; }
        public RSPGFormModel? RSPGForm { get; set; }
        [Required(ErrorMessage = "Rating is required")]
        [Range(0, 100, ErrorMessage = "Rating must be between 0 and 100.")]
        [DisplayName("RSPG Form Rating")]
        public double RSPGRating { get; set; }
    }
}
