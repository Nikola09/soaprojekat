using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataCore.Model
{
    public class Location
    {
        public long Id { get; set; }

        public float Accuracy { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public double Altitude{ get; set; }
}
}
