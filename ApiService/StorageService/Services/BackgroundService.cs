
using System.Threading;
using System.Threading.Tasks;
using System;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;
using RabbitMQ.Client.Events;
using DataCore.Model;
using StorageService.Context;

namespace StorageService.Services
{
    public class BackgroundService : IHostedService, IDisposable
    {
        private readonly DatabaseContext context;

        public BackgroundService(DatabaseContext context)
        {
            this.context = context;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            DoWork(null);
            return Task.CompletedTask;
        }

        private void DoWork(object state)
        {
            string queue = "transfer";
            var factory = new ConnectionFactory() { HostName = "172.25.124.88" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.ExchangeDeclare(exchange: "ex", type: "direct");
                channel.ExchangeDeclare(exchange: "ex2", type: "direct");
                channel.ExchangeDeclare(exchange: "ex3", type: "direct");
                channel.ExchangeDeclare(exchange: "ex4", type: "direct");

                //for sending to MongoService and NodejsService
                channel.ExchangeDeclare(exchange: "ex5", type: "fanout");//bat
                channel.ExchangeDeclare(exchange: "ex6", type: "fanout");//loc
                channel.ExchangeDeclare(exchange: "ex7", type: "fanout");//api
                channel.ExchangeDeclare(exchange: "ex8", type: "fanout");//amb

                channel.QueueDeclare(queue: queue, 
                    durable: false, 
                    exclusive: false, 
                    autoDelete: false, 
                    arguments: null);

                channel.QueueBind(queue: queue, exchange: "ex1", routingKey: "keybat");
                channel.QueueBind(queue: queue, exchange: "ex2", routingKey: "keyloc");
                channel.QueueBind(queue: queue, exchange: "ex3", routingKey: "keyapi");
                channel.QueueBind(queue: queue, exchange: "ex4", routingKey: "keyamb");

                JsonSerializerSettings settings = new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.Auto
                };

                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += (model, ea) =>
                {
                    var body = ea.Body;
                    var message = Encoding.UTF8.GetString(body);
                    Console.WriteLine(" [x] Received {0}", message);
                    switch(ea.RoutingKey)
                    {
                        case "keybat":
                            {
                                var s = JsonConvert.DeserializeObject<Battery>(message, settings);
                                context.Batteries.Add(s);
                                context.SaveChanges();

                                channel.BasicPublish(exchange: "ex5",
                                 routingKey: "keybat0",
                                 basicProperties: null,
                                 body: body);
                                break;
                            }
                        case "keyloc":
                            {
                                var s = JsonConvert.DeserializeObject<Location>(message, settings);
                                context.Locations.Add(s);
                                context.SaveChanges();

                                channel.BasicPublish(exchange: "ex6",
                                 routingKey: "keyloc0",
                                 basicProperties: null,
                                 body: body);
                                break;
                            }
                        case "keyapi":
                            {
                                var s = JsonConvert.DeserializeObject<Apii>(message, settings);
                                context.Apiis.Add(s);
                                context.SaveChanges();

                                channel.BasicPublish(exchange: "ex7",
                                 routingKey: "keyapi0",
                                 basicProperties: null,
                                 body: body);
                                break;
                            }
                        case "keyamb":
                            {
                                var s = JsonConvert.DeserializeObject<Ambient>(message, settings);
                                context.Ambients.Add(s);
                                context.SaveChanges();

                                channel.BasicPublish(exchange: "ex8",
                                 routingKey: "keyamb0",
                                 basicProperties: null,
                                 body: body);
                                break;
                            }
                        default:
                            break;
                    }
                };
                channel.BasicConsume(queue: queue,
                                 autoAck: true,
                                 consumer: consumer);

                while (true) ;
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public void Dispose()
        {
        }


    }
}
