using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dashboard.Model
{
	class NodeLocation
	{
        public string Id { get; set; }
        //public long Storage_Id { get; set; }
        public long Timestamp { get; set; }
        public float Accuracy { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public double Altitude { get; set; }
    }
}
