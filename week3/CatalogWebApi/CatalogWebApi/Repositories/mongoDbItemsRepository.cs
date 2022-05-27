﻿using System;
using CatalogWebApi.Entities;
using MongoDB.Driver;

namespace CatalogWebApi.Repositories
{
	public class mongoDbItemsRepository :IInMemRepositoryItems
	{
        private const string databaseName = "catalog";
        private const string collectionName = "items";
        private readonly IMongoCollection<Item> itemsCollection;


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
            throw new NotImplementedException();
        }

        public IEnumerable<Item> GetItems()
        {
            throw new NotImplementedException();
        }

        public void UpdateItem(Item item)
        {
            throw new NotImplementedException();
        }
    }
}

