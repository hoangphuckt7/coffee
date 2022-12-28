using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataCenter.Collections
{
    public class Coupon : BaseMongoCollection
    {
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public int? Limit { get; set; }
        public double? Maximum { get; set; }
        public double? Minium { get; set; }
        public double? Discount { get; set; }
        public bool Default { get; set; } = false;
    }
}
