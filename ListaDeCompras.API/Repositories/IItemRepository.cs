using ListaDeCompras.API.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.ObjectModel;

namespace ListaDeCompras.API.Repositories
{
    public interface IItemRepository
    {
        public Task<IEnumerable<Item>> GetAsync();

        public Task<Item> GetAsync(Guid id);

        public Task<Item> CreateAsync(Item item);

        public Task<Item> UpdateAsync([FromBody] Item item, Guid id);

        public Task<bool> DeleteAsync(Guid id);
    }
}
