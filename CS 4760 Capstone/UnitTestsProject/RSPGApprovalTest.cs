using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RSPGApplication.Data;
using RSPGApplication.HelperClasses;
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
    public class RSPGApprovalTest
    {
        // This is making a RSPG Form and then approving the project to see if a project gets approved
        private RSPGApplicationContext GetInMemoryContext()
        {
            var options = new DbContextOptionsBuilder<RSPGApplicationContext>()
                .UseInMemoryDatabase(databaseName: "RSPGApprovalTest")
                .Options;

            return new RSPGApplicationContext(options);
        }

        [TestMethod]
        public async Task RSPGApproval_Test()
        {
            var context = GetInMemoryContext();
            await context.Database.EnsureDeletedAsync();
            await context.Database.EnsureCreatedAsync();


            context.User.AddRange(
                new User
                {
                    email = "ApproveTest@mail.com",
                    password = "123",
                    firstName = "Approve",
                    lastName = "Test",
                    CollegeId = 1,
                    DepartmentId = 1,
                    position = "Admin",
                    RSPGMember = true,
                    isAdmin = true,
                    isRSPGChair = true,
                    isDean = true,
                    isDepChair = true,
                });
            context.SaveChanges();

            context.College.Add(
                new College
                {
                    Name = "College of E.A.S.T",
                    Address = "123 street",
                    DeanID = 1
                });
            context.SaveChanges();

            context.Department.Add(
                new Department
                {
                    Name = "Computer Science",
                    Address = "123 street",
                    CollegeID = 1,
                    ChairID = 1
                });
            context.SaveChanges();

            context.RSPGForm.Add(
                new RSPGFormModel
                {
                    UserId = 1,
                    ProjectTitle = "Science Stuff",
                    ProjectDirector = "Toby",
                    CollegeId = 1,
                    DepartmentId = 1,
                    MailCode = "12345",
                    DepartmentChairName = "Johnny",
                    DeanName = "Bill",
                    ProgramDirectorName = "Andy",
                    OtherParticipants = "None",
                    UploadedFiles = ["form1.txt"],
                    RequiresIRB = false,
                    IsSubmitted = true,
                    Semester = "Summer",
                    GrantType = "Travel"
                });
            context.SaveChanges();

            context.BudgetForm.Add(
                new BudgetForm
                {
                    RSPGFormID = 1
                });
            context.SaveChanges();

            context.TravelResource.AddRange(
                new TravelResource
                {
                    BudgetFormId = 1,
                    Name = "None",
                    FundsFrom1 = "None",
                    Total1 = 0,
                    RSPGTotal = 0
                });
            context.SaveChanges();


            var rspgform = context.RSPGForm.FirstOrDefault(f => f.RSPGFormId == 1);
            if (rspgform != null)
            {
                rspgform.ApprovalStatus = true;
                context.SaveChanges();
            }



            Assert.AreEqual(rspgform.UserId, 1);
            Assert.AreEqual(rspgform.ProjectTitle, "Science Stuff");
            Assert.AreEqual(rspgform.CollegeId, 1);
            Assert.AreEqual(rspgform.DepartmentId, 1);
            Assert.AreEqual(rspgform.GrantType, "Travel");
            Assert.AreEqual(rspgform.Semester, "Summer");
            Assert.AreEqual(rspgform.ApprovalStatus, true);

        }
    }
}
