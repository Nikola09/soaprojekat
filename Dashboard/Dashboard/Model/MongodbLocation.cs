using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dashboard.Model
{
	class MongodbLocation
	{
        public string InternalId { get; set; }
        //public long Id { get; set; }
        public long Timestamp { get; set; }
        public float Accuracy { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public double Altitude { get; set; }
    }
}
