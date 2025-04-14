using RSPGApplication.Models;
using Microsoft.EntityFrameworkCore;
using RSPGApplication.Data;
using RSPGApplication.Pages.BudgetFormContents;


namespace UnitTestsProject
{
    [TestClass]
    public class BudgetFormResourceCreationTest
    {
        /// <summary>
        /// Creates a temporary database for this test
        /// </summary>
        /// <returns></returns>
        private RSPGApplicationContext GetInMemoryContext()
        {
            var options = new DbContextOptionsBuilder<RSPGApplicationContext>()
                .UseInMemoryDatabase(databaseName: "BudgetTest")
                .Options;

            return new RSPGApplicationContext(options);
        }


        [TestMethod]
        public async Task BudgetForm_Creation_With_Resources()
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

            // Creates list of resources to add to the database
            List<PersonalResources> addedPersonalResources = [
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
                }];

            List<EquipmentResource> addedEquipmentResources = [
                new EquipmentResource
                {
                    BudgetFormId = 1,
                    Name = "James",
                    FundsFrom1 = "Computer Science Dept.",
                    Total1 = 2500,
                    RSPGTotal = 2500
                },
                new EquipmentResource
                {
                    BudgetFormId = 1,
                    Name = "Jane",
                    FundsFrom1 = "Computer Science Dept.",
                    Total1 = 2500,
                    RSPGTotal = 2500
                }];

            List<TravelResource> addedTravelResources = [
                new TravelResource
                {
                    BudgetFormId = 1,
                    Name = "James",
                    FundsFrom1 = "Computer Science Dept.",
                    Total1 = 2500,
                    RSPGTotal = 2500
                },
                new TravelResource
                {
                    BudgetFormId = 1,
                    Name = "Jane",
                    FundsFrom1 = "Computer Science Dept.",
                    Total1 = 2500,
                    RSPGTotal = 2500
                }];

            List<OtherResource> addedOtherResources = [
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
                }];

            // Sets up the backend of the pages
            PersonalResourcesModel personalResourcePage = new PersonalResourcesModel(context);
            EquipmentResourceModel equipmentResourcePage = new EquipmentResourceModel(context);
            TravelResourceModel travelResourcePage = new TravelResourceModel(context);
            OtherResourceModel otherResoucePage = new OtherResourceModel(context);
            
            // Calls the function to update the database
            await personalResourcePage.UpdateDatabaseAsync(1, addedPersonalResources);
            await equipmentResourcePage.UpdateDatabaseAsync(1, addedEquipmentResources);
            await travelResourcePage.UpdateDatabaseAsync(1, addedTravelResources);
            await otherResoucePage.UpdateDatabaseAsync(1, addedOtherResources);

            // Get resources data from the database
            List<PersonalResources> PResources = await context.PersonalResources.Where(r => r.BudgetFormId == 1).ToListAsync();
            List<EquipmentResource> EResources = await context.EquipmentResource.Where(r => r.BudgetFormId == 1).ToListAsync();
            List<TravelResource> TResources = await context.TravelResource.Where(r => r.BudgetFormId == 1).ToListAsync();
            List<OtherResource> OResources = await context.OtherResource.Where(r => r.BudgetFormId == 1).ToListAsync();

            // Checks if the number of resources match for each resource type
            Assert.AreEqual(2, PResources.Count);
            Assert.AreEqual(2, EResources.Count);
            Assert.AreEqual(2, TResources.Count);
            Assert.AreEqual(2, OResources.Count);

        }

    }
}
