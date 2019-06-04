using System.Threading;
using System.Threading.Tasks;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using DataCore.Model;

namespace CollectorService.Services
{
    public class BackgroundService : IHostedService, IDisposable
    {
        private Timer timer;
        private readonly IStorageService storageService;
        private StreamReader streamReader1;
        private StreamReader streamReader2;

        public BackgroundService(IStorageService storageService)
        {
            this.storageService = storageService;
            streamReader1 = new StreamReader("data/Hand_Battery.txt");
            streamReader2 = new StreamReader("data/Hand_Location.txt");
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {

            timer = new Timer(DoWork, null, 0, storageService.Ttl / storageService.GetItemsNumber);

            return Task.CompletedTask;
        }

        private void DoWork(object state)
        {
            string lineBattery = streamReader1.ReadLine();
            string lineLocation = streamReader2.ReadLine();

            if (lineBattery != null)
            {
                var data = lineBattery.Split(' ');
                var bat = new Battery()
                {
                    Id = Convert.ToInt64(data[0]),
                    Level = Convert.ToInt32(data[3]),
                    Temperature = Convert.ToSingle(data[4]),
                };

                string jsonBat = JsonConvert.SerializeObject(bat);
                JObject obj = JObject.Parse(jsonBat);
                //JObject cont = (JObject)obj[obj.Properties().ElementAt(0).Name];cont.Add("Id", Guid.NewGuid());
                storageService.addItem(obj);
            }
            if (lineLocation != null)
            {
                var data = lineLocation.Split(' ');
                var loc = new Location()
                {
                    Id = Convert.ToInt64(data[0]),
                    Accuracy = Convert.ToSingle(data[3]),
                    Latitude = Convert.ToDouble(data[4]),
                    Longitude = Convert.ToDouble(data[5]),
                    Altitude = Convert.ToDouble(data[6]),
                };

                string jsonLoc = JsonConvert.SerializeObject(loc);
                JObject obj = JObject.Parse(jsonLoc);
                storageService.addItem(obj);
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            timer?.Change(Timeout.Infinite, 0);

            return Task.CompletedTask;
        }

        public void Dispose()
        {
            timer?.Dispose();
        }
    }
}
