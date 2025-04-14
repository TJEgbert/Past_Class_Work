using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Text;

namespace RSPGApplication.Pages.RSPGFormRelated
{
    public class SendToAccountingModel : PageModel
    {
        public string CsvData { get; private set; }
        public string ErrorMessage { get; private set; }

        public void OnGet()
        {
            // Retrieve CSV data and prevent data loss on refresh
            CsvData = TempData.Peek("CsvData") as string ?? string.Empty;
            ErrorMessage = TempData["ErrorMessage"] as string ?? string.Empty;
        }

        public IActionResult OnPostDownloadCsv()
        {
            var csvData = TempData.Peek("CsvData") as string;

            if (string.IsNullOrEmpty(csvData))
            {
                TempData["ErrorMessage"] = "No CSV data found. Please allocate funds and send to accounting again.";
                return RedirectToPage("FundAllocation");
            }

            byte[] fileBytes = Convert.FromBase64String(csvData);
            return File(fileBytes, "text/csv", "ApprovedFundAllocations.csv");
        }
    }
}
