using ListaDeCompras.API.Data;
using ListaDeCompras.API.DTO;
using ListaDeCompras.API.Interfaces;
using ListaDeCompras.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ListaDeCompras.API.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private readonly ApplicationDbContext _context;
        private AmbienteRepository ambienteRepository;

        public ItemRepository(ApplicationDbContext context)
        {
            this._context = context; 
        }

        public async Task<Item> CreateAsync(ItemDTO itemDTO)
        {
            ambienteRepository = new AmbienteRepository(_context);

            Ambiente ambiente = await ambienteRepository.GetAmbienteAsync(itemDTO.AmbienteId); //_context.Ambientes.FindAsync(itemDTO.AmbienteId);
            
            Item novoItem = null;

            if (ambiente == null)
            {
                return novoItem;
            }

            novoItem = new Item(
                itemDTO.Nome,
                itemDTO.CriadoPor,
                itemDTO.EditadoPor,
                itemDTO.Desativado,
                itemDTO.AmbienteId
                ); 

            _context.Itens.AddAsync(novoItem);
            await _context.SaveChangesAsync();

            return novoItem;
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

        public async Task<Item> UpdateAsync([FromBody] ItemDTO item, Guid id)
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
            itemDb.AmbienteId = item.AmbienteId;

            await _context.SaveChangesAsync();

            return itemDb;
        }

        public async Task<IEnumerable<Item>> GetAsync()
        {
            IList<Item> itens = await _context.Itens.Include(i => i.Ambiente).ToListAsync();

            return itens;
        }

        public async Task<Item> GetAsync(Guid id)
        {
            Item item = await _context.Itens.FindAsync(id);

            return item;
        }
    }
}
