using System;
using CatalogWebApi.Entities;
using MongoDB.Bson;
using MongoDB.Driver;

namespace CatalogWebApi.Repositories
{
	public class mongoDbItemsRepository :IInMemRepositoryItems
	{
        private const string databaseName = "catalog";
        private const string collectionName = "items";
        private readonly IMongoCollection<Item> itemsCollection;
        private readonly FilterDefinitionBuilder<Item> filterBuilder = Builders<Item>.Filter;


        public mongoDbItemsRepository(IMongoClient mongoClient)
		{
            IMongoDatabase database = mongoClient.GetDatabase(databaseName);
            itemsCollection = database.GetCollection<Item>(collectionName);
		}

        public void AddItem(Item item)
        {
            itemsCollection.InsertOne(item);
        }

        public void DeleteItem(Guid id)
        {
            throw new NotImplementedException();
        }

        public Item? GetItem(Guid id)
        {
           var filter = filterBuilder.Eq(x => x.Id, id);
            return itemsCollection.Find(filter).SingleOrDefault();
        }

        public IEnumerable<Item> GetItems()
        {
            return itemsCollection.Find(new BsonDocument()).ToList();
        }

        public void UpdateItem(Item item)
        {
            var filter = filterBuilder.Eq(x => x.Id, item.Id);
            itemsCollection.FindOneAndReplace(filter, item);
        }
    }
}

