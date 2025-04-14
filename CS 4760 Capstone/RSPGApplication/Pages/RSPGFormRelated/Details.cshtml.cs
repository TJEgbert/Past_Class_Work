using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RSPGApplication.Data;
using RSPGApplication.Models;
using System.IO;
using static RSPGApplication.Pages.RSPGFormRelated.RSPGFormPageModel;
using RSPGApplication.HelperClasses;
using CardTotals = RSPGApplication.HelperClasses.CardTotals;

namespace RSPGApplication.Pages.RSPGFormRelated
{
    public class DetailsModel : PageModel
    {
        private readonly RSPGApplicationContext _context;

        // Holds the string representation of RSPGTotal for personal resources
        public string PrRRSPGTotal { get; set; } = "$0.00";
        // Holds the string representation of Total for personal resources
        public string PrTotal { get; set; } = "$0.00";

        // Holds the string representation of RSPGTotal for equipment resources
        public string ErRRSPGTotal { get; set; } = "$0.00";
        // Holds the string representation of Total for equipment resources
        public string ErTotal { get; set; } = "$0.00";

        // Holds the string representation of RSPGTotal for travel resources
        public string TrRRSPGTotal { get; set; } = "$0.00";
        // Holds the string representation of Total for travel resources
        public string TrTotal { get; set; } = "$0.00";

        // Holds the string representation of RSPGTotal for other resources
        public string OrRRSPGTotal { get; set; } = "$0.00";
        // Holds the string representation of Total for other resources
        public string OrTotal { get; set; } = "$0.00";

        // Holds the Budgtform for the RSPG form
        private BudgetForm budgetForm { get; set; }

        // Used to update the visibility of the resources cards on page reload
        public string PrVisibility { get; set; } = "hidden";
        public string ErVisibility { get; set; } = "hidden";
        public string TrVisibility { get; set; } = "hidden";
        public string OrVisibility { get; set; } = "hidden";

        // Used to display the RSPG Rubric button
        public bool isRating = false;

        public DetailsModel(RSPGApplicationContext context)
        {
            _context = context;
        }

        [BindProperty]
        public RSPGFormModel RSPGFormModel { get; set; } = default!;

        /// <summary>
        /// Gets called if the user is coming in for just the Details
        /// </summary>
        /// <param name="id">The id of the RSPGform</param>
        /// <returns>The page if id or rspgformodel is not null else NotFound</returns>
        public async Task<IActionResult> OnGetDetailsAsync(int? id)
        {
            
            if (id == null)
            {
                return NotFound();
            }

            var rspgformmodel = await _context.RSPGForm.FirstOrDefaultAsync(m => m.RSPGFormId == id);

            if (rspgformmodel == null)
            {
                return NotFound();
            }

            RSPGFormModel = rspgformmodel;
            ViewData["CollegeId"] = new SelectList(_context.College, "CollegeID", "Name");
            ViewData["DepartmentId"] = new SelectList(_context.Department, "DeptID", "Name");
            ViewData["UserId"] = new SelectList(_context.User, "Id", "email");

            BudgetForm tempBudgetForm = await _context.BudgetForm.FirstOrDefaultAsync(m => m.RSPGFormID == id);
            budgetForm = tempBudgetForm;
            CardSetUp();


            return Page();
        }

        /// <summary>
        /// Gets called if the user is coming in from RSPGIndex
        /// </summary>
        /// <param name="id">The id of the RSPGform</param>
        /// <returns>The page if id or rspgformodel is not null else NotFound</returns>
        public async Task<IActionResult> OnGetRateAsync(int? id)
        {
            isRating = true;
            if (id == null)
            {
                return NotFound();
            }

            var rspgformmodel = await _context.RSPGForm.FirstOrDefaultAsync(m => m.RSPGFormId == id);

            if (rspgformmodel == null)
            {
                return NotFound();
            }

            RSPGFormModel = rspgformmodel;
            ViewData["CollegeId"] = new SelectList(_context.College, "CollegeID", "Name");
            ViewData["DepartmentId"] = new SelectList(_context.Department, "DeptID", "Name");
            ViewData["UserId"] = new SelectList(_context.User, "Id", "email");

            BudgetForm tempBudgetForm = await _context.BudgetForm.FirstOrDefaultAsync(m => m.RSPGFormID == id);
            budgetForm = tempBudgetForm;
            CardSetUp();


            return Page();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> OnGetDownloadIRBAsync(int id)
        {
            var submission = await _context.RSPGForm.FirstOrDefaultAsync(m => m.RSPGFormId == id);
            if (submission == null || string.IsNullOrEmpty(submission.IRBForm))
            {
                return NotFound();
            }

            string folderName = "userID_" + submission.UserId + "_projectName_" + submission.ProjectTitle;
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "FileUpload", folderName,submission.IRBForm);

            if (!System.IO.File.Exists(filePath))
            {
                return NotFound();
            }

            string contentType = GetContentType(filePath);
            return PhysicalFile(filePath, contentType, submission.IRBForm);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public async Task<IActionResult> OnGetDownloadFileAsync(int id, string anotherid)
        {
            var submission = await _context.RSPGForm.FirstOrDefaultAsync(m => m.RSPGFormId == id);
            if (submission == null || string.IsNullOrEmpty(anotherid))
            {
                return NotFound();
            }

            string folderName = "userID_" + submission.UserId + "_projectName_" + submission.ProjectTitle;
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "FileUpload", folderName, anotherid);

            if (!System.IO.File.Exists(filePath))
            {
                return NotFound();
            }

            string contentType = GetContentType(filePath);
            return PhysicalFile(filePath, contentType, anotherid);
        }

        private string GetContentType(string filePath)
        {
            var fileExtension = Path.GetExtension(filePath).ToLower();
            return fileExtension switch
            {
                ".jpg" or ".jpeg" => "image/jpeg",
                ".png" => "image/png",
                ".pdf" => "application/pdf",
                ".docx" => "application/vnd.openxmlformats-officedocument.wordprocessingml.document",
                _ => "application/octet-stream"
            };
        }

        /// <summary>
        /// Sets up resource cards and displays the correct ones based on grant types
        /// </summary>
        private async void CardSetUp()
        {
            // If there is budget form
            if (budgetForm != null)
            {
                TotalsCalc calulator = new TotalsCalc(_context);
                CardTotals totals = new CardTotals();

                totals = calulator.CalcprTotals(budgetForm.BudgetFormId);
                PrTotal = totals.Total;
                PrRRSPGTotal = totals.RSPGTotal;

                totals = calulator.CalcErTotals(budgetForm.BudgetFormId);
                ErTotal = totals.Total;
                ErRRSPGTotal = totals.RSPGTotal;

                totals = calulator.CalcTrTotals(budgetForm.BudgetFormId);
                TrTotal = totals.Total;
                TrRRSPGTotal = totals.RSPGTotal;

                totals = calulator.CalcOrTotals(budgetForm.BudgetFormId);
                OrTotal = totals.Total;
                OrRRSPGTotal = totals.RSPGTotal;
            }

            // Updates the visibility of resource cards 
            if (RSPGFormModel.GrantType.ToLower() == "travel")
            {
                TrVisibility = "";
            }
            else
            {
                PrVisibility = "";
                TrVisibility = "";
                ErVisibility = "";
                OrVisibility = "";
            }

        }

    }
}
