using CatalogWebApi.Entities;

namespace CatalogWebApi.Repositories
{
    public interface IInMemRepositoryItems
    {
        Item? GetItem(Guid id);
        IEnumerable<Item> GetItems();
        void AddItem(Item item);
        void UpdateItem(Item item);
        void DeleteItem(Guid id);

    }
}