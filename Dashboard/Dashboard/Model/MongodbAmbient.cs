﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dashboard.Model
{
	class MongodbAmbient
	{
		public string InternalId { get; set; }
		//public long Id { get; set; }
		public long Timestamp { get; set; }
		public float Lumix { get; set; }
		public float Temperature { get; set; }
	}
}