using ListaDeCompras.API.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.ObjectModel;

namespace ListaDeCompras.API.Repositories
{
    public interface ISetoresRepository
    {
        public Task<IEnumerable<Setor>> GetAsync();

        public Task<Setor> GetAsync(Guid id);

        public Task<Setor> CreateAsync(Setor setor);

        public Task<Setor> UpdateAsync([FromBody] Setor setor, Guid id);

        public Task<IResult> DeleteAsync(Guid id);
    }
}
