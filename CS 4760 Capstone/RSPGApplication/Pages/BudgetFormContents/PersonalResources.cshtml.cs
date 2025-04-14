using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Nodes;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RSPGApplication.Data;
using RSPGApplication.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Elfie.Serialization;
using Microsoft.EntityFrameworkCore;
using RSPGApplication.ViewModels;

namespace RSPGApplication.Pages.BudgetFormContents
{
    public class PersonalResourcesModel : PageModel
    {
        private readonly RSPGApplicationContext _context;

        [BindProperty]
        public PersonalResources PersonalResources { get; set; } = default!;

        // Used to load any resources saved in database related to the session saved _BudgetFormId 
        public List<PersonalResources> loadedResources { get; set; }
        // Used to load the currentID used in javescript on page from loadedResources
        public int currentID { get; set; } = 0;
        // Used to load the startingID used in javescript on page from loadedResources
        public int startingID { get; set; } = 0;
        // Used to calculate the totals related to loadedResources 
        public List<ResourcePagesTotalsViewModel> totals { get; set; }
        // The RSPGform id related to the budgetForm
        public int RSPGID { get; set; } = 0;
        // Tracks if we game from edit of not.  Used in the frontend
        public string editMode { get; set; } = "false";

        public PersonalResourcesModel(RSPGApplicationContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Set up page coming from the RSPGform page
        /// </summary>
        /// <returns>The updated page</returns>
        public async Task<IActionResult> OnGet()
        {
            BudgetForm budgetForm = await _context.BudgetForm.FirstOrDefaultAsync(m => m.BudgetFormId == (int)HttpContext.Session.GetInt32("_BudgetFormId"));
            // Gets the personal resources from the database
            loadedResources = _context.PersonalResources.Where(r => r.BudgetFormId == (int)HttpContext.Session.GetInt32("_BudgetFormId")).ToList();
            // If there where any database entries
            DisplayResources();

            return Page();
        }

        /// <summary>
        /// Set up page coming from the edit page
        /// </summary>
        /// <param name="id">The RPSGForm id</param>
        /// <returns>The updated page</returns>
        public async Task<IActionResult> OnGetEditMode(int id)
        {
            editMode = "true";
            RSPGID = id;
            HttpContext.Session.SetInt32("_editModeFormId", id);
            BudgetForm budgetForm = await _context.BudgetForm.FirstOrDefaultAsync(m => m.RSPGFormID == id);
            loadedResources = _context.PersonalResources.Where(r => r.BudgetFormId == budgetForm.BudgetFormId).ToList();
            DisplayResources();

            return Page();
        }

        /// <summary>
        /// On post coming from the RSPGform
        /// </summary>
        /// <param name="resources">The personal resources to saved into the database</param>
        /// <returns>status codde 200</returns>
        public async Task<IActionResult> OnPostForms([FromBody] List<PersonalResources> resources)
        {
            // Gets the personal resources from the database
            loadedResources = _context.PersonalResources.Where(r => r.BudgetFormId == (int)HttpContext.Session.GetInt32("_BudgetFormId")).ToList();
            await UpdateDatabaseAsync((int)HttpContext.Session.GetInt32("_BudgetFormId"), resources);

            // Returns successful response
            return StatusCode(200);
        }

        /// <summary>
        /// On post coming from the edit page
        /// </summary>
        /// <param name="resources">The personal resources to saved into the database</param>
        /// <returns>status codde 200</returns>
        public async Task<IActionResult> OnPostEditMode([FromBody] List<PersonalResources> resources)
        {
            BudgetForm budgetForm = await _context.BudgetForm.FirstOrDefaultAsync(m => m.RSPGFormID == (int)HttpContext.Session.GetInt32("_editModeFormId"));
            // Gets the personal resources from the database
            loadedResources = _context.PersonalResources.Where(r => r.BudgetFormId == budgetForm.BudgetFormId).ToList();

            await UpdateDatabaseAsync(budgetForm.BudgetFormId, resources);

            HttpContext.Session.Remove("_editModeFormId");

            // Returns successful response
            return StatusCode(200);
        }

        /// <summary>
        /// Gets the page ready and load resouce totals to display on the page
        /// </summary>
        private void DisplayResources()
        {
            if (loadedResources.Count != 0)
            {
                // Gets the first and the last PRId related resource
                currentID = loadedResources.LastOrDefault().PRId;
                startingID = loadedResources[0].PRId;
                currentID++;

                // Creates a new total list 
                totals = new List<ResourcePagesTotalsViewModel>();
                foreach (PersonalResources resource in loadedResources)
                {
                    // Calculates totals and add a new total object to the new list
                    double total = resource.GetTotalWithoutTax();
                    double tax = resource.GetTax();
                    double grandTotal = resource.GetGrandTotal();


                    totals.Add(new ResourcePagesTotalsViewModel(resource.PRId, total, tax, grandTotal));
                }
            }
        }

        /// <summary>
        /// Updates the database with the new equipment resources
        /// </summary>
        /// <param name="budgetFormID">The id of the budgetform</param>
        /// <param name="resources">The list of EquipmentResource to be saved to the database</param>
        /// <returns></returns>
        public async Task UpdateDatabaseAsync(int budgetFormID, List<PersonalResources> resources)
        {
            // Removes all loadedResouces from the database
            if(loadedResources != null)
            {
                _context.PersonalResources.RemoveRange(loadedResources);
                _context.SaveChanges();
            }
            List<PersonalResources> savedResources = new List<PersonalResources>();

            // Loops through updated resources.BudgetFormID with the session BudgetFormID
            for (int i = 0; i < resources.Count; i++)
            {
                if (resources[i].Name != "")
                {
                    resources[i].BudgetFormId = budgetFormID;
                    savedResources.Add(resources[i]);
                }
            }
            // Adds them to the database
            _context.AddRange(savedResources);
            await _context.SaveChangesAsync();
        }


    }
}
