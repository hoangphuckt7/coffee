using MongoDB.Bson.Serialization.Attributes;

namespace DataCenter.Collections
{
    public class BackupDate
    {
        [BsonId]
        public Guid Id { get; set; }
        public DateTime? LastBackupDate { get; set; }
    }
}
