using ListaDeCompras.API.Data;
using ListaDeCompras.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ListaDeCompras.API.Repositories
{
    public class ItemRepository : IItemRepository
    {
        public readonly ApplicationDbContext _context;

        public ItemRepository(ApplicationDbContext context)
        {
            this._context = context; 
        }

        public async Task<Item> CreateAsync(Item item)
        {
            _context.Itens.AddAsync(item);
            await _context.SaveChangesAsync();

            return item;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            Item item = await GetAsync(id);

            if (item == null)
            {
                return false;
            }

            _context.Itens.Remove(item);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<Item> UpdateAsync([FromBody] Item item, Guid id)
        {
            Item itemDb = await GetAsync(id);

            if (itemDb == null)
            {
                return itemDb;
            }

            itemDb.Nome = item.Nome;
            itemDb.EditadoPor = item.EditadoPor;
            itemDb.EditadoEm = DateTime.Now;
            itemDb.Desativado = item.Desativado;

            await _context.SaveChangesAsync();

            return itemDb;
        }

        public async Task<IEnumerable<Item>> GetAsync()
        {
            IList<Item> itens = await _context.Itens
                .ToListAsync();

            return await _context.Itens.ToListAsync();
        }

        public async Task<Item> GetAsync(Guid id)
        {
            Item item = await _context.Itens
                .FirstOrDefaultAsync(i=> i.Id == id)
                ;

            return item;
        }
    }
}
