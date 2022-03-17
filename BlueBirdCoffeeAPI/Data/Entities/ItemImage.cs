using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class ItemImage :BaseEntity
    {
        public byte[]? Image { get; set; }


        [ForeignKey("Item")]
        public Guid ItemId { get; set; }
        public virtual Item? Item { get; set; }
    }
}
