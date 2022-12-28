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
    public class BaseMongoCollection
    {
        [BsonId]
        public Guid Id { get; set; }
        public string? Description { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.UtcNow.AddHours(7);
        public DateTime DateUpdated { get; set; } = DateTime.UtcNow.AddHours(7);
        public bool IsDeleted { get; set; } = false;
    }
}
