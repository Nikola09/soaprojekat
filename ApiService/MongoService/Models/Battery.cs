using DataCore.Model;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoService.Models
{
    public class MongodbBattery
    {
        [BsonId]
        public ObjectId InternalId { get; set; }
        public long Id { get; set; }

        public long Timestamp { get; set; }

        public int Level { get; set; }

        public float Temperature { get; set; }

        public MongodbBattery()
        {
        }
        public MongodbBattery(Battery b)
        {
            Id = b.Id;
            Timestamp = b.Timestamp;
            Level = b.Level;
            Temperature = b.Temperature;
        }
    }
}
