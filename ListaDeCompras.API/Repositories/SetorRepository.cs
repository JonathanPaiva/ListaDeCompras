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
    public class SetorRepository : ISetoresRepository
    {
        public readonly ApplicationDbContext _context;

        public SetorRepository(ApplicationDbContext context)
        {
            this._context = context; 
        }

        public async Task<Setor> CreateAsync(Setor setor)
        {
            _context.Setores.AddAsync(setor);
            await _context.SaveChangesAsync();

            return setor;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            Setor setor = await GetAsync(id);

            if (setor == null)
            {
                return false;
            }

            _context.Setores.Remove(setor);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<Setor> UpdateAsync([FromBody] Setor setor, Guid id)
        {
            Setor setorDb = await GetAsync(id);

            if (setorDb == null)
            {
                return setorDb;
            }

            setorDb.Nome = setor.Nome;
            setorDb.EditadoPor = setor.EditadoPor;
            setorDb.EditadoEm = DateTime.Now;
            setorDb.Desativado = setor.Desativado;

            await _context.SaveChangesAsync();

            return setorDb;
        }

        public async Task<IEnumerable<Setor>> GetAsync()
        {
            IList<Setor> setores = await _context.Setores.ToListAsync();

            return await _context.Setores.ToListAsync();
        }

        public async Task<Setor> GetAsync(Guid id)
        {
            Setor setor = await _context.Setores.FirstOrDefaultAsync(s => s.Id == id);

            return setor;
        }
    }
}
