using System.Threading;
using System.Threading.Tasks;
using System;
using System.IO;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using DataCore.Model;
using RabbitMQ.Client;
using System.Text;

namespace CollectorService.Services
{
    public class BackgroundService : IHostedService, IDisposable
    {
        private Timer timer;
        private readonly IStorageService storageService;
        private StreamReader streamReader1;
        private StreamReader streamReader2;
        private StreamReader streamReader3;
        private StreamReader streamReader4;

        public BackgroundService(IStorageService storageService)
        {
            this.storageService = storageService;
            streamReader1 = new StreamReader("data/Hand_Battery.txt");
            streamReader2 = new StreamReader("data/Hand_Location.txt");
            streamReader3 = new StreamReader("data/Hand_API.txt");
            streamReader4 = new StreamReader("data/Hand_Ambient.txt");
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
            string lineApi = streamReader3.ReadLine();
            string lineAmbient = streamReader4.ReadLine();

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
            if (lineApi != null)
            {
                var data = lineApi.Split(' ');
                var apii = new Apii()
                {
                    Id = Convert.ToInt64(data[0]),
                    Still = Convert.ToInt32(data[3]),
                    OnFoot = Convert.ToInt32(data[4]),
                    Walking = Convert.ToInt32(data[5]),
                    Running = Convert.ToInt32(data[6]),
                    OnBicycle = Convert.ToInt32(data[7]),
                    InVehicle = Convert.ToInt32(data[8]),
                    Tilting = Convert.ToInt32(data[9]),
                    Unknown = Convert.ToInt32(data[10]),

                };

                string jsonApii = JsonConvert.SerializeObject(apii);
                JObject obj = JObject.Parse(jsonApii);
                //JObject cont = (JObject)obj[obj.Properties().ElementAt(0).Name];cont.Add("Id", Guid.NewGuid());
                storageService.addItem(obj);
            }
            if (lineAmbient != null)
            {
                var data = lineAmbient.Split(' ');
                var ambient = new Ambient()
                {
                    Id = Convert.ToInt64(data[0]),
                    Lumix = Convert.ToSingle(data[3]),
                    Temperature = Convert.ToSingle(data[4]),
                };

                string jsonAmbient = JsonConvert.SerializeObject(ambient);
                JObject obj = JObject.Parse(jsonAmbient);
                //JObject cont = (JObject)obj[obj.Properties().ElementAt(0).Name];cont.Add("Id", Guid.NewGuid());
                storageService.addItem(obj);
            }
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "hello",
                                 durable: false,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);

                string message = "Hello World!";
                var body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish(exchange: "",
                                     routingKey: "hello",
                                     basicProperties: null,
                                     body: body);
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
