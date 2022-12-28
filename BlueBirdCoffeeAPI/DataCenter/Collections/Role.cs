using MongoDB.Bson.Serialization.Attributes;

namespace DataCenter.Collections
{
    public class Role
    {
        [BsonId]
        public string Id { get; set; }
        public string Name { get; set; }
        public string NormalizedName { get; set; }
        public string ConcurrencyStamp { get; set; }
    }
}
