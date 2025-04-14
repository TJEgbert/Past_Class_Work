using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.SqlServer.Server;
using RSPGApplication.Data;
using RSPGApplication.Models;

namespace RSPGApplication.Pages.RSPGFormRelated
{
    public class ApprovalPageModel : PageModel
    {
        private readonly RSPGApplication.Data.RSPGApplicationContext _context;

        public ApprovalPageModel(RSPGApplication.Data.RSPGApplicationContext context)
        {
            _context = context;
        }

        [BindProperty]
        public IList<RSPGFormModel> RSPGFormModel { get; private set; } = new List<RSPGFormModel>();

        public async Task<IActionResult> OnGetAsync()
        {
            if (_context.RSPGForm != null)
            {
                int? deptId = HttpContext.Session.GetInt32("_DeptID");

                RSPGFormModel = await _context.RSPGForm
                    .Include(r => r.College)
                    .Include(r => r.Department)
                    .Include(r => r.User)
                    .Where(r => r.DepartmentId == deptId && r.IsSubmitted == true && r.ChairApproved == null)
                    .ToListAsync();
            }

            //Set mode when on approval page 
            HttpContext.Session.SetString("_Mode", "Approval");

            return Page();
        }

        private bool RSPGFormModelExists(int id)
        {
            return _context.RSPGForm.Any(e => e.RSPGFormId == id);
        }

        public async Task<IActionResult> OnPostAcceptAsync(int id)
        {
            var rspgForm = await _context.RSPGForm.FirstOrDefaultAsync(r => r.RSPGFormId == id);

            rspgForm.ChairApproved = true;

            await _context.SaveChangesAsync();

            if (_context.RSPGForm != null)
            {
                int? deptId = HttpContext.Session.GetInt32("_DeptID");

                RSPGFormModel = await _context.RSPGForm
                    .Include(r => r.College)
                    .Include(r => r.Department)
                    .Include(r => r.User)
                    .Where(r => r.DepartmentId == deptId && r.IsSubmitted == true && r.ChairApproved == null)
                    .ToListAsync();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostRejectAsync(int id)
        {
            var rspgForm = await _context.RSPGForm.FirstOrDefaultAsync(r => r.RSPGFormId == id);

            rspgForm.ChairApproved = false;
            rspgForm.ApprovalStatus = false;

            await _context.SaveChangesAsync();

            if (_context.RSPGForm != null)
            {
                int? deptId = HttpContext.Session.GetInt32("_DeptID");

                RSPGFormModel = await _context.RSPGForm
                    .Include(r => r.College)
                    .Include(r => r.Department)
                    .Include(r => r.User)
                    .Where(r => r.DepartmentId == deptId && r.IsSubmitted == true && r.ChairApproved == null)
                    .ToListAsync();
            }

            return Page();
        }
    }
}
