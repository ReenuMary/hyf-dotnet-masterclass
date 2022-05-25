using System;
using CatalogWebApi.Entities;


namespace CatalogWebApi.Repositories;

public class InMemRepositoryItems : IInMemRepositoryItems
{
    private readonly List<Item> items = new()
    {
        new Item { Id = Guid.NewGuid(), Name = "Potion", Price = 9, CreationDate = DateTimeOffset.Now },
        new Item { Id = Guid.NewGuid(), Name = "Iron sword", Price = 20, CreationDate = DateTimeOffset.Now },
        new Item { Id = Guid.NewGuid(), Name = "Bronze shield", Price = 18, CreationDate = DateTimeOffset.Now },
    };

    public IEnumerable<Item> GetItems()
    {
        return items;
    }

    public Item? GetItem(Guid id)
    {
        return items.FirstOrDefault(x => x.Id == id);
    }

    public void AddItem(Item item)
    {
        items.Add(item);
    }

    public void UpdateItem(Item item)
    {
      var index =  items.FindIndex(x => x.Id == item.Id);
        items[index] = item;
    }

    public void DeleteItem(Guid id)
    {
        var index = items.FindIndex(x => x.Id == id);
        items.RemoveAt(index);
    }
}


