using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace RSPGApplication.Pages.UserRelated
{
    public class LoginModel : PageModel
    {

        private readonly Data.RSPGApplicationContext _context;

        public LoginModel(Data.RSPGApplicationContext context)
        {
            _context = context;
            message = "";
        }

        /// <summary>
        /// Holds the email that get entered into the form
        /// </summary>
        [BindProperty]
        public required string email { get; set; }

        /// <summary>
        /// Holds the password that get entered in on the form
        /// </summary>
        [BindProperty]
        public required string password { get; set; }

        /// <summary>
        /// Holds a message if one is needed for the user
        /// </summary>
        public string message { get; set; }

        public IActionResult OnGet()
        {
            if (!Program.inDeveloperMode)
            {
                if (HttpContext.Session.Get("_UserID") != null)
                {
                    return RedirectToPage("/dashboard");
                }
            }
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            // Gets the user frome the database based on email
            var user = await _context.User.FirstOrDefaultAsync(m => m.email == email);

            if (user != null)
            {
                string storedHash = user.password;

                // Checks if the user name password and email are correct and there is a user
                if (email.ToLower().Equals(user.email.ToLower()) && PasswordHelper.VerifyPassword(password, storedHash) && user != null)
                {
                    // set session here
                    HttpContext.Session.SetInt32("_UserID", user.Id);
                    HttpContext.Session.SetString("_Position", user.position);
                    HttpContext.Session.SetInt32("_CollegeID", (int)user.CollegeId);
                    HttpContext.Session.SetInt32("_DeptID", (int)user.DepartmentId);
                    HttpContext.Session.SetString("_IsRSPG", user.RSPGMember.ToString());
                    HttpContext.Session.SetString("_IsAdmin", user.isAdmin.ToString());
                    HttpContext.Session.SetString("_IsRSPGChair", user.isRSPGChair.ToString());
                    HttpContext.Session.SetString("_IsDeptChair",user.isDepChair.ToString());

                    // Rederiected to dashboard once completed
                    return RedirectToPage("/dashboard");
                }
            }

            message = "Email or password is incorrect";
            return Page();
        }
    }
}
