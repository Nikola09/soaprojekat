using ApiService.Context;
using DataCore.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiService.Repository
{
    public class LocationRepository : ILocationRepository
    {
        private readonly DatabaseContext _databaseContext;

        public LocationRepository(DatabaseContext dbContext)
        {
            _databaseContext = dbContext;
        }
        public void DeleteLocation(long locationId)
        {
            var location = _databaseContext.Locations.Find(locationId);
            _databaseContext.Locations.Remove(location);
            Save();
        }

        public Location GetLocationByID(long locationId)
        {
            return _databaseContext.Locations.Find(locationId);
        }

        public IEnumerable<Location> GetLocations()
        {
            return _databaseContext.Locations.ToList();
        }

        public void InsertLocation(Location location)
        {
            _databaseContext.Add(location);
            Save();
        }

        public void Save()
        {
            _databaseContext.SaveChanges();
        }

        public void UpdateLocation(Location location)
        {
            _databaseContext.Entry(location).State = EntityState.Modified;
            Save();
        }
    }
}
