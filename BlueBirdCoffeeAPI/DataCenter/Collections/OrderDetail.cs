using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataCenter.Collections
{
    public class OrderDetail
    {
        [BsonId]
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime DateUpdated { get; set; } = DateTime.UtcNow.AddHours(7);
        public int Quantity { get; set; }
        public int FinalQuantity { get; set; }
        public string? MissingReason { get; set; }
        public double Price { get; set; }
        public string? Description { get; set; }
        public Guid ItemId { get; set; }
        public Guid OrderId { get; set; }
    }
}
