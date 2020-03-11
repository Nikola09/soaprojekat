
using System.Threading;
using System.Threading.Tasks;
using System;
using System.IO;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RabbitMQ.Client;
using System.Text;
using RabbitMQ.Client.Events;

namespace StorageService.Services
{
    public class BackgroundService : IHostedService, IDisposable
    {
        private Timer timer;
        private const int tperiod = 5000;

        public BackgroundService()
        {
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            //timer = new Timer(DoWork, null, 0,tperiod);
            DoWork(null);
            return Task.CompletedTask;
        }

        private void DoWork(object state)
        {
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
                //while (true) ;
                //primio = false;
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            timer?.Change(Timeout.Infinite, 0);
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            timer.Dispose();
        }


    }
}
