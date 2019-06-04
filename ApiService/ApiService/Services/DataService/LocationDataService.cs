using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataCore.Model;
using ApiService.Repository;
using Newtonsoft.Json.Linq;

namespace ApiService.Services.DataService
{
    public class LocationDataService : IDataService
    {
        private ILocationRepository locationRepository;

        public LocationDataService(ILocationRepository locationRepository)
        {
            this.locationRepository = locationRepository;
        }
        public void Save(JObject obj)
        {
            string type = obj.Properties().ElementAt(0).Name;
            JObject data = (JObject)obj[type];

            Location l = data.ToObject<Location>();

            Location call = locationRepository.GetLocationByID(l.Id);

            if (call == null)
            {
                locationRepository.InsertLocation(l);
            }
        }

    }
}
