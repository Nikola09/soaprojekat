using DataCore.Model;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoService.Models
{
    public class MongodbAmbient
    {
        [BsonId]
        public ObjectId InternalId { get; set; }
        public long Id { get; set; }
        public long Timestamp { get; set; }
        public float Lumix { get; set; }
        public float Temperature { get; set; }

        public MongodbAmbient() 
        { 
        }
        public MongodbAmbient(Ambient a)
        {
            Id = a.Id;
            Timestamp = a.Timestamp;
            Lumix = a.Lumix;
            Temperature = a.Temperature;
        }
    }
}
