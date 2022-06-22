using System;
using CatalogWebApi.Entities;


namespace CatalogWebApi.Repositories;

public class InMemRepositoryItems : IRepositoryItems
{
    private readonly List<Item> items = new()
    {
        new Item { Id = Guid.NewGuid(), Name = "Potion", Price = 9, CreationDate = DateTimeOffset.Now },
        new Item { Id = Guid.NewGuid(), Name = "Iron sword", Price = 20, CreationDate = DateTimeOffset.Now },
        new Item { Id = Guid.NewGuid(), Name = "Bronze shield", Price = 18, CreationDate = DateTimeOffset.Now },
    };

    public async Task<IEnumerable<Item>> GetItemsAsync()
    {
        return  await Task.FromResult(items);
    }

    public async Task<Item?> GetItemAsync(Guid id)
    {
        var item = items.FirstOrDefault(x => x.Id == id);
        return await Task.FromResult(item);
    }

    public async Task AddItemAsync(Item item)
    {
        items.Add(item);
        await Task.CompletedTask;
    }

    public async Task UpdateItemAsync(Item item)
    {
      var index =  items.FindIndex(x => x.Id == item.Id);
        items[index] = item;
        await Task.CompletedTask;
    }

    public async Task DeleteItemAsync(Guid id)
    {
        var index = items.FindIndex(x => x.Id == id);
        items.RemoveAt(index);
        await Task.CompletedTask;
    }
}


