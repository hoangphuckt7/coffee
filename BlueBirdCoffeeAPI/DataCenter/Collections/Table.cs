using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataCenter.Collections
{
    public class Table : BaseMongoCollection
    {
        public int CurrentOrder { get; set; } = 0;
        public string Position { get; set; }
        public string Size { get; set; }
        public string Shape { get; set; }
        public int Rotation { get; set; }
        public Guid FloorId { get; set; }
    }
}
