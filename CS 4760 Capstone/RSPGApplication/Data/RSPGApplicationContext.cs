using Microsoft.EntityFrameworkCore;
using RSPGApplication.Models;

namespace RSPGApplication.Data
{
    public class RSPGApplicationContext : DbContext
    {
        public RSPGApplicationContext(DbContextOptions<RSPGApplicationContext> options)
            : base(options)
        {
        }

        public DbSet<RSPGApplication.Models.User> User { get; set; } = default!;
        public DbSet<RSPGApplication.Models.College> College { get; set; } = default!;
        public DbSet<RSPGApplication.Models.Department> Department { get; set; } = default!;
        public DbSet<RSPGApplication.Models.RSPGFormModel> RSPGForm { get; set; } = default!;
        public DbSet<RSPGApplication.Models.PersonalResources> PersonalResources { get; set; } = default!;
        public DbSet<RSPGApplication.Models.BudgetForm> BudgetForm { get; set; } = default!;
        public DbSet<RSPGApplication.Models.Rating> Rating { get; set; } = default!;
        public DbSet<RSPGApplication.Models.Criteria> Criteria { get; set; } = default!;
        public DbSet<RSPGApplication.Models.EquipmentResource> EquipmentResource { get; set; } = default!;
        public DbSet<RSPGApplication.Models.TravelResource> TravelResource { get; set; } = default!;
        public DbSet<RSPGApplication.Models.OtherResource> OtherResource { get; set; } = default!;
        public DbSet<RSPGApplication.Models.RSPGSummaryFinalReport> RSPGSummaryFinalReport { get; set; } = default!;

    }
}
