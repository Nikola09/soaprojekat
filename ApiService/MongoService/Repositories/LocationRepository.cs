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
    public class LocationRepository
    {
        private readonly DatabaseContext _context;
        public LocationRepository(DatabaseContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<MongodbLocation>> GetAllLocations()
        {
            return await _context
                            .Locations
                            .Find(_ => true)
                            .ToListAsync();
        }
        public Task<MongodbLocation> GetLocation(long id)
        {
            FilterDefinition<MongodbLocation> filter = Builders<MongodbLocation>.Filter.Eq(m => m.Id, id);
            return _context
                    .Locations
                    .Find(filter)
                    .FirstOrDefaultAsync();
        }
        public async Task Create(MongodbLocation Location)
        {
            await _context.Locations.InsertOneAsync(Location);
        }
        public async Task<bool> Update(MongodbLocation Location)
        {
            ReplaceOneResult updateResult =
                await _context
                        .Locations
                        .ReplaceOneAsync(
                            filter: g => g.Id == Location.Id,
                            replacement: Location);
            return updateResult.IsAcknowledged
                    && updateResult.ModifiedCount > 0;
        }
        public async Task<bool> Delete(long id)
        {
            FilterDefinition<MongodbLocation> filter = Builders<MongodbLocation>.Filter.Eq(m => m.Id, id);
            DeleteResult deleteResult = await _context
                                                .Locations
                                              .DeleteOneAsync(filter);
            return deleteResult.IsAcknowledged
                && deleteResult.DeletedCount > 0;
        }
        public async Task<long> GetNextId()
        {
            return await _context.Locations.CountDocumentsAsync(new BsonDocument()) + 1;
        }
    }
}
