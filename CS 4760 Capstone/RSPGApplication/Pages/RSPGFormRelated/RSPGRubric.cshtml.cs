using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System;
using RSPGApplication.Models;

namespace RSPGApplication.Pages.RSPGFormRelated
{

    public class RSPGRubricModel : PageModel
    {
        private readonly Data.RSPGApplicationContext _context;


        public RSPGRubricModel(Data.RSPGApplicationContext context)
        {
            _context = context;
        }

        public List<Criteria> CriteriaList { get; set; } = new();

        public Rating UserRating { get; set; } = default!;

        [BindProperty]
        public Dictionary<int, double> Scores { get; set; } = new();

        [BindProperty]
        public Dictionary<string, double> AreaScores { get; set; } = new();


        public async Task<IActionResult> OnGetAsync()
        {
            CriteriaList = await _context.Criteria.ToListAsync();
            return Page();
        }

        public IActionResult OnPostCalculate()
        {
            CriteriaList = _context.Criteria.ToList();

            double totalWeightedScore = 0;
            double maxPossibleScore = 0;

            // Handle Area 1 & 2 as a single score
            var areaGroups = CriteriaList.GroupBy(c => c.CriteriaSection);


            foreach (var group in areaGroups)
            {
                if (group.Key == "Area One" || group.Key == "Area Two")
                {
                    if (AreaScores.TryGetValue(group.Key, out double areaScore))
                    {
                        double groupWeightSum = group.Sum(c => c.Weight);
                        totalWeightedScore += groupWeightSum * areaScore;
                        maxPossibleScore += groupWeightSum * 2;
                    }
                }
                else // Area 3 or others, per-criteria scoring
                {
                    foreach (var criteria in group)
                    {
                        if (Scores.TryGetValue(criteria.CriteriaId, out double score))
                        {
                            totalWeightedScore += criteria.Weight * score;
                            maxPossibleScore += criteria.Weight * 2;
                        }
                    }
                }
            }


            double finalRating = maxPossibleScore > 0 ? 100 * totalWeightedScore / maxPossibleScore : 0;
            ViewData["FinalRating"] = finalRating;

            TempData["FinalRating"] = finalRating.ToString();
            TempData.Keep("FinalRating");

            return Page();
        }

        public async Task<IActionResult> OnPostRate()
        {

            if (TempData["FinalRating"] == null)
            {
                CriteriaList = await _context.Criteria.ToListAsync();
                return Page(); // Ensure TempData exists before proceeding
            }

            double ratingValue = Convert.ToDouble(TempData["FinalRating"]);


            if (ratingValue < 0 || ratingValue > 100)
            {
                CriteriaList = await _context.Criteria.ToListAsync();
                return Page();
            }

            double rating = ratingValue;

            int? intSessionData = HttpContext.Session.GetInt32("_UserID");
            int? RSPGSessionData = HttpContext.Session.GetInt32("_RSPGFORMID");

            int UserID = intSessionData.GetValueOrDefault();
            int FormID = RSPGSessionData.GetValueOrDefault();

            //check to see if the user has already rated the form 
            var existingRating = await _context.Rating.FirstOrDefaultAsync(r => r.RSPGFormId == FormID && r.UserId == UserID);

            if (existingRating != null)
            {
                existingRating.RSPGRating = ratingValue;
            }
            else
            {
                UserRating = new Rating
                {
                    RSPGFormId = FormID,
                    UserId = UserID,
                    RSPGRating = ratingValue,
                };
                _context.Rating.Add(UserRating);
            }

            await _context.SaveChangesAsync();

            return RedirectToPage("/RSPGFormRelated/RSPGIndex");
        }
    }
}