using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.ViewModels
{
    public class StatisticsModels
    {
        public string BestSellerItemName { get; set; }
        public int BestSellerCount { get; set; }
        public double Income { get; set; }

        public string BestSellerLastMonthItemName { get; set; }
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
