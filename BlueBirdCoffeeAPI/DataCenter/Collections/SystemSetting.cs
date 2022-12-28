using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataCenter.Collections
{
    public class SystemSetting
    {
        [BsonId]
        public string? Key { get; set; }
        public string? Value { get; set; }
    }
}
