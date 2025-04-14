using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RSPGApplication.Data;
using RSPGApplication.Models;
using RSPGApplication.Pages.RSPGFormRelated;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestsProject
{

    [TestClass]
    public class FundAllocationTests
    {
        private RSPGApplicationContext GetInMemoryContext()
        {
            var options = new DbContextOptionsBuilder<RSPGApplicationContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            return new RSPGApplicationContext(options);
        }

        [TestMethod]
        public async Task FundAllocation_OnGet_PopulatesFormWithTotal()
        {
            // Arrange
            var context = GetInMemoryContext();
            await context.Database.EnsureDeletedAsync();
            await context.Database.EnsureCreatedAsync();

            // Seed user
            var user = new RSPGApplication.Models.User
            {
                Id = 1,
                firstName = "Test",
                lastName = "User",
                email = "test@example.com",
                password = "123"
            };
            context.User.Add(user);

            // Seed form
            // Seed form
            var form = new RSPGFormModel
            {
                RSPGFormId = 1,
                UserId = 1,
                ProjectTitle = "Test Project",
                ChairApproved = true,
                ApprovalStatus = null,
                DepartmentChairName = "Chair",
                GrantType = "Internal",
                MailCode = "123",
                ProjectDirector = "Dr. Smith",
                Semester = "Spring 2025",
                SubmissionDate = DateTime.Now
            };

            context.RSPGForm.Add(form);

            // Seed budget form
            var budget = new BudgetForm
            {
                BudgetFormId = 1,
                RSPGFormID = 1
            };
            context.BudgetForm.Add(budget);

            await context.SaveChangesAsync();

            // Act
            var pageModel = new FundAllocationModel(context);
            var result = await pageModel.OnGet();

            // Assert
            Assert.IsInstanceOfType(result, typeof(PageResult));
            Assert.AreEqual(1, pageModel.FormWithTotal.Count);
            Assert.AreEqual("Test Project", pageModel.FormWithTotal[0].ProjectTitle);
        }
    }


}
