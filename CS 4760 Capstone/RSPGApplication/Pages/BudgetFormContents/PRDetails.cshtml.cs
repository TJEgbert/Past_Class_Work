using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RSPGApplication.Data;
using RSPGApplication.Models;
using RSPGApplication.ViewModels;

namespace RSPGApplication.Pages.BudgetFormContents
{
    public class PRDetailsModel : PageModel
    {
        private readonly RSPGApplicationContext _context;

        public PRDetailsModel(RSPGApplicationContext context)
        {
            _context = context;
        }

        // Holds the personal resource associated with RSPG form
        public List<PersonalResources> PersonalResources { get; set; } = default!;
        // Holds the totals for each  resource
        public List<ResourcePagesTotalsViewModel> totalLists { get; set; } = default!;
        // The RSPGForm Id used to get the budgetForm
        public int RSPGFormID;

        public async Task<IActionResult> OnGetSetRSPGIDAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            RSPGFormID = (int)id;
            // Gets the budget form related the RSPGForm ID
            BudgetForm budgetForm = await _context.BudgetForm.FirstOrDefaultAsync(m => m.RSPGFormID == id);
            // Gets the personal resources
            List<PersonalResources> personalresources = await _context.PersonalResources.Where(m => m.BudgetFormId == budgetForm.BudgetFormId).ToListAsync();

            if (personalresources == null)
            {
                return NotFound();
            }
            else
            {
                // Gets the totals need for display on the page
                totalLists = new List<ResourcePagesTotalsViewModel>();
                PersonalResources = personalresources;
                foreach (PersonalResources resource in personalresources)
                {
                    double total = resource.GetTotalWithoutTax();
                    double tax = resource.GetTax();
                    double grandTotal = resource.GetGrandTotal();


                    totalLists.Add(new ResourcePagesTotalsViewModel(resource.PRId, total, tax, grandTotal));
                }
            }
            return Page();
        }

    }
}
