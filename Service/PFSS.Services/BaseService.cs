using MongoDB.Driver;
using PFSS.Models;
using PrivateFileStorageService;
using System;
using System.Collections.Generic;
using MongoDB.Bson;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PFSS.Services
{
    public class BaseService<T> where T: Shared
    {
        protected readonly IMongoCollection<T> collection;
        protected readonly IMongoDatabase database;
        public BaseService(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            database = client.GetDatabase(settings.DatabaseName);
            collection = database.GetCollection<T>(typeof(T).Name);
        }
        public async virtual Task<T> Add(T entity)
        {
            await collection.InsertOneAsync(entity);
            return entity;
        }
        public async virtual Task<IList<T>> GetAll()
        {
            return await collection.FindAsync(x => true).Result.ToListAsync();
        }
        public async virtual Task<T> GetById(string id)
        {
            return await collection.FindAsync(x => x.Id == id).Result.SingleOrDefaultAsync();
        }
        public async virtual Task<IList<T>> GetByCondition(Expression<Func<T, bool>> expression)
        {
            return await collection.FindAsync(expression).Result.ToListAsync();
        }
        public async virtual Task Update(T entity)
        {
            await collection.ReplaceOneAsync(x => x.Id == entity.Id, entity, new ReplaceOptions());
        }
        public async virtual Task UpdateAndGet(T entity)
        {
            await collection.FindOneAndReplaceAsync(x => x.Id == entity.Id, entity);
        }
        public async virtual Task Delete(string id)
        {
            await collection.DeleteOneAsync(sub => sub.Id == id);
        }
    }
}
