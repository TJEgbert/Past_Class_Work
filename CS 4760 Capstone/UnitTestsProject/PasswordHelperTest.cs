using RSPGApplication.Models;
using Microsoft.EntityFrameworkCore;
using RSPGApplication.Data;
using RSPGApplication.Pages.BudgetFormContents;
using RSPGApplication;
using Microsoft.AspNetCore.Http;


namespace UnitTestsProject
{
    [TestClass]
    public class PasswordHelperTest
    {

        [TestMethod]
        public async Task Password_Helper_Test()
        {
            string value = "123";

            string sameValue = "123";

            string otherValue = "321";

            // test password creation 
            string hashedPassword = PasswordHelper.HashPassword(value);
            string otherHashedPassword = PasswordHelper.HashPassword(otherValue);
            string sameHashedPassword = PasswordHelper.HashPassword(sameValue);

            // Makes sure the returned hash value is different from the entered value
            Assert.AreNotEqual(hashedPassword, value);
            
            // Mskes sure the other hash and main hashed password don't equal the same hash
            Assert.AreNotEqual(hashedPassword, otherHashedPassword);

            // Makes sure the same value and value are hashed differently for the same input
            Assert.AreNotEqual(hashedPassword, sameHashedPassword);

            string enteredPassword = "123";

            string otherPassword = "321";

            // test to see if hashed password and entered password are equal
            bool check = PasswordHelper.VerifyPassword(enteredPassword, hashedPassword);
            Assert.IsTrue(check);

            // test to see if hashed password and other password are equal
            check = PasswordHelper.VerifyPassword(otherPassword, hashedPassword);
            Assert.IsFalse(check);

        }

    }
}
