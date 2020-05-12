using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dashboard.Model
{
	class MongodbApii
	{
        public string InternalId { get; set; }
        //public long Id { get; set; }
        public long Timestamp { get; set; }
        public int Still { get; set; }
        public int OnFoot { get; set; }
        public int Walking { get; set; }
        public int Running { get; set; }
        public int OnBicycle { get; set; }
        public int InVehicle { get; set; }
        public int Tilting { get; set; }
        public int Unknown { get; set; }
    }
}
