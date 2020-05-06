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
    public class ApiiRepository
    {
        private readonly DatabaseContext _context;
        public ApiiRepository(DatabaseContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<MongodbApii>> GetAllApiis()
        {
            return await _context
                            .Apiis
                            .Find(_ => true)
                            .ToListAsync();
        }
        public Task<MongodbApii> GetApii(long id)
        {
            FilterDefinition<MongodbApii> filter = Builders<MongodbApii>.Filter.Eq(m => m.Id, id);
            return _context
                    .Apiis
                    .Find(filter)
                    .FirstOrDefaultAsync();
        }
        public async Task Create(MongodbApii Apii)
        {
            await _context.Apiis.InsertOneAsync(Apii);
        }
        public async Task<bool> Update(MongodbApii Apii)
        {
            ReplaceOneResult updateResult =
                await _context
                        .Apiis
                        .ReplaceOneAsync(
                            filter: g => g.Id == Apii.Id,
                            replacement: Apii);
            return updateResult.IsAcknowledged
                    && updateResult.ModifiedCount > 0;
        }
        public async Task<bool> Delete(long id)
        {
            FilterDefinition<MongodbApii> filter = Builders<MongodbApii>.Filter.Eq(m => m.Id, id);
            DeleteResult deleteResult = await _context
                                                .Apiis
                                              .DeleteOneAsync(filter);
            return deleteResult.IsAcknowledged
                && deleteResult.DeletedCount > 0;
        }
        public async Task<long> GetNextId()
        {
            return await _context.Apiis.CountDocumentsAsync(new BsonDocument()) + 1;
        }
    }
}
