using ListaDeCompras.API.Data;
using ListaDeCompras.API.DTO;
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

        public async Task<Ambiente> CreateAmbienteAsync(AmbienteDTO ambienteDTO)
        {
            Ambiente novoAmbiente = new Ambiente(
                ambienteDTO.Nome,
                ambienteDTO.CriadoPor,
                ambienteDTO.EditadoPor,
                ambienteDTO.Desativado
                );

            _context.Ambientes.AddAsync(novoAmbiente);
            await _context.SaveChangesAsync();

            return novoAmbiente;
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

        public async Task<Ambiente> UpdateAmbienteAsync([FromBody] AmbienteDTO ambienteDTO, Guid id)
        {
            Ambiente ambienteDb = await GetAmbienteAsync(id);

            if (ambienteDb == null)
            {
                return ambienteDb;
            }

            ambienteDb.SetNome(ambienteDTO.Nome);
            ambienteDb.SetEditado(ambienteDTO.EditadoPor);
            ambienteDb.SetDesativado(ambienteDTO.Desativado);

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
