using ListaDeCompras.API.Data;
using ListaDeCompras.API.Models;
using Microsoft.AspNetCore.Mvc;
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

        public async Task<IResult> DeleteAsync(Guid id)
        {
            Setor setor = _context.Setores.FirstOrDefault(s => s.Id == id);

            if (setor == null)
            {
                return Results.NotFound();
            }

            _context.Setores.Remove(setor);
            await _context.SaveChangesAsync();

            return Results.Ok();
        }

        public async Task<Setor> UpdateAsync([FromBody] Setor setor, Guid id) //[FromBody] Setor setor
        {
            Setor setorDb = await _context.Setores.FirstOrDefaultAsync(s => s.Id == id);

            setorDb.Nome = setor.Nome;
            setorDb.EditadoPor = setor.EditadoPor;
            setorDb.EditadoEm = DateTime.Now;
            setorDb.Desativado = setor.Desativado;

            await _context.SaveChangesAsync();

            return setorDb;
        }

        public async Task<IEnumerable<Setor>> GetAsync()
        {
            return await _context.Setores.ToListAsync();
        }

        public async Task<Setor> GetAsync(Guid id)
        {
            Setor setor = await _context.Setores.FirstOrDefaultAsync(s => s.Id == id);

            return setor;
        }
    }
}
