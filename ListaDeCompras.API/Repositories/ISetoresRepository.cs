using ListaDeCompras.API.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.ObjectModel;

namespace ListaDeCompras.API.Repositories
{
    public interface ISetoresRepository
    {
        public Task<ActionResult<IEnumerable<Setor>>> GetAsync();

        public Task<ActionResult<Setor>> GetAsync(Guid id);

        public Task<ActionResult<Setor>> CreateAsync(Setor setor);

        public Task<ActionResult<Setor>> UpdateAsync([FromBody] Setor setor, Guid id);

        public Task<ActionResult> DeleteAsync(Guid id);
    }
}
