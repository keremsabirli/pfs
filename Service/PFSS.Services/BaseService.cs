using MongoDB.Driver;
using PFSS.Models;
using PrivateFileStorageService;
using PFSS.Models;
using System;
using System.Collections.Generic;
using MongoDB.Bson;
using System.Linq.Expressions;

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
        public virtual T Add(T entity)
        {
            collection.InsertOne(entity);
            return entity;
        }
        public virtual IList<T> Get()
        {
            return collection.Find(x => true).ToList();
        }
        public virtual T Get(string id)
        {
            return collection.Find(x => x.Id == id).SingleOrDefault();
        }
        public virtual IList<T> Get(Expression<Func<T, bool>> expression)
        {
            return collection.Find(expression).ToList();
        }
        public virtual void Update(T entity)
        {
            collection.ReplaceOne(x => x.Id == entity.Id, entity);
        }
        public virtual void UpdateAndGet(T entity)
        {
            collection.FindOneAndReplace(x => x.Id == entity.Id, entity);
        }
        public virtual void Delete(string id)
        {
            collection.DeleteOne(sub => sub.Id == id);
        }
    }
}
