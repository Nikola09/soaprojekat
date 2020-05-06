using MongoDB.Bson;
using MongoDB.Driver;
using MongoService.Context;
using MongoService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MongoService.Repositories
{
    public class BatteryRepository
    {
        private readonly DatabaseContext _context;
        public BatteryRepository(DatabaseContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<MongodbBattery>> GetAllBatteries()
        {
            return await _context
                            .Batteries
                            .Find(_ => true)
                            .ToListAsync();
        }
        public Task<MongodbBattery> GetBattery(long id)
        {
            FilterDefinition<MongodbBattery> filter = Builders<MongodbBattery>.Filter.Eq(m => m.Id, id);
            return _context
                    .Batteries
                    .Find(filter)
                    .FirstOrDefaultAsync();
        }
        public async Task Create(MongodbBattery Battery)
        {
            await _context.Batteries.InsertOneAsync(Battery);
        }
        public async Task<bool> Update(MongodbBattery Battery)
        {
            ReplaceOneResult updateResult =
                await _context
                        .Batteries
                        .ReplaceOneAsync(
                            filter: g => g.Id == Battery.Id,
                            replacement: Battery);
            return updateResult.IsAcknowledged
                    && updateResult.ModifiedCount > 0;
        }
        public async Task<bool> Delete(long id)
        {
            FilterDefinition<MongodbBattery> filter = Builders<MongodbBattery>.Filter.Eq(m => m.Id, id);
            DeleteResult deleteResult = await _context
                                                .Batteries
                                              .DeleteOneAsync(filter);
            return deleteResult.IsAcknowledged
                && deleteResult.DeletedCount > 0;
        }
        public async Task<long> GetNextId()
        {
            return await _context.Batteries.CountDocumentsAsync(new BsonDocument()) + 1;
        }
    }
}
