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
    public class AmbientRepository
    {
        private readonly DatabaseContext _context; 
        public AmbientRepository(DatabaseContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<MongodbAmbient>> GetAllAmbients()
        {
            return await _context
                            .Ambients
                            .Find(_ => true)
                            .ToListAsync();
        }
        public Task<MongodbAmbient> GetAmbient(long id)
        {
            FilterDefinition<MongodbAmbient> filter = Builders<MongodbAmbient>.Filter.Eq(m => m.Id, id);
            return _context
                    .Ambients
                    .Find(filter)
                    .FirstOrDefaultAsync();
        }
        public async Task Create(MongodbAmbient Ambient)
        {
            await _context.Ambients.InsertOneAsync(Ambient);
        }
        public async Task<bool> Update(MongodbAmbient Ambient)
        {
            ReplaceOneResult updateResult =
                await _context
                        .Ambients
                        .ReplaceOneAsync(
                            filter: g => g.Id == Ambient.Id,
                            replacement: Ambient);
            return updateResult.IsAcknowledged
                    && updateResult.ModifiedCount > 0;
        }
        public async Task<bool> Delete(long id)
        {
            FilterDefinition<MongodbAmbient> filter = Builders<MongodbAmbient>.Filter.Eq(m => m.Id, id);
            DeleteResult deleteResult = await _context
                                                .Ambients
                                              .DeleteOneAsync(filter);
            return deleteResult.IsAcknowledged
                && deleteResult.DeletedCount > 0;
        }
        public async Task<long> GetNextId()
        {
            return await _context.Ambients.CountDocumentsAsync(new BsonDocument()) + 1;
        }
    }
}
