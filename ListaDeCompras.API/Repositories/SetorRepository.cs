using ListaDeCompras.API.Data;
using ListaDeCompras.API.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;

namespace ListaDeCompras.API.Repositories
{
    public class SetorRepository : ISetoresRepository
    {
        private readonly ApplicationDbContext context;

        public SetorRepository(ApplicationDbContext context)
        {
            this.context = context; 
        }

        public async Task<Setor> CreateAsync(Setor setor)
        {
            context.Setores.Add(setor);
            await context.SaveChangesAsync();

            return setor;   
        }

        public async Task DeleteAsync(Guid id)
        {
            Setor setor = context.Setores.FirstOrDefault(s => s.Id == id);

            context.Setores.Remove(setor);
            await context.SaveChangesAsync();
        }

        public async Task EditAsync(Setor setor)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<Setor>> GetAllAsync()
        {
            return await context.Setores.ToListAsync();
        }

        public async Task<Setor> GetAsync(Guid id)
        {
            Setor setor = context.Setores.FirstOrDefault(s => s.Id == id);

            return setor;
        }
    }
}
