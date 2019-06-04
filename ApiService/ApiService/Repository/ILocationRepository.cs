using DataCore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiService.Repository
{
    public interface ILocationRepository
    {
        IEnumerable<Location> GetLocations();
        Location GetLocationByID(long locationid);
        void InsertLocation(Location location);
        void DeleteLocation(long locationId);
        void UpdateLocation(Location location);
        void Save();
    }
}
