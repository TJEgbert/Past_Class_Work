using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RSPGApplication.Data;
using RSPGApplication.HelperClasses;
using RSPGApplication.Models;
using RSPGApplication.ViewModels;

namespace RSPGApplication.Pages.RSPGFormRelated
{
    public class RSPGIndexModel : PageModel
    {
        private readonly RSPGApplicationContext _context;

        public RSPGIndexModel(RSPGApplicationContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public List<RatingEntryViewModel> RatingEntries { get; set; } = new List<RatingEntryViewModel>();

        public async Task OnGetAsync()
        {
            List<RSPGFormModel> RSPGFormModel = new List<RSPGFormModel>();

            if (_context.RSPGForm != null)
            {
                RSPGFormModel = await _context.RSPGForm
                    .Include(r => r.College)
                    .Include(r => r.Department)
                    .Include(r => r.User)
                    .Where(r=> r.ChairApproved == true)
                    .ToListAsync();

                foreach(RSPGFormModel form in RSPGFormModel)
                {
                    int userID = (int) HttpContext.Session.GetInt32("_UserID");
                    Rating rating = await _context.Rating.FirstOrDefaultAsync(r => r.UserId == userID && r.RSPGFormId == form.RSPGFormId);
                    BudgetForm budgetForm = await _context.BudgetForm.FirstOrDefaultAsync(r => r.RSPGFormID == form.RSPGFormId);
                    double rspgTotal = 0;
                    if (budgetForm != null)
                    {
                        TotalsCalc calculator = new TotalsCalc(_context);
                        rspgTotal = await calculator.GetRSPGTotalAsync(budgetForm.BudgetFormId);
                    }

                    if (rating != null)
                    {
                        RatingEntries.Add(new RatingEntryViewModel(form, $"{form.User.firstName} {form.User.lastName}", form.ProjectTitle, rspgTotal.ToString("c2"), rating.RSPGRating));
                    }
                    else
                    {
                        RatingEntries.Add(new RatingEntryViewModel(form, $"{form.User.firstName} {form.User.lastName}", form.ProjectTitle, rspgTotal.ToString("c2"), 0));
                    }
                }
            }
        }

    }
}
