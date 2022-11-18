using ListaDeCompras.API.DTO;
using ListaDeCompras.API.Interfaces;
using ListaDeCompras.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ListaDeCompras.API.Controllers
{
    [Route("ambientes")]
    [ApiController]
    public class AmbienteController : ControllerBase
    {
        private readonly IAmbienteRepository _ambienteRepository;

        public AmbienteController(IAmbienteRepository ambienteRepository)
        {
            this._ambienteRepository = ambienteRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ambiente>>> Get()
        {
            var ambientes = await _ambienteRepository.GetAmbienteAsync();
                        
            if (ambientes == null || ambientes.Count() == 0)
            {
                return NoContent();
            }

            return Ok(ambientes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Ambiente>> Get(Guid id)
        {
            Ambiente ambiente = await _ambienteRepository.GetAmbienteAsync(id);

            if (ambiente == null)
            {
                return NotFound();
            }

            return Ok(ambiente);
        }

        [HttpPost]
        public async Task<ActionResult<Ambiente>> Create([FromBody] AmbienteDTO ambienteDTO)
        {
            Ambiente novoAmbiente = await _ambienteRepository.CreateAmbienteAsync(ambienteDTO);

            if (novoAmbiente == null)
            {
                return BadRequest();
            }

            return new CreatedResult($"ambientes/{novoAmbiente.Id}", novoAmbiente);  
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Ambiente>> UpdateAsync([FromBody] AmbienteDTO ambienteDTO, Guid id)
        {
            Ambiente ambienteDb = await _ambienteRepository.UpdateAmbienteAsync(ambienteDTO, id);

            if(ambienteDb == null)
            {
                return NotFound();
            }

            return Ok(ambienteDb);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            bool deletado;

            try
            {
                deletado = await _ambienteRepository.DeleteAmbienteAsync(id);
            }
            catch(DbUpdateException ex)
            {
                return Unauthorized();
            }
            
            if (deletado)
            {
                return Ok();
                
            }

            return NotFound();
        }
    }
}
