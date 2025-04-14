using RSPGApplication.Models;
using Microsoft.EntityFrameworkCore;
using RSPGApplication.Data;
using RSPGApplication.Pages.BudgetFormContents;
using RSPGApplication.Pages.CriteriaRelated;
using Microsoft.AspNetCore.Mvc;


namespace UnitTestsProject
{
    [TestClass]
    public class CreateCriteriaTest
    {
        /// <summary>
        /// Creates a temporary database for this test
        /// </summary>
        /// <returns></returns>
        private RSPGApplicationContext GetInMemoryContext()
        {
            var options = new DbContextOptionsBuilder<RSPGApplicationContext>()
                .UseInMemoryDatabase(databaseName: "CriteriaTest")
                .Options;

            return new RSPGApplicationContext(options);
        }


        [TestMethod]
        public async Task Criteria_Creation()
        {
            // Gets the database and clears it
            var context = GetInMemoryContext();
            await context.Database.EnsureDeletedAsync();
            await context.Database.EnsureCreatedAsync();

            //Set up page model now
            var pageModel = new AdminCreateCriteriaModel(context);

            //Create a cample Criteria to simulate form input
            var criteria = new Criteria
            {
                CriteriaSection = "Area one",
                CriteriaTitle = "Test Criteria",
                Weight = 5,
                RatingZero = "Test Zero",
                RatingOne = "Test One",
                RatingTwo = "Test Two"
            };

            pageModel.Criteria = criteria;

            var result = await pageModel.OnPostAsync();

            // Make sure it redirects
            Assert.IsInstanceOfType(result, typeof(RedirectToPageResult));

            // Verify that the Criteria object was added to the database
            var dbCriteria = await context.Criteria.FirstOrDefaultAsync(c => c.CriteriaTitle == "Test Criteria");
            Assert.IsNotNull(dbCriteria);
            Assert.AreEqual("Area one", dbCriteria.CriteriaSection);
            Assert.AreEqual(5, dbCriteria.Weight);
            Assert.AreEqual("Test Zero", dbCriteria.RatingZero);
            Assert.AreEqual("Test One", dbCriteria.RatingOne);
            Assert.AreEqual("Test Two", dbCriteria.RatingTwo);
        }

    }
}
