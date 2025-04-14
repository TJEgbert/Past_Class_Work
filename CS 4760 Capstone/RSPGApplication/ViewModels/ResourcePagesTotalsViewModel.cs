namespace RSPGApplication.ViewModels
{
    public class ResourcePagesTotalsViewModel
    {
        public int ResourceID { get; set; } = 0;
        public double BeforeTax { get; set; } = 0;
        public double Taxes { get; set; } = 0;
        public double GrandTotal { get; set; } = 0;

        public ResourcePagesTotalsViewModel(int id, double beforeTax, double taxes, double grandTotal)
        {
            ResourceID = id;
            BeforeTax = beforeTax;
            Taxes = taxes;
            GrandTotal = grandTotal;
        }

        public ResourcePagesTotalsViewModel(int id, double grandTotal)
        {
            ResourceID = id;
            GrandTotal = grandTotal;
        }
    }
}
