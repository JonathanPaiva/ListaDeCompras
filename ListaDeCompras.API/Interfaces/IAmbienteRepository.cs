using ListaDeCompras.API.DTO;
using ListaDeCompras.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace ListaDeCompras.API.Interfaces
{
    public interface IAmbienteRepository
    {
        public Task<IEnumerable<Ambiente>> GetAmbienteAsync();

        public Task<Ambiente> GetAmbienteAsync(Guid id);

        public Task<Ambiente> CreateAmbienteAsync(AmbienteDTO ambiente);

        public Task<Ambiente> UpdateAmbienteAsync([FromBody] AmbienteDTO ambienteDTO, Guid id);

        public Task<bool> DeleteAmbienteAsync(Guid id);
    }
}
