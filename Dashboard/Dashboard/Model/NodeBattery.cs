using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dashboard.Model
{
	class NodeBattery
	{
		public string Id { get; set; }
		public long Storage_Id { get; set; }
		public long Timestamp { get; set; }

		public int Level { get; set; }

		public float Temperature { get; set; }
	}
}
