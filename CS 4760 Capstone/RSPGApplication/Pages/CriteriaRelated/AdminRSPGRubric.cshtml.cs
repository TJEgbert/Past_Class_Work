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
    public class AdminRSPGRubricModel : PageModel
    {
        private readonly RSPGApplicationContext _context;

        public AdminRSPGRubricModel(RSPGApplicationContext context)
        {
            _context = context;
        }

        public IList<Criteria> Criteria { get; set; } = default!;

        public async Task OnGetAsync()
        {
            Criteria = await _context.Criteria.ToListAsync();
        }
    }
}
