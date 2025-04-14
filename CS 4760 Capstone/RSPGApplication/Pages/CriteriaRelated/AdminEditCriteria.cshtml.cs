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

namespace RSPGApplication.Pages.CriteriaRelated
{
    public class AdminEditCriteriaModel : PageModel
    {
        private readonly RSPGApplicationContext _context;

        public AdminEditCriteriaModel(RSPGApplicationContext context)
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
            Criteria = criteria;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Criteria).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CriteriaExists(Criteria.CriteriaId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("/CriteriaRelated/AdminRSPGRubric");
        }

        private bool CriteriaExists(int id)
        {
            return _context.Criteria.Any(e => e.CriteriaId == id);
        }
    }
}

