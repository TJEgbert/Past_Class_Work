using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using MySqlConnector;
using RSPGApplication.Data;

namespace RSPGApplication.Models
{
    public class BudgetForm
    {
        [Key]
        public int BudgetFormId { get; set; } // Primary key

        public int RSPGFormID { get; set; }
    }
}
