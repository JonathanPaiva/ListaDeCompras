using ListaDeCompras.API.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.ObjectModel;

namespace ListaDeCompras.API.Repositories
{
    public interface IAmbienteRepository
    {
        public Task<IEnumerable<Ambiente>> GetAsync();

        public Task<Ambiente> GetAsync(Guid id);

        public Task<Ambiente> CreateAsync(Ambiente ambiente);

        public Task<Ambiente> UpdateAsync([FromBody] Ambiente ambiente, Guid id);

        public Task<bool> DeleteAsync(Guid id);
    }
}
