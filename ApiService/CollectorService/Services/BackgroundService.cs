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

        private Battery lastBattery;
        private Location lastLocation;
        private Apii lastApii;
        private Ambient lastAmbient;

        private bool sendBat = false;
        private bool sendLoc = false;
        private bool sendApi = false;
        private bool sendAmb = false;
        private int bat_temp_treshold = 2;
        private int bat_level_treshold = 1;
        private double gps_treshold = 0.0001;
        private int confidence_treshold = 45;
        private int light_treshold = 6;



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

            sendBat = false;
            if (lineBattery != null)
            {
                var data = lineBattery.Split(' ');
                var bat = new Battery()
                {
                    Timestamp = Convert.ToInt64(data[0]),
                    Level = Convert.ToInt32(data[3]),
                    Temperature = Convert.ToSingle(data[4]),
                };

                string jsonBat = JsonConvert.SerializeObject(bat);
                JObject obj = JObject.Parse(jsonBat);
                //JObject cont = (JObject)obj[obj.Properties().ElementAt(0).Name];cont.Add("Id", Guid.NewGuid());
                storageService.addItem(obj);

                if(lastBattery != null)
                {
                    if(Math.Abs(lastBattery.Level - bat.Level) >= bat_level_treshold || Math.Abs(lastBattery.Temperature - bat.Temperature) >= bat_temp_treshold)
                    {
                        sendBat = true;
                    }
                }
                lastBattery = bat;
            }
            sendLoc = false;
            if (lineLocation != null)
            {
                var data = lineLocation.Split(' ');
                var loc = new Location()
                {
                    Timestamp = Convert.ToInt64(data[0]),
                    Accuracy = Convert.ToSingle(data[3]),
                    Latitude = Convert.ToDouble(data[4]),
                    Longitude = Convert.ToDouble(data[5]),
                    Altitude = Convert.ToDouble(data[6]),
                };

                string jsonLoc = JsonConvert.SerializeObject(loc);
                JObject obj = JObject.Parse(jsonLoc);
                storageService.addItem(obj);

                if (lastLocation != null)
                {
                    if (Math.Abs(lastLocation.Latitude - loc.Latitude) >=gps_treshold || Math.Abs(lastLocation.Longitude - loc.Longitude) >= gps_treshold)
                    {
                        sendLoc = true;
                    }
                }
                lastLocation = loc;
                
            }

            sendApi = false;
            if (lineApi != null)
            {
                var data = lineApi.Split(' ');
                var apii = new Apii()
                {
                    Timestamp = Convert.ToInt64(data[0]),
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
                if (lastApii != null)
                {
                    if (Math.Abs(lastApii.Still - apii.Still) >= confidence_treshold ||
                        Math.Abs(lastApii.OnFoot - apii.OnFoot) >= confidence_treshold ||
                        Math.Abs(lastApii.Walking - apii.Walking) >= confidence_treshold ||
                        Math.Abs(lastApii.Running - apii.Running) >= confidence_treshold ||
                        Math.Abs(lastApii.OnBicycle - apii.OnBicycle) >= confidence_treshold ||
                        Math.Abs(lastApii.InVehicle - apii.InVehicle) >= confidence_treshold ||
                        Math.Abs(lastApii.Tilting - apii.Tilting) >= confidence_treshold)
                    {
                        sendApi = true;
                    }
                }
                lastApii = apii;
                
            }

            sendAmb = false;
            if (lineAmbient != null)
            {
                var data = lineAmbient.Split(' ');
                var ambient = new Ambient()
                {
                    Timestamp = Convert.ToInt64(data[0]),
                    Lumix = Convert.ToSingle(data[3]),
                    Temperature = Convert.ToSingle(data[4]),
                };

                string jsonAmbient = JsonConvert.SerializeObject(ambient);
                JObject obj = JObject.Parse(jsonAmbient);
                //JObject cont = (JObject)obj[obj.Properties().ElementAt(0).Name];cont.Add("Id", Guid.NewGuid());
                storageService.addItem(obj);
                if (lastAmbient != null)
                {
                    if (Math.Abs(lastAmbient.Lumix -ambient.Lumix) >= light_treshold)
                    {
                        sendAmb = true;
                    }
                }
                lastAmbient = ambient;
                
            }
            //ELSE SEND = FALSE;
            if (sendBat || sendLoc || sendApi || sendAmb)
            {
                var factory = new ConnectionFactory() { HostName = "172.25.124.88"};
                using (var connection = factory.CreateConnection())
                using (var channel = connection.CreateModel())
                {
                    channel.ExchangeDeclare(exchange: "ex1", type: "direct");
                    channel.ExchangeDeclare(exchange: "ex2", type: "direct");
                    channel.ExchangeDeclare(exchange: "ex3", type: "direct");
                    channel.ExchangeDeclare(exchange: "ex4", type: "direct");

                    if(sendBat)
                    {
                        var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(lastBattery));
                        channel.BasicPublish(exchange: "ex1",
                            routingKey: "keybat",
                            basicProperties: null,
                            body: body);
                    }
                    if(sendLoc)
                    {
                        var body2 = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(lastLocation));
                        channel.BasicPublish(exchange: "ex2",
                            routingKey: "keyloc",
                            basicProperties: null,
                            body: body2);
                    }
                    if(sendApi)
                    {
                        var body3 = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(lastApii));
                        channel.BasicPublish(exchange: "ex3",
                            routingKey: "keyapi",
                            basicProperties: null,
                            body: body3);
                    }
                    if (sendAmb)
                    {
                        var body4 = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(lastAmbient));
                        channel.BasicPublish(exchange: "ex4",
                            routingKey: "keyamb",
                            basicProperties: null,
                            body: body4);
                    }
                    //var body1 = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(o)); sender
                    //JsonSerializerSettings settings = new JsonSerializerSettings
                    //{
                    //    TypeNameHandling = TypeNameHandling.Auto
                    //};
                    //var s1 = JsonConvert.DeserializeObject<GameStatus>(message, settings);  // receiver with settings
                }
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
