using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataCenter.Collections
{
    public class ItemImage :BaseMongoCollection
    {
        public byte[]? Image { get; set; }
        public Guid ItemId { get; set; }
    }
}
