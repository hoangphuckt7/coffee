using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Item : BaseEntity
    {
        public string? Name { get; set; }
        public double Price { get; set; }
        public bool Available { get; set; } = true;

        [ForeignKey("Category")]
        public Guid CategoryId { get; set; }
        public virtual Category? Category { get; set; }
    }
}
