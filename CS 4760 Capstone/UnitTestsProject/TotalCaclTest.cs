using Microsoft.EntityFrameworkCore;
using RSPGApplication.Data;
using RSPGApplication.HelperClasses;
using RSPGApplication.Models;

namespace UnitTestsProject
{
    [TestClass]
    public class TotalCaclTest
    {
        /// <summary>
        /// Creates a temporary database for this test
        /// </summary>
        /// <returns></returns>
        private RSPGApplicationContext GetInMemoryContext()
        {
            var options = new DbContextOptionsBuilder<RSPGApplicationContext>()
                .UseInMemoryDatabase(databaseName: "CaclTest")
                .Options;

            return new RSPGApplicationContext(options);
        }


        [TestMethod]
        public async Task TotalCacl_Test()
        {
            // Gets the database and clears it
            var context = GetInMemoryContext();
            await context.Database.EnsureDeletedAsync();
            await context.Database.EnsureCreatedAsync();

            // Adds needed data contents
            context.User.AddRange(
                new User
                {
                    email = "admin@mail.com",
                    password = "123",
                    firstName = "Wade",
                    lastName = "Wilson",
                    CollegeId = 1,
                    DepartmentId = 1,
                    position = "Admin",
                    RSPGMember = true,
                    isAdmin = true,
                    isRSPGChair = false,
                    isDean = false,
                    isDepChair = false,
                },
                new User
                {
                    email = "Dean1@mail.com",
                    password = "123",
                    firstName = "Mad",
                    lastName = "Max",
                    CollegeId = 1,
                    DepartmentId = 1,
                    position = "Dean",
                    RSPGMember = true,
                    isAdmin = false,
                    isRSPGChair = false,
                    isDean = true,
                    isDepChair = false,
                },
                new User
                {
                    email = "Dean2@mail.com",
                    password = "123",
                    firstName = "Sad",
                    lastName = "Max",
                    CollegeId = 2,
                    DepartmentId = 3,
                    position = "Dean",
                    RSPGMember = true,
                    isAdmin = false,
                    isRSPGChair = false,
                    isDean = true,
                    isDepChair = false,
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
                    ProjectTitle = "Test Project 3",
                    ProjectDirector = "Jean Grey",
                    CollegeId = 1,
                    DepartmentId = 1,
                    MailCode = "code 1234",
                    DepartmentChairName = "Jacques McKeown",
                    DeanName = "Peter Parker",
                    ProgramDirectorName = "Ryland Grace",
                    OtherParticipants = "None",
                    UploadedFiles = ["form1.txt", "form2.txt"],
                    RequiresIRB = true,
                    IRBForm = "requiredForm.txt",
                    IsSubmitted = false,
                    Semester = "Spring",
                    GrantType = "Research"
                });

            context.SaveChanges();

            context.BudgetForm.Add(
                new BudgetForm
                {
                    RSPGFormID = 1
                });
            context.SaveChanges();

            context.PersonalResources.AddRange(
                new PersonalResources
                {
                    BudgetFormId = 1,
                    IsStudent = true,
                    Name = "James",
                    FundsFrom1 = "Computer Science Dept.",
                    Total1 = 2500,
                    RSPGTotal = 2500
                },
                new PersonalResources
                {
                    BudgetFormId = 1,
                    IsStudent = false,
                    Name = "Jane",
                    FundsFrom1 = "Computer Science Dept.",
                    Total1 = 2500,
                    RSPGTotal = 2500
                });

            context.EquipmentResource.AddRange(
                new EquipmentResource
                {
                    BudgetFormId = 1,
                    Name = "Computer Parts",
                    FundsFrom1 = "Computer Science Dept.",
                    Total1 = 1000,
                    RSPGTotal = 1000
                },
                new EquipmentResource
                {
                    BudgetFormId = 1,
                    Name = "3D Printer",
                    FundsFrom1 = "College of E.A.S.T",
                    Total1 = 2500,
                    FundsFrom2 = "Computer Science Dept.",
                    Total2 = 1000,
                    RSPGTotal = 2500
                });

            context.TravelResource.AddRange(
                new TravelResource
                {
                    BudgetFormId = 1,
                    Name = "Rental Car",
                    FundsFrom1 = "Computer Science Dept.",
                    Total1 = 500,
                    RSPGTotal = 500
                },
                new TravelResource
                {
                    BudgetFormId = 1,
                    Name = "Flights",
                    FundsFrom1 = "College of E.A.S.T",
                    Total1 = 1500,
                    FundsFrom2 = "Computer Science Dept.",
                    Total2 = 1500,
                    RSPGTotal = 1000
                });
            context.OtherResource.AddRange(
                new OtherResource
                {
                    BudgetFormId = 1,
                    Name = "James",
                    FundsFrom1 = "Computer Science Dept.",
                    Total1 = 2500,
                    RSPGTotal = 2500
                },
                new OtherResource
                {
                    BudgetFormId = 1,
                    Name = "Jane",
                    FundsFrom1 = "Computer Science Dept.",
                    Total1 = 2500,
                    RSPGTotal = 2500
                });
            context.SaveChanges();

            // Creates the totalCalc
            TotalsCalc calculator = new TotalsCalc(context);

            // Calculates the totals for RSPG and the grand total for each resource
            CardTotals PRTotals = calculator.CalcprTotals(1);
            CardTotals ERTotals = calculator.CalcErTotals(1);
            CardTotals TRTotals = calculator.CalcTrTotals(1);
            CardTotals ORTotals = calculator.CalcOrTotals(1);

            // Gets the RSPG grand total for resources
            double RSPGTotal = await calculator.GetRSPGTotalAsync(1);

            // Verifies totals match up
            Assert.AreEqual(PRTotals.RSPGTotal, "$5,925.00");
            Assert.AreEqual(PRTotals.Total, "$11,850.00");

            Assert.AreEqual(ERTotals.RSPGTotal, "$3,500.00");
            Assert.AreEqual(ERTotals.Total, "$8,000.00");

            Assert.AreEqual(TRTotals.RSPGTotal, "$1,500.00");
            Assert.AreEqual(TRTotals.Total, "$5,000.00");

            Assert.AreEqual(ORTotals.RSPGTotal, "$5,000.00");
            Assert.AreEqual(ORTotals.Total, "$10,000.00");

            Assert.AreEqual(RSPGTotal, 15925);
        }

    }
}

