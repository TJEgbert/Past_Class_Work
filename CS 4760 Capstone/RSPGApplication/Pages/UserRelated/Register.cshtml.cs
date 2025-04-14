using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using NuGet.Protocol;
using RSPGApplication.Models;
using System.Diagnostics;

namespace RSPGApplication.Pages.UserRelated
{
    public class RegisterModel : PageModel
    {
        private readonly Data.RSPGApplicationContext _context;

        /// <summary>
        /// Holds the colleges that are in the database
        /// </summary>
        public List<SelectListItem> colleges { get; set; }


        /// <summary>
        /// Holds the information for the newly created User
        /// </summary>
        [BindProperty]
        public User user { get; set; } = default!;

        public RegisterModel(Data.RSPGApplicationContext context)
        {
            _context = context;
            GetColleges();
        }

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

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {

            if (!ModelState.IsValid)
            {
                return Page();
            }

            user.confirmPassword = null;

            user.password = PasswordHelper.HashPassword(user.password);

            _context.User.Add(user);
            await _context.SaveChangesAsync();

            HttpContext.Session.SetInt32("_UserID", user.Id);
            HttpContext.Session.SetString("_Position", user.position);
            HttpContext.Session.SetInt32("_CollegeID", (int)user.CollegeId);
            HttpContext.Session.SetInt32("_DeptID", (int)user.DepartmentId);
            HttpContext.Session.SetString("_IsRSPG", user.RSPGMember.ToString());

            return RedirectToPage("/dashboard");
        }


        /// <summary>
        /// Loads the department drop down box based in college
        /// </summary>
        /// <param name="name">The name of the college</param>
        /// <returns>Json containing the colleges</returns>
        public IActionResult OnGetDepartments(string name)
        {
            // update once models for department and college are done
            IList<Department> departments = _context.Department.Where(dep => dep.CollegeID == int.Parse(name)).ToList();
            List<SelectListItem> jsonList = new List<SelectListItem>();

            foreach (Department item in departments)
            {
                jsonList.Add(new SelectListItem(item.Name, item.DeptID.ToString()));
            }
            var jsonResult = new JsonResult(jsonList);
            return jsonResult;
        }

        private void GetColleges()
        {
            List<SelectListItem> temp = new List<SelectListItem>();
            IList<College> collegeList = _context.College.ToList();
            List<string> names = new List<string>();
            foreach (var item in collegeList)
            {
                temp.Add(new SelectListItem(item.Name, item.CollegeID.ToString()));
            }
            colleges = temp;
        }

    }
}
