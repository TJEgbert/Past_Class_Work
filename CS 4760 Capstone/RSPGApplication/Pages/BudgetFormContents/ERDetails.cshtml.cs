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
    public class ERDetailsModel : PageModel
    {
        private readonly RSPGApplication.Data.RSPGApplicationContext _context;

        public List<EquipmentResource> EquipmentResources { get; set; } = default!;
        // Holds the totals for each resource
        public List<ResourcePagesTotalsViewModel> totalLists { get; set; } = default!;
        // The RSPGForm Id used to get the budgetForm
        public int RSPGFormID;

        public ERDetailsModel(RSPGApplication.Data.RSPGApplicationContext context)
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
            List<EquipmentResource> equipmentresource = await _context.EquipmentResource.Where(m => m.BudgetFormId == budgetForm.BudgetFormId).ToListAsync();

            if (equipmentresource == null)
            {
                return NotFound();
            }
            else
            {
                EquipmentResources = equipmentresource;

                totalLists = new List<ResourcePagesTotalsViewModel>();
                foreach (EquipmentResource resource in EquipmentResources)
                {
                    double total = resource.GetTotal();

                    totalLists.Add(new ResourcePagesTotalsViewModel(resource.ERId, total));
                }
            }
            return Page();
        }

    }
}
