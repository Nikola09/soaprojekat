using DataCore.Model;
using ApiService.Repository;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiService.Services.DataService
{
    public class BatteryDataService : IDataService
    {
        private IBatteryRepository batteryRepository;

        public BatteryDataService(IBatteryRepository batteryRepository)
        {
            this.batteryRepository = batteryRepository;
        }
        public void Save(JObject obj)
        {
            string type = obj.Properties().ElementAt(0).Name;
            JObject data = (JObject)obj[type];

            Battery b = data.ToObject<Battery>();

            Battery battery = batteryRepository.GetBatteryByID(b.Id);

            if (battery == null)
            {
                batteryRepository.InsertBattery(b);
            }
        }

    }
}
