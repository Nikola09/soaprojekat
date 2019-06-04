using ApiService.Context;
using DataCore.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiService.Repository
{
    public class BatteryRepository : IBatteryRepository
    {
        private readonly DatabaseContext _databaseContext;

        public BatteryRepository(DatabaseContext dbContext)
        {
            _databaseContext = dbContext;
        }
        public void DeleteBattery(long batteryId)
        {
            var battery = _databaseContext.Batteries.Find(batteryId);
            _databaseContext.Batteries.Remove(battery);
            Save();
        }

        public Battery GetBatteryByID(long batteryId)
        {
            return _databaseContext.Batteries.Find(batteryId);
        }

        public IEnumerable<Battery> GetBatteries()
        {
            return _databaseContext.Batteries.ToList();
        }

        public void InsertBattery(Battery battery)
        {
            _databaseContext.Add(battery);
            Save();
        }

        public void Save()
        {
            _databaseContext.SaveChanges();
        }

        public void UpdateBattery(Battery battery)
        {
            _databaseContext.Entry(battery).State = EntityState.Modified;
            Save();
        }
    }
}
