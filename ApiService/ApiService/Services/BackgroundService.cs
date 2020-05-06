using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using ApiService.Services.DataService;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace ApiService.Services
{
    public class BackgroundService : IHostedService , IDisposable
    {
        private readonly IHttpClientFactory clientFactory;
        private readonly IConfiguration configuration;
        private readonly IServiceProvider serviceProvider;
        private BackgroundTimer backgroundTimer;
        static readonly HttpClient client2 = new HttpClient();

        public BackgroundService(IConfiguration configuration, IHttpClientFactory clientFactory, IServiceProvider serviceProvider, BackgroundTimer backgroundTimer)
        {
            this.configuration = configuration;
            this.clientFactory = clientFactory;
            this.serviceProvider = serviceProvider;
            this.backgroundTimer = backgroundTimer;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            backgroundTimer.setCallback(DoWork);

            return Task.CompletedTask;
        }

        private void DoWork(object state)
        {

            /*string baseUrl = "https://localhost:5000"; //"https://localhost:42385"; 
            var request = new HttpRequestMessage(HttpMethod.Get,
                baseUrl + "/api/data");

                //var client = clientFactory.CreateClient();
           

            //var response = await client.GetAsync(request.RequestUri);
            HttpResponseMessage response = await client2.GetAsync(baseUrl + "/api/data");
            response.EnsureSuccessStatusCode();

            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsAsync<IEnumerable<JObject>>();

                using (var scope = serviceProvider.CreateScope())
                {
                    foreach (JObject obj in data)
                    {
                        int numElem = obj.Properties().Count();
                        IDataService dataService = null;

                        if(numElem == 3)
                        {
                            dataService = scope.ServiceProvider.GetService<BatteryDataService>();
                        }
                        else if(numElem == 5)
                        {
                            dataService = scope.ServiceProvider.GetService<LocationDataService>();
                        }

                        if (dataService != null)
                        {
                            dataService.Save(obj);
                        }
                    }
                }
            }*/
            bool primio = false;
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "hello",
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += (model, ea) =>
                {
                    var body = ea.Body;
                    var message = Encoding.UTF8.GetString(body);
                    Console.WriteLine(" [x] Received {0}", message);
                    primio = true;
                };
                channel.BasicConsume(queue: "hello",
                                     autoAck: true,
                                     consumer: consumer);

                while (!primio) ;
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            backgroundTimer.stopTimer();

            return Task.CompletedTask;
        }

        public void Dispose()
        {
            backgroundTimer.Dispose();
        }
    }
}
