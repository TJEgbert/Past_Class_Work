using Microsoft.EntityFrameworkCore;
using RSPGApplication.Data;
using RSPGApplication.Models;

namespace RSPGApplication.HelperClasses
{
    public class TotalsCalc
    {
        private readonly RSPGApplicationContext _context;


        public TotalsCalc(RSPGApplicationContext context)
        {
            _context = context;
        }


        /// <summary>
        /// Calculates and formats total and RSPGTotal of the Personal Resources related to the BudgetForm
        /// </summary>
        /// <returns>CardTotals object containing totals</returns>
        public CardTotals CalcprTotals(int budgetFormID)
        {
            CardTotals cardTotals = new CardTotals();

            List<PersonalResources> resources = _context.PersonalResources.Where(r => r.BudgetFormId == budgetFormID).ToList();
            double RSPGTotal = 0.0;
            double total = 0.0;
            if (resources != null)
            {
                foreach (PersonalResources resource in resources)
                {
                    total += resource.GetGrandTotal();
                    RSPGTotal += resource.RPSGTaxTotal();
                }
                string totalString = "$";
                string RSPGString = "$";

                totalString += string.Format("{0:N2}", total);
                RSPGString += string.Format("{0:N2}", RSPGTotal);

                cardTotals.Total = totalString;
                cardTotals.RSPGTotal = RSPGString;
            }
            return cardTotals;
        }

        /// <summary>
        /// Calculates and formats total and RSPGTotal of the Equipment Resources related to the BudgetForm
        /// </summary>
        /// <returns>CardTotals object containing totals</returns>
        public CardTotals CalcErTotals(int budgetFormID)
        {
            CardTotals cardTotals = new CardTotals();

            List<EquipmentResource> resources = _context.EquipmentResource.Where(r => r.BudgetFormId == budgetFormID).ToList();
            double RSPGTotal = 0.0;
            double total = 0.0;
            if (resources != null)
            {
                foreach (EquipmentResource resource in resources)
                {
                    total += resource.GetTotal();
                    RSPGTotal += resource.RSPGTotal;
                }
                string totalString = "$";
                string RSPGString = "$";

                totalString += string.Format("{0:N2}", total);
                RSPGString += string.Format("{0:N2}", RSPGTotal);

                cardTotals.Total = totalString;
                cardTotals.RSPGTotal = RSPGString;
            }
            return cardTotals;
        }

        /// <summary>
        /// Calculates and formats total and RSPGTotal of the Travel Resources related to the BudgetForm
        /// </summary>
        /// <returns>CardTotals object containing totals</returns>
        public CardTotals CalcTrTotals(int budgetFormID)
        {
            CardTotals cardTotals = new CardTotals();

            List<TravelResource> resources = _context.TravelResource.Where(r => r.BudgetFormId == budgetFormID).ToList();
            double RSPGTotal = 0.0;
            double total = 0.0;
            if (resources != null)
            {
                foreach (TravelResource resource in resources)
                {
                    total += resource.GetTotal();
                    RSPGTotal += resource.RSPGTotal;
                }
                string totalString = "$";
                string RSPGString = "$";

                totalString += string.Format("{0:N2}", total);
                RSPGString += string.Format("{0:N2}", RSPGTotal);

                cardTotals.Total = totalString;
                cardTotals.RSPGTotal = RSPGString;
            }
            return cardTotals;
        }

        /// <summary>
        /// Calculates and formats total and RSPGTotal of the Other Resources related to the BudgetForm
        /// </summary>
        /// <returns>CardTotals object containing totals</returns>
        public CardTotals CalcOrTotals(int budgetFormID)
        {
            CardTotals cardTotals = new CardTotals();

            List<OtherResource> resources = _context.OtherResource.Where(r => r.BudgetFormId == budgetFormID).ToList();
            double RSPGTotal = 0.0;
            double total = 0.0;
            if (resources != null)
            {
                foreach (OtherResource resource in resources)
                {
                    total += resource.GetTotal();
                    RSPGTotal += resource.RSPGTotal;
                }
                string totalString = "$";
                string RSPGString = "$";

                totalString += string.Format("{0:N2}", total);
                RSPGString += string.Format("{0:N2}", RSPGTotal);

                cardTotals.Total = totalString;
                cardTotals.RSPGTotal = RSPGString;
            }
            return cardTotals;
        }

        /// <summary>
        /// Calculates the RSPG totals for a budgetForm based in the RSPGFormID that get passed in
        /// </summary>
        /// <param name="budgetFormID">The ID of the budgetForm</param>
        /// <returns></returns>
        public async Task<double> GetRSPGTotalAsync(int budgetFormID)
        {
            double total = 0;
            List<PersonalResources> personalResources = await _context.PersonalResources.Where(m => m.BudgetFormId == budgetFormID).ToListAsync();
            foreach (PersonalResources resource in personalResources)
            {
                total += resource.RPSGTaxTotal();
            }
            List<EquipmentResource> equipmentResources = await _context.EquipmentResource.Where(m => m.BudgetFormId == budgetFormID).ToListAsync();
            foreach (EquipmentResource resource in equipmentResources)
            {
                total += resource.RSPGTotal;
            }
            List<TravelResource> travelResources = await _context.TravelResource.Where(m => m.BudgetFormId == budgetFormID).ToListAsync();
            foreach (TravelResource resource in travelResources)
            {
                total += resource.RSPGTotal;
            }
            List<OtherResource> otherResources = await _context.OtherResource.Where(m => m.BudgetFormId == budgetFormID).ToListAsync();
            foreach (OtherResource resource in otherResources)
            {
                total += resource.RSPGTotal;
            }

            return total;

        }
    }
}
