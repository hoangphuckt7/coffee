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

        public double ChartTodateIncome { get; set; }
        public double ChartLastDateIncome { get; set; }
        public double ChartThisWeekIncome { get; set; }
        public double ChartLastWeekIncome { get; set; }
        public double ChartThisMonthIncome { get; set; }
        public double ChartLastMonthIncome { get; set; }
    }
}
