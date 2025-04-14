using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RSPGApplication.Data;
using RSPGApplication.Models;
using RSPGApplication.Pages.RSPGFormRelated;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Microsoft.ApplicationInsights.MetricDimensionNames.TelemetryContext;

namespace UnitTestsProject
{
    [TestClass]
    public class UnitTestsProject
    {
        private RSPGApplicationContext GetInMemoryContext()
        {
            var options = new DbContextOptionsBuilder<RSPGApplicationContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            return new RSPGApplicationContext(options);
        }

        [TestMethod]
        public async Task RSPGForm_Creation()
        {
            // Arrange
            var context = GetInMemoryContext();
            await context.Database.EnsureDeletedAsync();
            await context.Database.EnsureCreatedAsync();

            // Seed related data
            context.College.Add(new College
            {
                CollegeID = 1,
                Name = "Engineering",
                Address = "123 College Ave"
            });

            context.Department.Add(new Department
            {
                DeptID = 1,
                Name = "CS",
                Address = "456 Dept Rd",
                CollegeID = 1
            });

            context.User.Add(new RSPGApplication.Models.User
            {
                Id = 1,
                email = "test@user.com",
                password = "test123",
                firstName = "Test",
                lastName = "User",
                CollegeId = 1,
                DepartmentId = 1
            });

            await context.SaveChangesAsync();

            // Act
            var form = new RSPGFormModel
            {
                UserId = 1,
                ProjectTitle = "Test Project",
                ProjectDirector = "Test User",
                CollegeId = 1,
                DepartmentId = 1,
                MailCode = "12345",
                DepartmentChairName = "Chair Name",
                DeanName = "Dean Name",
                ProgramDirectorName = "PD Name",
                OtherParticipants = "Alice, Bob",
                RequiresIRB = false,
                IsSubmitted = true,
                GrantType = "Internal",
                Semester = "Spring 2025",
                SubmissionDate = DateTime.Now,
                UploadedFiles = new List<string> { "file1.pdf", "file2.pdf" }
            };

            context.RSPGForm.Add(form);
            await context.SaveChangesAsync();

            // Assert
            var savedForm = await context.RSPGForm.FirstOrDefaultAsync(f => f.ProjectTitle == "Test Project");
            Assert.IsNotNull(savedForm);
            Assert.AreEqual("Test User", savedForm.ProjectDirector);
            Assert.AreEqual("Chair Name", savedForm.DepartmentChairName);
            Assert.IsTrue(savedForm.IsSubmitted);
        }
    }
}