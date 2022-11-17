using ListaDeCompras.API.DTO;
using ListaDeCompras.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace ListaDeCompras.API.Interfaces
{
    public interface IItemRepository
    {
        public Task<IEnumerable<Item>> GetAsync();

        public Task<Item> GetAsync(Guid id);

        public Task<Item> CreateAsync(ItemDTO itemDTO);

        public Task<Item> UpdateAsync([FromBody] ItemDTO item, Guid id);

        public Task<bool> DeleteAsync(Guid id);
    }
}
