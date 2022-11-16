using ListaDeCompras.API.Data;
using ListaDeCompras.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System.Collections;
using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;

namespace ListaDeCompras.API.Repositories
{
    public class AmbienteRepository : IAmbienteRepository
    {
        public readonly ApplicationDbContext _context;

        public AmbienteRepository(ApplicationDbContext context)
        {
            this._context = context; 
        }

        public async Task<Ambiente> CreateAsync(Ambiente ambiente)
        {
            _context.Ambientes.AddAsync(ambiente);
            await _context.SaveChangesAsync();

            return ambiente;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            Ambiente ambiente = await GetAsync(id);

            if (ambiente == null)
            {
                return false;
            }

            _context.Ambientes.Remove(ambiente);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<Ambiente> UpdateAsync([FromBody] Ambiente ambiente, Guid id)
        {
            Ambiente ambienteDb = await GetAsync(id);

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

        public async Task<IEnumerable<Ambiente>> GetAsync()
        {
            IList<Ambiente> ambientes = await _context.Ambientes.ToListAsync();

            return await _context.Ambientes.ToListAsync();
        }

        public async Task<Ambiente> GetAsync(Guid id)
        {
            Ambiente ambiente = await _context.Ambientes.FirstOrDefaultAsync(a => a.Id == id);

            return ambiente;
        }
    }
}
