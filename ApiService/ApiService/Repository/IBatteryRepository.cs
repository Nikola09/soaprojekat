using DataCore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiService.Repository
{
    public interface IBatteryRepository
    {
        IEnumerable<Battery> GetBatteries();
        Battery GetBatteryByID(long batteryid);
        void InsertBattery(Battery battery);
        void DeleteBattery(long batteryId);
        void UpdateBattery(Battery battery);
        void Save();
    }
}
