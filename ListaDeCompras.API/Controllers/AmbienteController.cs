using ListaDeCompras.API.Models;
using ListaDeCompras.API.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

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
            var ambientes = await _ambienteRepository.GetAsync();
                        
            if (ambientes == null || ambientes.Count() == 0)
            {
                return new NoContentResult();
            }

            return new OkObjectResult(ambientes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Ambiente>> Get(Guid id)
        {
            Ambiente ambiente = await _ambienteRepository.GetAsync(id);

            if (ambiente == null)
            {
                return new NotFoundResult();
            }

            return new OkObjectResult(ambiente);
        }

        [HttpPost]
        public async Task<ActionResult<Ambiente>> Create([FromBody] Ambiente ambiente)
        {
            await _ambienteRepository.CreateAsync(ambiente);

            return new CreatedResult($"ambientes/{ambiente.Id}", ambiente);  
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Ambiente>> UpdateAsync([FromBody] Ambiente ambiente, Guid id)
        {
            Ambiente ambienteDb = await _ambienteRepository.UpdateAsync(ambiente, id);

            if(ambienteDb == null)
            {
                return new NotFoundResult();
            }

            return new OkObjectResult(ambienteDb);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            bool deletado = await _ambienteRepository.DeleteAsync(id);

            if (deletado)
            {
                return new OkResult();
                
            }

            return new NotFoundResult();
        }
    }
}
