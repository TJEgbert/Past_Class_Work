using Microsoft.EntityFrameworkCore;
using RSPGApplication.Data;
using RSPGApplication.Models;

namespace RSPGApplication
{
    public class Program
    {
        // Switch to turn off cookies
        public static bool inDeveloperMode = false;

        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            string connectionString = "RSPGApplicationContext";

            builder.Services.AddDbContext<RSPGApplicationContext>(dbContextOptions =>
            dbContextOptions.UseMySql(builder.Configuration.GetConnectionString(connectionString), ServerVersion.AutoDetect(builder.Configuration.GetConnectionString(connectionString)))
                );

            // Add services to the container.
            builder.Services.AddRazorPages();
            builder.Services.AddHttpContextAccessor(); // to use IhttpContextAccessor

            builder.Services.AddDistributedMemoryCache();
            builder.Services.AddSession(options =>
            {
                options.Cookie.Name = ".User.Session";
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                SeedData.AddColleges(services);
                SeedData.AddDepartments(services);
                SeedData.AddUsers(services);
                SeedData.AddForms(services);
                SeedData.AddCriteria(services);
                SeedData.AddBudgetForms(services);
                SeedData.AddPersonalResources(services);
                SeedData.AddEquipmentResources(services);
                SeedData.AddTravelResources(services);
                SeedData.AddOtherResources(services);
                SeedData.AddRatings(services);
            }

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();
            app.UseSession();

            app.MapRazorPages();

            app.Run();
        }
    }
}
