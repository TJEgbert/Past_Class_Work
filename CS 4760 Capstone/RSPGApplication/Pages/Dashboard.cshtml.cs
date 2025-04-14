using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RSPGApplication.Models;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace RSPGApplication.Pages
{
    public class DashboardModel : PageModel
    {

        private readonly RSPGApplication.Data.RSPGApplicationContext _context;

        public DashboardModel(RSPGApplication.Data.RSPGApplicationContext context)
        {
            _context = context;
        }

        [BindProperty]
        public IList<Models.RSPGFormModel> RSPGForm { get; set; }

        public IList<Models.RSPGFormModel> ApprovedForms { get; set; }
        public IList<Models.RSPGFormModel> RejectedForms { get; set; }
        public IList<Models.RSPGFormModel> PendingForms { get; set; }

        public IActionResult OnGet()
        {
            clearRSPGFormSessionData();
            if (!Program.inDeveloperMode)
            {
                if (HttpContext.Session.Get("_UserID") == null)
                {
                    return RedirectToPage("/UserRelated/login");
                }
            }

            var userId = HttpContext.Session.GetInt32("_UserID");

            if (userId == null)
            {
                return RedirectToPage("/login");
            }

            RSPGForm = _context.RSPGForm
                .Include(r => r.User) // Include related User data
                .Include(r => r.College)
                .Include(r => r.Department)
                .Where(r => r.UserId == userId)
                .ToList();

            // TODO --- Needing an approval status on the RSPGFormModel
            ApprovedForms = RSPGForm.Where(r => r.ApprovalStatus == true).ToList();
            RejectedForms = RSPGForm.Where(r => r.ApprovalStatus == false).ToList();
            PendingForms = RSPGForm.Where(r => r.ApprovalStatus == null).ToList();

            //For looking at the details of the submitted forms 
            HttpContext.Session.SetString("_Mode", "Desktop");

            return Page();
        }

        public async Task<IActionResult> OnPostDelete(int id)
        {
            RSPGFormModel deleteForm = _context.RSPGForm.FirstOrDefault(f => f.RSPGFormId == id);
            _context.SaveChanges();

            return StatusCode(200);
        }


        private void clearRSPGFormSessionData()
        {
            HttpContext.Session.Remove("_formUserId");
            HttpContext.Session.Remove("_formCollegeId");
            HttpContext.Session.Remove("_formDepartmentId");
            HttpContext.Session.Remove("_formProjectTitle");
            HttpContext.Session.Remove("_formMailCode");
            HttpContext.Session.Remove("_formDepartmentChair");
            HttpContext.Session.Remove("_formOtherParticipants");
            HttpContext.Session.Remove("_formProgramDirectorName");
            HttpContext.Session.Remove("_formProjectDirector");
            HttpContext.Session.Remove("_sememester");
            HttpContext.Session.Remove("_grantType");
            HttpContext.Session.Remove("_prVisibility");
            HttpContext.Session.Remove("_erVisibility");
            HttpContext.Session.Remove("_trVisibility");
            HttpContext.Session.Remove("_orVisibility");
            HttpContext.Session.Remove("_formId");
            HttpContext.Session.Remove("_editModeFormId");
        }
    }
}
