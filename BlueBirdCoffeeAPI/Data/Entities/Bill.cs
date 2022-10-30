using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Bill: BaseEntity
    {
        public string? ItemMissingReason { get; set; }
        public double? Coupon { get; set; }
        public double? Discount { get; set; }
        public bool IsTakeAway { get; set; }
        public int BillNumber { get; set; }
        public double Total { get; set; }
        public string? CouponCode { get; set; }

        [ForeignKey("Casher")]
        public string? CasherId { get; set; }
        public virtual User? Casher { get; set; }

        [ForeignKey("Customer")]
        public string? CustomerId { get; set; }
        public virtual User? Customer { get; set; }
    }
}
