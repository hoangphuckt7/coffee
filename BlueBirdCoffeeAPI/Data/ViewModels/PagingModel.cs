using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.ViewModels
{
    public class PagingModel
    {
        public object Data { get; set; } = null!;
        public int Total { get; set; }
    }

    public class BilPagingModel
    {
        public object Data { get; set; } = null!;
        public int Total { get; set; }
        public double Income { get; set; }
        public double EstimateIncome { get; set; }
    }
}
