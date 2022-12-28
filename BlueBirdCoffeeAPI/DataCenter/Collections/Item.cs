using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataCenter.Collections
{
    public class Item : BaseMongoCollection
    {
        public string? Name { get; set; }
        public double Price { get; set; }
        public bool Available { get; set; } = true;

        public Guid CategoryId { get; set; }
    }
}
