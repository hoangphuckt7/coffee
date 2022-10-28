using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Coupon : BaseEntity
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
