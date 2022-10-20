namespace AdminManager.Models
{
    public class StatisticsModels
    {
        public string BestSellerItemName { get; set; } = null!;
        public int BestSellerCount { get; set; }
        public double Income { get; set; }

        public string BestSellerLastMonthItemName { get; set; } = null!;
        public int BestSellerLastMonthCount { get; set; }
        public double IncomeLastMonth { get; set; }
    }
}
