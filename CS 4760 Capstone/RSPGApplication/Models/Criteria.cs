using Microsoft.Identity.Client;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace RSPGApplication.Models
{
    public class Criteria
    {
        [Key]
        public int CriteriaId { get; set; }
        [Required(ErrorMessage = "Please Select an Area.")]
        [DisplayName("Criteria Section")]
        public string CriteriaSection { get; set; }
        [Required]
        [DisplayName("Criteria")]
        public string CriteriaTitle { get; set; }
        [Required]
        [DisplayName("Weight")]
        public int Weight { get; set; }
        [Required]
        [DisplayName("0")]
        public string RatingZero { get; set; }
        [Required]
        [DisplayName("1")]
        public string RatingOne { get; set; }
        [Required]
        [DisplayName("2")]
        public string RatingTwo { get; set; }
    }
}