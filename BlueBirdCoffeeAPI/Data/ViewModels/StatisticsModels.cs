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
    }
}
