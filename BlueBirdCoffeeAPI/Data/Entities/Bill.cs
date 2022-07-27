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
        [ForeignKey("Order")]
        public Guid OrderId { get; set; }
        public virtual Order? Order { get; set; }

        public string? ItemMissingReason { get; set; }


        [ForeignKey("Casher")]
        public string? CasherId { get; set; }
        public virtual User? Casher { get; set; }

        [ForeignKey("Customer")]
        public string? CustomerId { get; set; }
        public virtual User? Customer { get; set; }

        public bool? IsFinalBill { get; set; }
    }
}
