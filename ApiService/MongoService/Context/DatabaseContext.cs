using MongoDB.Driver;
using MongoService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MongoService.Context
{
    public class DatabaseContext
    {
        private readonly IMongoDatabase _db;
        
        public DatabaseContext(MongoDBConfig config)
        {
            //var client = new MongoClient(config.ConnectionString);
            //_db = client.GetDatabase(config.Database);
            //string username = config.User;
            //string password = config.Password;

            string mongoDbAuthMechanism = "SCRAM-SHA-1";
            MongoInternalIdentity internalIdentity =
                      new MongoInternalIdentity("admin", config.User);
            PasswordEvidence passwordEvidence = new PasswordEvidence(config.Password);
            MongoCredential mongoCredential =
                 new MongoCredential(mongoDbAuthMechanism,
                         internalIdentity, passwordEvidence);
            List<MongoCredential> credentials =
                       new List<MongoCredential>() { mongoCredential };


            MongoClientSettings settings = new MongoClientSettings();
            // comment this line below if your mongo doesn't run on secured mode
            //settings.Credentials = credentials;
            String mongoHost = config.Host;
            MongoServerAddress address = new MongoServerAddress(mongoHost);
            settings.Server = address;

            MongoClient client = new MongoClient(settings);

            _db = client.GetDatabase(config.Database);
        }
        public IMongoCollection<MongodbAmbient> Ambients => _db.GetCollection<MongodbAmbient>("Ambients");
        public IMongoCollection<MongodbApii> Apiis => _db.GetCollection<MongodbApii>("Apiis");
        public IMongoCollection<MongodbBattery> Batteries => _db.GetCollection<MongodbBattery>("Batteries");
        public IMongoCollection<MongodbLocation> Locations => _db.GetCollection<MongodbLocation>("Locations");
    }
}
