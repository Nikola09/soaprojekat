using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataCore.Model
{
    public class Battery
    {
        public long Id { get; set; }

        public long Timestamp { get; set; }

        public int Level { get; set; }

        public float Temperature { get; set; }
    }
}
