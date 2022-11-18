using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Order : BaseEntity
    {
        public int OrderNumber { get; set; }
        public bool IsCompleted { get; set; } = false;
        public bool IsCheckout { get; set; } = false;
        public bool IsRejected { get; set; } = false;
        public bool IsMissing { get; set; } = false;

        public string? RejectedReason { get; set; }

        [ForeignKey("Table")]
        public Guid? TableId { get; set; }
        public virtual Table? Table { get; set; }

        [ForeignKey("Employee")]
        public string? EmployeeId { get; set; }
        public virtual User? Employee { get; set; }

        [ForeignKey("Bartender")]
        public string? BartenderId { get; set; }
        public virtual User? Bartender { get; set; }

        [ForeignKey("UserRejected")]
        public string? UserRejectedId { get; set; }
        public virtual User? UserRejected { get; set; }

        public virtual List<OrderDetail>? OrderDetails { get; set; }
    }
}
