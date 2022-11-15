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

        public async Task<ActionResult<Setor>> CreateAsync(Setor setor)
        {
            _context.Setores.AddAsync(setor);
            await _context.SaveChangesAsync();

            return new CreatedResult($"setores/{setor.Id}", setor);
        }

        public async Task<ActionResult> DeleteAsync(Guid id)
        {
            Setor setor = _context.Setores.FirstOrDefault(s => s.Id == id);

            if (setor == null)
            {
                return new NotFoundResult();
            }

            _context.Setores.Remove(setor);
            await _context.SaveChangesAsync();

            return new OkResult();
        }

        public async Task<ActionResult<Setor>> UpdateAsync([FromBody] Setor setor, Guid id)
        {
            Setor setorDb = await _context.Setores.FirstOrDefaultAsync(s => s.Id == id);

            if (setorDb == null)
            {
                return new NotFoundResult();
            }

            setorDb.Nome = setor.Nome;
            setorDb.EditadoPor = setor.EditadoPor;
            setorDb.EditadoEm = DateTime.Now;
            setorDb.Desativado = setor.Desativado;

            await _context.SaveChangesAsync();

            return setorDb;
        }

        public async Task<ActionResult<IEnumerable<Setor>>> GetAsync()
        {
            IList<Setor> setores = await _context.Setores.ToListAsync();

            if(setores == null || setores.Count == 0)
            {
                return new NoContentResult();
            }

            return await _context.Setores.ToListAsync();
        }

        public async Task<ActionResult<Setor>> GetAsync(Guid id)
        {
            Setor setor = await _context.Setores.FirstOrDefaultAsync(s => s.Id == id);

            if (setor == null)
            {
                return new NotFoundResult();
            }

            return setor;
        }
    }
}
