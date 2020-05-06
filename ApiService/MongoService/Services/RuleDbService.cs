using DataCore.Model;
using Microsoft.Extensions.Hosting;
using MongoService.Context;
using MongoService.Models;
using MongoService.Repositories;
using MongoService.Rules;
using Newtonsoft.Json;
using NRules;
using NRules.Fluent;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MongoService.Services
{
    public class RuleDbService : IHostedService, IDisposable
    {
        private readonly BatteryRepository brcontext;
        private readonly LocationRepository lrcontext;
        private readonly ApiiRepository arcontext;
        private readonly AmbientRepository ambRepcontext;

        public RuleDbService(BatteryRepository br, LocationRepository lr, ApiiRepository ar,AmbientRepository ambRep)
        {
            this.brcontext =br;
            this.lrcontext = lr;
            this.arcontext = ar;
            this.ambRepcontext = ambRep;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            DoWork(null);
            return Task.CompletedTask;
        }

        private void DoWork(object state)
        {
            var factory = new ConnectionFactory() { HostName = "172.25.124.88" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                
                channel.ExchangeDeclare(exchange: "ex5", type: "fanout");
                channel.ExchangeDeclare(exchange: "ex6", type: "fanout");
                channel.ExchangeDeclare(exchange: "ex7", type: "fanout");
                channel.ExchangeDeclare(exchange: "ex8", type: "fanout");
                var queueName = channel.QueueDeclare().QueueName;
                channel.QueueBind(queue: queueName, exchange: "ex5", routingKey: "keybat0");
                channel.QueueBind(queue: queueName, exchange: "ex6", routingKey: "keyloc0");
                channel.QueueBind(queue: queueName, exchange: "ex7", routingKey: "keyapi0");
                channel.QueueBind(queue: queueName, exchange: "ex8", routingKey: "keyamb0");

                JsonSerializerSettings settings = new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.Auto
                };

                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += (model, ea) =>
                {
                    var body = ea.Body;
                    var message = Encoding.UTF8.GetString(body);
                    Console.WriteLine(" [x] Received (AspMongo) {0}", message);
                    switch (ea.RoutingKey)
                    {
                        case "keybat0":
                            {
                                var s = JsonConvert.DeserializeObject<Battery>(message, settings);

                                var ruleRepository = new RuleRepository();
                                ruleRepository.Load(x => x.From(typeof(BatteryRule).Assembly));

                                //Compile rules
                                var ruleFactory = ruleRepository.Compile();

                                //Create a working session
                                var session = ruleFactory.CreateSession();
                                session.Insert(s);
                                session.Fire();
                                List<MongodbBattery> values = session.Query<MongodbBattery>().ToList();
                                values.ForEach(async (v) => { await brcontext.Create(v); });
                                break;
                            }
                        case "keyloc0":
                            {
                                var s = JsonConvert.DeserializeObject<Location>(message, settings);

                                var ruleRepository = new RuleRepository();
                                ruleRepository.Load(x => x.From(typeof(LocationRule).Assembly));

                                //Compile rules
                                var ruleFactory = ruleRepository.Compile();

                                //Create a working session
                                var session = ruleFactory.CreateSession();
                                session.Insert(s);
                                session.Fire();
                                List<MongodbLocation> values = session.Query<MongodbLocation>().ToList();
                                values.ForEach(async (v) => { await lrcontext.Create(v); });
                                break;
                            }
                        case "keyapi0":
                            {
                                var s = JsonConvert.DeserializeObject<Apii>(message, settings);

                                var ruleRepository = new RuleRepository();
                                ruleRepository.Load(x => x.From(typeof(ApiiRule).Assembly));

                                //Compile rules
                                var ruleFactory = ruleRepository.Compile();

                                //Create a working session
                                var session = ruleFactory.CreateSession();
                                session.Insert(s);
                                session.Fire();
                                List<MongodbApii> values = session.Query<MongodbApii>().ToList();
                                values.ForEach(async (v) => { await arcontext.Create(v); });
                                break;
                            }
                        case "keyamb0":
                            {
                                var s = JsonConvert.DeserializeObject<Ambient>(message, settings);

                                var ruleRepository = new RuleRepository();
                                ruleRepository.Load(x => x.From(typeof(AmbientRule).Assembly));

                                //Compile rules
                                var ruleFactory = ruleRepository.Compile();

                                //Create a working session
                                var session = ruleFactory.CreateSession();
                                session.Insert(s);
                                session.Fire();
                                List<MongodbAmbient> values = session.Query<MongodbAmbient>().ToList();
                                values.ForEach(async (v) => { await ambRepcontext.Create(v); });
                                break;
                            }
                        default:
                            break;
                    }
                };
                channel.BasicConsume(queue: queueName,
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
