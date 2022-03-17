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
        public int Quantity { get; set; }
        public double Price { get; set; }
        public bool? IsMissing { get; set; }

        [Key, ForeignKey("Item")]
        public Guid ItemId { get; set; }
        public virtual Item? Item { get; set; }

        [Key, ForeignKey("Order")]
        public Guid OrderId { get; set; }
        public virtual Order? Order { get; set; }
    }
}
