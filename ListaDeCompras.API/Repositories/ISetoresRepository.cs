using ListaDeCompras.API.Models;
using System.Collections.ObjectModel;

namespace ListaDeCompras.API.Repositories
{
    public interface ISetoresRepository
    {
        Task<ICollection<Setor>> GetAllAsync();

        Task<Setor> GetAsync(Guid id);

        Task<Setor> CreateAsync(Setor setor);

        Task EditAsync(Setor setor);

        Task DeleteAsync(Guid id);
    }
}
