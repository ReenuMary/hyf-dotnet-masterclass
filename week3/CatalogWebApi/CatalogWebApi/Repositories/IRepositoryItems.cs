using CatalogWebApi.Entities;

namespace CatalogWebApi.Repositories
{
    public interface IRepositoryItems
    {
        Task<Item?> GetItemAsync(Guid id);
        Task<IEnumerable<Item>> GetItemsAsync();
        Task AddItemAsync(Item item);
        Task UpdateItemAsync(Item item);
        Task DeleteItemAsync(Guid id);

    }
}