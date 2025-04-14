using Elfie.Serialization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RSPGApplication.Models;
using RSPGApplication.ViewModels;
using RSPGApplication.Data;

using System.Globalization;
using System.Text;
using Newtonsoft.Json;
using RSPGApplication.HelperClasses;

namespace RSPGApplication.Pages.RSPGFormRelated
{
    public class FundAllocationModel : PageModel
    {
        private readonly Data.RSPGApplicationContext _context;

        public List<RSPGFundAllocationViewModel> FormWithTotal { get; set; } = default!;
        public List<RSPGFundAllocationViewModel> ApprovedFormWithTotal { get; set; } = default!;

        // New properties to store default values
        public double DefaultTotalAllocation { get; set; }
        public double DefaultMaxAllocation { get; set; }

        public FundAllocationModel(Data.RSPGApplicationContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGet()
        {
            FormWithTotal = new List<RSPGFundAllocationViewModel>();
            ApprovedFormWithTotal = new List<RSPGFundAllocationViewModel>();

            double totalAvailableFunds = 100000;
            var unapprovedForms = await _context.RSPGForm
                .Where(m => m.ApprovalStatus == null && m.ChairApproved == true)
                .ToListAsync();

            foreach (var form in unapprovedForms)
            {
                var user = await _context.User.FirstOrDefaultAsync(r => r.Id == form.UserId);
                var rating = await _context.Rating.FirstOrDefaultAsync(r => r.RSPGFormId == form.RSPGFormId);
                BudgetForm budgetForm = await _context.BudgetForm.FirstOrDefaultAsync(r => r.RSPGFormID == form.RSPGFormId);
                TotalsCalc totalCalulator = new TotalsCalc(_context);
                double totalRequested = await totalCalulator.GetRSPGTotalAsync(budgetForm.BudgetFormId);

                FormWithTotal.Add(new RSPGFundAllocationViewModel(
                    form,
                    totalRequested,
                    rating?.RSPGRating ?? 0,
                    user != null ? $"{user.firstName} {user.lastName}" : "Unknown",
                    projectTitle: form.ProjectTitle
                ));
            }

            return Page();
        }

        /// <summary>
        /// Generates a CSV file of approved allocations and redirects to the SendToAccounting page.
        /// </summary>
        public async Task<IActionResult> OnPostSendToAccountingAsync()
        {
            var approvedForms = await _context.RSPGForm
                .Where(m => m.ApprovalStatus == true)
                .ToListAsync();

            if (!approvedForms.Any())
            {
                TempData["Message"] = "No approved forms available to send.";
                return RedirectToPage();
            }

            var csv = new StringBuilder();
            csv.AppendLine("First Name,Last Name,Mail Code,Amount");

            foreach (var form in approvedForms)
            {
                var user = await _context.User.FirstOrDefaultAsync(u => u.Id == form.UserId);
                if (user != null)
                {
                    csv.AppendLine($"{user.firstName},{user.lastName},{form.MailCode},{form.AllocatedAmount}");
                }
            }

            byte[] fileBytes = Encoding.UTF8.GetBytes(csv.ToString());
            TempData["CsvData"] = Convert.ToBase64String(fileBytes);

            return StatusCode(200);
        }

        /// <summary>
        /// Updates the RSPGForms with their allocated amounts and approval status
        /// </summary>
        /// <param name="allocatedAmmounts">Holds the id and allocated amount for the rspg forms</param>
        /// <returns>Status code 200</returns>
        public async Task<IActionResult> OnPostDone([FromBody] List<RSPGFormSubmitInfo> allocatedAmmounts)
        {
            if (allocatedAmmounts == null || !allocatedAmmounts.Any())
            {
                TempData["Message"] = "No allocations were provided.";
                return RedirectToPage();
            }

            // Iterate over each form and update it directly
            foreach (var allocation in allocatedAmmounts)
            {
                int approvaleStatus = 0;
                if (allocation.AllocatedAmount > 0)
                {
                    approvaleStatus = 1;
                }
                await _context.Database.ExecuteSqlRawAsync(
                    "UPDATE RSPGForm SET AllocatedAmount = {0}, ApprovalStatus = {1} WHERE RSPGFormId = {2}",
                    allocation.AllocatedAmount,
                    approvaleStatus,  // Approve if > 0
                    allocation.FormID
                );
            }
            return StatusCode(200);
        }


        /// <summary>
        /// Helper class to hold information from the frontend
        /// </summary>
        public class RSPGFormSubmitInfo
        {
            public double AllocatedAmount { get; set; }
            public int FormID { get; set; }
        }

    }
}