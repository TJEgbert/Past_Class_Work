using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RSPGApplication.Data;
using RSPGApplication.Models;
using RSPGApplication.ViewModels;

namespace RSPGApplication.Pages.BudgetFormContents
{
    public class ORDetailsModel : PageModel
    {
        private readonly RSPGApplication.Data.RSPGApplicationContext _context;

        public List<OtherResource> OtherResources { get; set; } = default!;
        // Holds the totals for each resource
        public List<ResourcePagesTotalsViewModel> totalLists { get; set; } = default!;
        // The RSPGForm Id used to get the budgetForm
        public int RSPGFormID;

        public ORDetailsModel(RSPGApplication.Data.RSPGApplicationContext context)
        {
            _context = context;
        }

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
            List<OtherResource> otherresources = await _context.OtherResource.Where(m => m.BudgetFormId == budgetForm.BudgetFormId).ToListAsync();

            if (otherresources == null)
            {
                return NotFound();
            }
            else
            {
                OtherResources = otherresources;

                totalLists = new List<ResourcePagesTotalsViewModel>();
                foreach (OtherResource resource in OtherResources)
                {
                    double total = resource.GetTotal();

                    totalLists.Add(new ResourcePagesTotalsViewModel(resource.ORId, total));
                }
            }
            return Page();
        }

    }
}
