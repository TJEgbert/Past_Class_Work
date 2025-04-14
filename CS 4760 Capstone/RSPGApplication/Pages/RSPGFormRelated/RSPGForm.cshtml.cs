using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Plugins;
using Pomelo.EntityFrameworkCore.MySql.Storage.Internal;
using RSPGApplication.Data;
using RSPGApplication.HelperClasses;
using RSPGApplication.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace RSPGApplication.Pages.RSPGFormRelated
{
    public class RSPGFormPageModel : PageModel
    {
        private readonly RSPGApplicationContext _dbContext;

        public RSPGFormPageModel(RSPGApplicationContext dbContext)
        {
            _dbContext = dbContext;
        }

        [BindProperty]
        public RSPGFormModel RSPGForm { get; set; } = default!; // Form data

        public List<SelectListItem> Colleges { get; set; } // Colleges dropdown
        public List<SelectListItem> Departments { get; set; } // Departments dropdown
        public List<User> Users { get; set; } // Users dropdown
        public List<string> LoadedFiles { get; set; } = new List<string>();
    

        [BindProperty]
        public BudgetForm budgetForm { get; set; } = default!;

        // Holds the string representation of RSPGTotal for personal resources
        public string PrRRSPGTotal { get; set; } = "$0.00";
        // Holds the string representation of Total for personal resources
        public string PrTotal { get; set; } = "$0.00";

        // Holds the string representation of RSPGTotal for equipment resources
        public string ErRRSPGTotal { get; set; } = "$0.00";
        // Holds the string representation of Total for equipment resources
        public string ErTotal { get; set; } = "$0.00";

        // Holds the string representation of RSPGTotal for travel resources
        public string TrRRSPGTotal { get; set; } = "$0.00";
        // Holds the string representation of Total for travel resources
        public string TrTotal { get; set; } = "$0.00";

        // Holds the string representation of RSPGTotal for other resources
        public string OrRRSPGTotal { get; set; } = "$0.00";
        // Holds the string representation of Total for other resources
        public string OrTotal { get; set; } = "$0.00";

        // Used to update the visibility of the resources cards on page reload
        public string PrVisibility { get; set; } = "hidden";
        public string ErVisibility { get; set; } = "hidden";
        public string TrVisibility { get; set; } = "hidden";
        public string OrVisibility { get; set; } = "hidden";

        public string Header { get; set; } = "RSPG Grant Application";
        public string SubHeader { get; set; } = "";
        public string editMode { get; set; } = "false";

        public IActionResult OnGet(int? id)
        {
            if (!Program.inDeveloperMode)
            {
                if (HttpContext.Session.Get("_UserID") == null)
                {
                    return RedirectToPage("/UserRelated/login");
                }
            }
            LoadDropdowns();
            RSPGForm = new RSPGFormModel();

            if (id != null)
            {
                Header = "Edit RSPG Form";
                SubHeader = "Modify your application details below:";
                RSPGForm = _dbContext.RSPGForm.FirstOrDefault(f => f.RSPGFormId == id);
                budgetForm = _dbContext.BudgetForm.FirstOrDefault(f => f.RSPGFormID == id);
                editMode = "true";
                displayCards();
                if (budgetForm != null)
                {
                    LoadCards(budgetForm.BudgetFormId);
                }
                LoadedFiles = RSPGForm.UploadedFiles;
            }
            else
            {
                var userId = HttpContext.Session.GetInt32("_UserID");

                if (userId != null)
                {

                    var user = _dbContext.User
                        .Include(u => u.College) // Include the College navigation property
                        .Include(u => u.Department) // Include the Department navigation property
                        .FirstOrDefault(u => u.Id == userId.Value);

                    // Gets the chair and the dean from the database
                    User chair = _dbContext.User.FirstOrDefault(u => u.DepartmentId == user.DepartmentId && u.isDepChair == true);
                    User dean = _dbContext.User.FirstOrDefault(u => u.CollegeId == user.CollegeId && u.isDean == true);

                    if (chair != null && dean != null)
                    {
                        RSPGForm.UserId = (int)userId;
                        RSPGForm.ProjectDirector = $"{user.firstName} {user.lastName}";
                        RSPGForm.CollegeId = user.College.CollegeID;
                        RSPGForm.DepartmentId = user.Department.DeptID;
                        RSPGForm.DepartmentChairName = $"{chair.firstName} {chair.lastName}";
                        RSPGForm.DeanName = $"{dean.firstName} {dean.lastName}";

                    }
                    else
                    {
                        RSPGForm.UserId = (int)userId;
                        RSPGForm.ProjectDirector = $"{user.firstName} {user.lastName}";
                        RSPGForm.CollegeId = user.College.CollegeID;
                        RSPGForm.DepartmentId = user.Department.DeptID;
                    }
                }
            }

            // If the user has been to form before
            if (HttpContext.Session.Get("_formUserId") != null)
            {
                // Update the visibility of the resource cards
                PrVisibility = HttpContext.Session.GetString("_prVisibility");
                ErVisibility = HttpContext.Session.GetString("_erVisibility");
                TrVisibility = HttpContext.Session.GetString("_trVisibility");
                OrVisibility = HttpContext.Session.GetString("_orVisibility");

                // Load session data from the form
                RSPGForm.UserId = (int)HttpContext.Session.GetInt32("_formUserId");
                RSPGForm.CollegeId = (int)HttpContext.Session.GetInt32("_formCollegeId");
                RSPGForm.DepartmentId = (int)HttpContext.Session.GetInt32("_formDepartmentId");
                RSPGForm.ProjectDirector = HttpContext.Session.GetString("_formProjectDirector");
                RSPGForm.ProjectTitle = HttpContext.Session.GetString("_formProjectTitle");
                RSPGForm.MailCode = HttpContext.Session.GetString("_formMailCode");
                RSPGForm.DepartmentChairName = HttpContext.Session.GetString("_formDepartmentChair");
                RSPGForm.DeanName = HttpContext.Session.GetString("_formDeanName");
                RSPGForm.OtherParticipants = HttpContext.Session.GetString("_formOtherParticipants");
                RSPGForm.ProgramDirectorName = HttpContext.Session.GetString("_formProgramDirectorName");
                RSPGForm.Semester = HttpContext.Session.GetString("_sememester");
                RSPGForm.GrantType = HttpContext.Session.GetString("_grantType");
                if(editMode == "false")
                {
                    budgetForm = _dbContext.BudgetForm.FirstOrDefault(f => f.BudgetFormId == (int)HttpContext.Session.GetInt32("_BudgetFormId"));
                    if (budgetForm != null)
                    {
                        LoadCards(budgetForm.BudgetFormId);
                    }
                    displayCards();
                }
            }

            return Page();
        }


        public IActionResult OnPostSubmitForm(IFormFileCollection uploadedFiles, IFormFile? irbFile, List<string> fileNames, List<string> databaseUploaded)
        {
            LoadDropdowns();
            if (!ModelState.IsValid)
            {
                return Page();
            }


            if (RSPGForm == null)
            {
                RSPGForm = new RSPGFormModel();
            }
            if (RSPGForm.UploadedFiles == null)
            {
                RSPGForm.UploadedFiles = new List<string>();
            }


            if (fileNames.Any())
            {
                if(RSPGForm.UploadedFiles.Count() != fileNames.Count())
                {
                    Console.WriteLine("file have been removed");
                }
            }

            // Ensure the FileUpload folder exists
            string folderName = "userID_" + RSPGForm.UserId + "_projectName_" + RSPGForm.ProjectTitle;
            string fileUploadPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "FileUpload", folderName);
            if (!Directory.Exists(fileUploadPath))
            {
                Directory.CreateDirectory(fileUploadPath);
            }

            // Process uploaded files
            if (uploadedFiles != null && uploadedFiles.Count > 0)
            {
                foreach (var file in uploadedFiles)
                {
                    if (file.Length > 0)
                    {
                        string filePath = Path.Combine(fileUploadPath, file.FileName);
                        using (var fileStream = new FileStream(filePath, FileMode.Create))
                        {
                            file.CopyTo(fileStream);
                        }
                        RSPGForm.UploadedFiles.Add(file.FileName);
                    }
                }
            }

            foreach(string file in databaseUploaded)
            {
                if(fileNames.Contains(file))
                {
                    RSPGForm.UploadedFiles.Add(file);
                }
                else
                {
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "FileUpload", folderName, file);
                    System.IO.File.Delete(filePath);
                }
            }

            // Process IRB file if required
            if (RSPGForm.RequiresIRB)
            {
                if (irbFile == null || irbFile.Length == 0)
                {
                    if(RSPGForm.IRBForm == "")
                    {
                        ModelState.AddModelError("RSPGForm.IRBForm", "IRB form is required if human or animal subjects are involved.");
                        return Page();
                    }
                }
                else
                {
                    if(RSPGForm.RSPGFormId != 0 && irbFile.FileName != RSPGForm.IRBForm && RSPGForm.IRBForm != null)
                    {
                        var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "FileUpload", folderName, RSPGForm.IRBForm);
                        System.IO.File.Delete(filePath);
                    }
                    string irbFilePath = Path.Combine(fileUploadPath, irbFile.FileName);
                    using (var irbStream = new FileStream(irbFilePath, FileMode.Create))
                    {
                        irbFile.CopyTo(irbStream);
                    }
                    RSPGForm.IRBForm = irbFile.FileName;
                }
            }

            if (RSPGForm.IsSubmitted)
            {
                TempData["SuccessMessage"] = "Your application has been submitted for review!";
                RSPGForm.IsSubmitted = true;
            }
            else
            {
                TempData["SaveMessage"] = "Your application has been saved. You can complete it later.";
            }    

                

            if (RSPGForm.RSPGFormId != 0)
            {
                UpdateForm();
            }
            else
            {
                CreateForm();
            }

            clearSessionData();
            return RedirectToPage("/Dashboard");
        }

        public IActionResult OnGetDepartments(int collegeId)
        {
            var departments = _dbContext.Department
                .Where(d => d.CollegeID == collegeId)
                .Select(d => new SelectListItem
                {
                    Value = d.DeptID.ToString(),
                    Text = d.Name
                })
                .ToList();

            return new JsonResult(departments);
        }

        private void LoadDropdowns()
        {
            Colleges = _dbContext.College
                .Select(c => new SelectListItem
                {
                    Value = c.CollegeID.ToString(),
                    Text = c.Name
                })
                .ToList();

            Users = _dbContext.User.ToList();
            Departments = new List<SelectListItem>();
        }

        /// <summary>
        /// Sets session data for the entered in form information
        /// </summary>
        /// <param name="form">Contains the information entered in from the form</param>
        /// <returns>Status code 200 if successful</returns>
        public IActionResult OnPostSaveTempForm([FromBody] TempRSPGForm form)
        {
            if (BudgetFormCreation(form))
            {
                return StatusCode(200);
            }

            return Page();
        }


        /// <summary>
        /// Creates a budgetform if one has not been created and set session data
        /// </summary>
        /// <param name="form">TempRSPGForm containing filled in form data</param>
        /// <returns>true if the form is not null false if it is</returns>
        private bool BudgetFormCreation(TempRSPGForm form)
        {
            
            if (HttpContext.Session.Get("_BudgetFormId") == null && form.formID == 0)
            {
                budgetForm = new BudgetForm();
                _dbContext.BudgetForm.Add(budgetForm);
                _dbContext.SaveChanges();
                HttpContext.Session.SetInt32("_BudgetFormId", budgetForm.BudgetFormId);
            }
            if (form != null)
            {
                SaveFormData(form);

                return true;
            }

            return false;
        }

        /// <summary>
        /// Sets up resource cards and displays the correct ones based on grant types
        /// </summary>
        private async void LoadCards(int budgetFormId)
        {
            TotalsCalc calulator = new TotalsCalc(_dbContext);
            CardTotals totals = new CardTotals();

            totals = calulator.CalcprTotals(budgetFormId);
            PrTotal = totals.Total;
            PrRRSPGTotal = totals.RSPGTotal;

            totals = calulator.CalcErTotals(budgetFormId);
            ErTotal = totals.Total;
            ErRRSPGTotal = totals.RSPGTotal;

            totals = calulator.CalcTrTotals(budgetFormId);
            TrTotal = totals.Total;
            TrRRSPGTotal = totals.RSPGTotal;

            totals = calulator.CalcOrTotals(budgetFormId);
            OrTotal = totals.Total;
            OrRRSPGTotal = totals.RSPGTotal;
        }

        private void displayCards()
        {
            // Updates the visibility of resource cards 
            if (RSPGForm.GrantType.ToLower() == "travel")
            {
                TrVisibility = "";
            }
            else
            {
                PrVisibility = "";
                TrVisibility = "";
                ErVisibility = "";
                OrVisibility = "";
            }
        }

        /// <summary>
        /// Store entered in form information into session
        /// </summary>
        /// <param name="form">TempRSPGForm containing the information from the form</param>
        private void SaveFormData(TempRSPGForm form)
        {
            HttpContext.Session.SetInt32("_formUserId", form.UserId);
            HttpContext.Session.SetInt32("_formCollegeId", form.CollegeId);
            HttpContext.Session.SetInt32("_formDepartmentId", form.DepartmentId);
            HttpContext.Session.SetString("_formProjectDirector", form.ProjectDirector);
            HttpContext.Session.SetString("_formProjectTitle", form.ProjectTitle);
            HttpContext.Session.SetString("_formMailCode", form.MailCode);
            HttpContext.Session.SetString("_formDepartmentChair", form.DepartmentChair);
            HttpContext.Session.SetString("_formDeanName", form.DeanName);
            HttpContext.Session.SetString("_formOtherParticipants", form.OtherParticipants);
            HttpContext.Session.SetString("_formProgramDirectorName", form.ProgramDirectorName);
            HttpContext.Session.SetString("_sememester", form.semester);
            HttpContext.Session.SetString("_grantType", form.grant);
            HttpContext.Session.SetString("_prVisibility", form.prVisibility);
            HttpContext.Session.SetString("_erVisibility", form.erVisibility);
            HttpContext.Session.SetString("_trVisibility", form.trVisibility);
            HttpContext.Session.SetString("_orVisibility", form.orVisibility);
        }

        /// <summary>
        /// Removes the session form related session data, saves the RSPGForm in the database
        /// and Updates the budget form RSPGformID
        /// </summary>
        private void CreateForm()
        {
      
            if (HttpContext.Session.Get("_BudgetFormId") != null)
            {
                // Saves the form in the database
                _dbContext.RSPGForm.Add(RSPGForm);
                _dbContext.SaveChanges();
                // Updates budgetForm
                budgetForm = _dbContext.BudgetForm.FirstOrDefault(b => b.BudgetFormId == (int)HttpContext.Session.GetInt32("_BudgetFormId"));
                _dbContext.Attach(budgetForm).State = EntityState.Modified;
                budgetForm.RSPGFormID = RSPGForm.RSPGFormId;
                _dbContext.SaveChanges();
            }
            else
            {
                _dbContext.RSPGForm.Add(RSPGForm);
                _dbContext.SaveChanges();
                BudgetForm budget = new BudgetForm();
                budget.RSPGFormID = RSPGForm.RSPGFormId;
                _dbContext.BudgetForm.Add(budget);
                _dbContext.SaveChanges();
                Console.WriteLine(budget.BudgetFormId);
            }
        }

        private void UpdateForm()
        {
            _dbContext.RSPGForm.Update(RSPGForm);
            if (RSPGForm.GrantType.ToLower() == "travel")
            {
                travelClearResources(RSPGForm.RSPGFormId);
            }
            _dbContext.SaveChanges();
            Console.WriteLine(RSPGForm);
        }

        /// <summary>
        /// Clears all other resources expect travel 
        /// </summary>
        private void travelClearResources(int RSPGFormID)
        {
            BudgetForm budgetForm = _dbContext.BudgetForm.FirstOrDefault(f => f.RSPGFormID == RSPGFormID);
            if(budgetForm != null)
            {
                List<PersonalResources> personalResources = _dbContext.PersonalResources.Where(r => r.BudgetFormId == budgetForm.BudgetFormId).ToList();
                _dbContext.PersonalResources.RemoveRange(personalResources);
                _dbContext.SaveChanges();
                List<EquipmentResource> equipmentResources = _dbContext.EquipmentResource.Where(r => r.BudgetFormId == budgetForm.BudgetFormId).ToList();
                _dbContext.EquipmentResource.RemoveRange(equipmentResources);
                _dbContext.SaveChanges();
                List<OtherResource> otherResources = _dbContext.OtherResource.Where(r => r.BudgetFormId == budgetForm.BudgetFormId).ToList();
                _dbContext.OtherResource.RemoveRange(otherResources);
                _dbContext.SaveChanges();
            }
            
        }

        private void clearSessionData()
        {
            HttpContext.Session.Remove("_formUserId");
            HttpContext.Session.Remove("_formCollegeId");
            HttpContext.Session.Remove("_formDepartmentId");
            HttpContext.Session.Remove("_formProjectTitle");
            HttpContext.Session.Remove("_formMailCode");
            HttpContext.Session.Remove("_formDepartmentChair");
            HttpContext.Session.Remove("_formOtherParticipants");
            HttpContext.Session.Remove("_formProgramDirectorName");
            HttpContext.Session.Remove("_formProjectDirector");
            HttpContext.Session.Remove("_sememester");
            HttpContext.Session.Remove("_grantType");
            HttpContext.Session.Remove("_prVisibility");
            HttpContext.Session.Remove("_erVisibility");
            HttpContext.Session.Remove("_trVisibility");
            HttpContext.Session.Remove("_orVisibility");
        }

        /// <summary>
        /// Helper class that stores entered in form data
        /// </summary>
        public class TempRSPGForm
        {
            public int UserId { get; set; }
            public string ProjectTitle { get; set; }
            public string ProjectDirector { get; set; }
            public int CollegeId { get; set; }
            public int DepartmentId { get; set; }
            public string MailCode { get; set; }
            public string DepartmentChair { get; set; }
            public string DeanName { get; set; }
            public string OtherParticipants { get; set; }
            public string ProgramDirectorName { get; set; }
            public string semester { get; set; }
            public string grant { get; set; }
            public string prVisibility { get; set; }
            public string erVisibility { get; set; }
            public string trVisibility { get; set; }
            public string orVisibility { get; set; }
            public int formID { get; set; }
        }

    }
}
