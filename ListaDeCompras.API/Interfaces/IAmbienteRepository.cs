using ListaDeCompras.API.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.ObjectModel;

namespace ListaDeCompras.API.Interfaces
{
    public interface IAmbienteRepository
    {
        public Task<IEnumerable<Ambiente>> GetAmbienteAsync();

        public Task<Ambiente> GetAmbienteAsync(Guid id);

        public Task<Ambiente> CreateAmbienteAsync(Ambiente ambiente);

        public Task<Ambiente> UpdateAmbienteAsync([FromBody] Ambiente ambiente, Guid id);

        public Task<bool> DeleteAmbienteAsync(Guid id);
    }
}
