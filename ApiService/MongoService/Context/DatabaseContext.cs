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
            var client = new MongoClient(config.ConnectionString);
            _db = client.GetDatabase(config.Database);
        }
        public IMongoCollection<MongodbAmbient> Ambients => _db.GetCollection<MongodbAmbient>("Ambients");
        public IMongoCollection<MongodbApii> Apiis => _db.GetCollection<MongodbApii>("Apiis");
        public IMongoCollection<MongodbBattery> Batteries => _db.GetCollection<MongodbBattery>("Batteries");
        public IMongoCollection<MongodbLocation> Locations => _db.GetCollection<MongodbLocation>("Locations");
    }
}
