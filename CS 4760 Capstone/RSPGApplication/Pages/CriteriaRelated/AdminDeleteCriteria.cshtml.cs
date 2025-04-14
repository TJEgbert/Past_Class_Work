using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RSPGApplication.Data;
using RSPGApplication.Models;

namespace RSPGApplication.Pages.CriteriaRelated
{
    public class AdminDeleteCriteriaModel : PageModel
    {
        private readonly RSPGApplicationContext _context;

        public AdminDeleteCriteriaModel(RSPGApplicationContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Criteria Criteria { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var criteria = await _context.Criteria.FirstOrDefaultAsync(m => m.CriteriaId == id);

            if (criteria == null)
            {
                return NotFound();
            }
            else
            {
                Criteria = criteria;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var criteria = await _context.Criteria.FindAsync(id);
            if (criteria != null)
            {
                Criteria = criteria;
                _context.Criteria.Remove(Criteria);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("/CriteriaRelated/AdminRSPGRubric");
        }
    }
}

