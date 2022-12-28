using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataCenter.Collections
{
    public class Bill: BaseMongoCollection
    {
        public string? ItemMissingReason { get; set; }
        public double Coupon { get; set; }
        public double Discount { get; set; }
        public bool IsTakeAway { get; set; }
        public int BillNumber { get; set; }
        public double Total { get; set; }
        public string? CouponCode { get; set; }
        public string? CasherId { get; set; }
        public string? CustomerId { get; set; }
    }
}
