using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class OrderDetail
    {
        public DateTime DateUpdated { get; set; } = DateTime.UtcNow.AddHours(7);

        public int Quantity { get; set; }
        public int FinalQuantity { get; set; }
        public string? MissingReason { get; set; }

        public double Price { get; set; }
        public string? Description { get; set; }

        [Key, ForeignKey("Item")]
        public Guid ItemId { get; set; }
        public virtual Item? Item { get; set; }

        [Key, ForeignKey("Order")]
        public Guid OrderId { get; set; }
        public virtual Order? Order { get; set; }
    }
}
