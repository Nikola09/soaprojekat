using DataCore.Model;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoService.Models
{
    public class MongodbLocation
    {
        [BsonId]
        public ObjectId InternalId { get; set; }
        public long Id { get; set; }
        public long Timestamp { get; set; }
        public float Accuracy { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public double Altitude { get; set; }

        public MongodbLocation()
        {
        }
        public MongodbLocation(Location l)
        {
            Id = l.Id;
            Timestamp = l.Timestamp;
            Accuracy = l.Accuracy;
            Latitude = l.Latitude;
            Longitude = l.Longitude;
            Altitude = l.Altitude;
        }
    }
}
