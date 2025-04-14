using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RSPGApplication.Models
{
    public class PersonalResources
    {
        [Key]
        public int PRId { get; set; }

        [ForeignKey("BudgetFormId")]
        public int BudgetFormId { get; set; }

        public bool IsStudent { get; set; }

        [Required(ErrorMessage = "Please insert a name")]
        public string Name { get; set; }
        
        public string? FundsFrom1 { get; set; }
        public double Total1 { get; set; } = 0;

        public string? FundsFrom2 { get; set; }
        public double Total2 { get; set; } = 0;

        public string? FundsFrom3 { get; set; }
        public double Total3 { get; set; } = 0;

        public int RSPGTotal { get; set; } = 0;


        public double GetTotalWithoutTax()
        {
            return (Total1 + Total2 + Total3 + RSPGTotal);
        }

        public double GetGrandTotal()
        {
            double sum = GetTotalWithoutTax();
            if (IsStudent)
            {
                sum += (sum * 0.22);
            }
            else
            {
                sum += (sum * 0.15);
            }
            return sum;
        }

        public double RPSGTaxTotal()
        {
            double sum = RSPGTotal;
            if (IsStudent)
            {
                sum += (sum * 0.22);
            }
            else
            {
                sum += (sum * 0.15);
            }
            return sum;

        }

        public double GetTax()
        {
            double sum = GetTotalWithoutTax();
            double tax;
            if (IsStudent)
            {
                tax = (sum * 0.22);
            }
            else
            {
                tax = (sum * 0.15);
            }

            return tax;
        }
    }
}
