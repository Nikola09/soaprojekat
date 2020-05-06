using DataCore.Model;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoService.Models
{
    public class MongodbApii
    {
        [BsonId]
        public ObjectId InternalId { get; set; }
        public long Id { get; set; }
        public long Timestamp { get; set; }
        public int Still { get; set; } // confidence %
        public int OnFoot { get; set; } // confidence %
        public int Walking { get; set; } // confidence %
        public int Running { get; set; } // confidence %
        public int OnBicycle { get; set; } // confidence %
        public int InVehicle { get; set; } // confidence %
        public int Tilting { get; set; } // confidence %
        public int Unknown { get; set; } // confidence %

        public MongodbApii()
        {
        }
        public MongodbApii(Apii a)
        {
            Id = a.Id;
            Timestamp = a.Timestamp;
            Still = a.Still;
            OnFoot = a.OnFoot;
            Walking = a.Walking;
            Running = a.Running;
            OnBicycle = a.OnBicycle;
            InVehicle = a.InVehicle;
            Tilting = a.Tilting;
            Unknown = a.Unknown;

        }
    }
}
