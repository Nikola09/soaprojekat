using System;
using System.Collections.Generic;
using System.Text;

namespace DataCore.Model
{
    public class Apii
    {
        public long Id { get; set; }
        public int Still { get; set; } // confidence %
        public int OnFoot { get; set; } // confidence %
        public int Walking { get; set; } // confidence %
        public int Running { get; set; } // confidence %
        public int OnBicycle { get; set; } // confidence %
        public int InVehicle { get; set; } // confidence %
        public int Tilting { get; set; } // confidence %
        public int Unknown { get; set; } // confidence %
    }
}
