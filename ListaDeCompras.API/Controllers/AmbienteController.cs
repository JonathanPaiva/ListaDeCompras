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
        private readonly IAmbienteRepository _setoresRepository;

        public AmbienteController(IAmbienteRepository setorRepository)
        {
            this._setoresRepository = setorRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ambiente>>> Get()
        {
            var setores = await _setoresRepository.GetAsync();
                        
            if (setores == null || setores.Count() == 0)
            {
                return new NoContentResult();
            }

            return new OkObjectResult(setores);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Ambiente>> Get(Guid id)
        {
            Ambiente setor = await _setoresRepository.GetAsync(id);

            if (setor == null)
            {
                return new NotFoundResult();
            }

            return new OkObjectResult(setor);
        }

        [HttpPost]
        public async Task<ActionResult<Ambiente>> Create([FromBody] Ambiente setor)
        {
            await _setoresRepository.CreateAsync(setor);

            return new CreatedResult($"ambientes/{setor.Id}", setor);  
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Ambiente>> UpdateAsync([FromBody] Ambiente setor, Guid id)
        {
            Ambiente setorDb = await _setoresRepository.UpdateAsync(setor, id);

            if(setorDb == null)
            {
                return new NotFoundResult();
            }

            return new OkObjectResult(setorDb);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            bool deletado = await _setoresRepository.DeleteAsync(id);

            if (deletado)
            {
                return new OkResult();
                
            }

            return new NotFoundResult();
        }
    }
}
