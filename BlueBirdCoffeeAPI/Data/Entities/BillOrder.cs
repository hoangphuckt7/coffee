using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class BillOrder
    {
        [Key, ForeignKey("Order")]
        public Guid OrderId { get; set; }
        public virtual Order? Order { get; set; }

        [Key, ForeignKey("Bill")]
        public Guid BillId { get; set; }
        public virtual Bill? Bill { get; set; }
    }
}
