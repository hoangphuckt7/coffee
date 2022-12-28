using MongoDB.Bson.Serialization.Attributes;

namespace DataCenter.Collections
{
    public class UserRole
    {
        [BsonId]
        public Guid Id { get; set; } = Guid.NewGuid();
        public string UserId { get; set; }
        public string RoleId { get; set; }
    }
}
