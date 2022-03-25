using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class BartenderTask: BaseEntity
    {
        public bool IsCompleted { get; set; }

        [Key, ForeignKey("Order")]
        public Guid OrderId { get; set; }
        public virtual Order? Order { get; set; }
    }
}
