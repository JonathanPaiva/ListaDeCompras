using ListaDeCompras.API.Data;
using ListaDeCompras.API.Interfaces;
using ListaDeCompras.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace ListaDeCompras.API.Repositories
{
    public class AmbienteRepository : IAmbienteRepository
    {
        public readonly ApplicationDbContext _context;

        public AmbienteRepository(ApplicationDbContext context)
        {
            this._context = context; 
        }

        public async Task<Ambiente> CreateAmbienteAsync(Ambiente ambiente)
        {
            _context.Ambientes.AddAsync(ambiente);
            await _context.SaveChangesAsync();

            return ambiente;
        }

        public async Task<bool> DeleteAmbienteAsync(Guid id)
        {
            Ambiente ambiente = await GetAmbienteAsync(id);

            if (ambiente == null)
            {
                return false;
            }

            _context.Ambientes.Remove(ambiente);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<Ambiente> UpdateAmbienteAsync([FromBody] Ambiente ambiente, Guid id)
        {
            Ambiente ambienteDb = await GetAmbienteAsync(id);

            if (ambienteDb == null)
            {
                return ambienteDb;
            }

            ambienteDb.Nome = ambiente.Nome;
            ambienteDb.EditadoPor = ambiente.EditadoPor;
            ambienteDb.EditadoEm = DateTime.Now;
            ambienteDb.Desativado = ambiente.Desativado;

            await _context.SaveChangesAsync();

            return ambienteDb;
        }

        public async Task<IEnumerable<Ambiente>> GetAmbienteAsync()
        {
            IList<Ambiente> ambientes = await _context.Ambientes.ToListAsync();

            return await _context.Ambientes.ToListAsync();
        }

        public async Task<Ambiente> GetAmbienteAsync(Guid id)
        {
            Ambiente ambiente = await _context.Ambientes.FirstOrDefaultAsync(a => a.Id == id);

            return ambiente;
        }
    }
}
