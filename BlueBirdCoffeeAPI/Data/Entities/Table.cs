using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Table : BaseEntity
    {
        public bool IsAvailable { get; set; } = true;

        [ForeignKey("Floor")]
        public Guid FloorId { get; set; }
        public virtual Floor? Floor { get; set; }
    }
}
