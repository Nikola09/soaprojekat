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

namespace ApiService.Services
{
    public class BackgroundService : IHostedService , IDisposable
    {
        private readonly IHttpClientFactory clientFactory;
        private readonly IConfiguration configuration;
        private readonly IServiceProvider serviceProvider;
        private BackgroundTimer backgroundTimer;

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

        private async void DoWork(object state)
        {

            string baseUrl = "http://127.0.0.1:46385"; 
            var request = new HttpRequestMessage(HttpMethod.Get,
                baseUrl + "/api/data");

                var client = clientFactory.CreateClient();

                var response = await client.SendAsync(request);
            
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
