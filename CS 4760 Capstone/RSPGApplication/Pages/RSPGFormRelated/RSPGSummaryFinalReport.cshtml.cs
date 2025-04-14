using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RSPGApplication.Data;
using RSPGApplication.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace RSPGApplication.Pages.RSPGFormRelated
{
    public class RSPGSummaryFinalReportModel : PageModel
    {
        private readonly RSPGApplicationContext _dbContext;
        private readonly ILogger<RSPGSummaryFinalReportModel> _logger;

        public RSPGSummaryFinalReportModel(RSPGApplicationContext dbContext, ILogger<RSPGSummaryFinalReportModel> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        [BindProperty]
        public RSPGSummaryFinalReport Report { get; set; } = new RSPGSummaryFinalReport();

        [BindProperty]
        public IFormFile? AppendicesFile { get; set; }

        public List<SelectListItem> ProjectTitles { get; set; } = new List<SelectListItem>();
        public List<string> ProposalTypes { get; set; } = new List<string>
        {
            "Hemingway Faculty Vitality",
            "Research and Professional Grants",
            "Innovative Teaching",
            "Hemingway Excellence or Collaborative",
            "Hemingway New Faculty"
        };

        public IActionResult OnGet()
        {
            var userId = HttpContext.Session.GetInt32("_UserID");

            if (userId == null)
            {
                return RedirectToPage("/UserRelated/Login");
            }

            var user = _dbContext.User
                .Include(u => u.College)
                .Include(u => u.Department)
                .FirstOrDefault(u => u.Id == userId.Value);

            if (user != null)
            {
                Report.UserId = user.Id;
                Report.Email = user.email;
                Report.ProjectDirector = $"{user.firstName} {user.lastName}";

                // Fetch all RSPG Forms submitted by this user
                var userProjects = _dbContext.RSPGForm
                    .Where(f => f.UserId == user.Id)
                    .Select(f => new SelectListItem { Value = f.ProjectTitle, Text = f.ProjectTitle })
                    .ToList();

                ProjectTitles = userProjects;

                // Pre-select the most recent project if available
                if (userProjects.Any())
                {
                    Report.ProjectTitle = userProjects.First().Value;
                }
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var userId = HttpContext.Session.GetInt32("_UserID");

            if (userId == null)
            {
                ModelState.AddModelError(string.Empty, "User session expired. Please log in again.");
                return Page();
            }

            // Ensure UserId exists before saving
            var userExists = await _dbContext.User.AnyAsync(u => u.Id == userId);
            if (!userExists)
            {
                ModelState.AddModelError(string.Empty, "Invalid user. Please contact the administrator.");
                return Page();
            }

            Report.UserId = userId.Value; // Assign UserId to ensure foreign key integrity

            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Handle file upload if any
            if (AppendicesFile != null)
            {
                var uploadsFolder = Path.Combine("wwwroot/uploads");
                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }

                var filePath = Path.Combine(uploadsFolder, AppendicesFile.FileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await AppendicesFile.CopyToAsync(fileStream);
                }

                Report.AppendicesFilePaths = new List<string> { "/uploads/" + AppendicesFile.FileName };
            }

            _dbContext.RSPGSummaryFinalReport.Add(Report);
            await _dbContext.SaveChangesAsync();


            return RedirectToPage("/Dashboard");
        }
    }
}
