using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RSPGApplication.Data;
using RSPGApplication.Models;

namespace RSPGApplication.Pages.CriteriaRelated
{
    public class AdminCreateCriteriaModel : PageModel
    {
        private readonly RSPGApplicationContext _context;

        public AdminCreateCriteriaModel(RSPGApplicationContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Criteria Criteria { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Criteria.Add(Criteria);
            await _context.SaveChangesAsync();

            return RedirectToPage("/CriteriaRelated/AdminRSPGRubric");
        }
    }
}

