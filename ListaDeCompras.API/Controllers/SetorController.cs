using ListaDeCompras.API.Data;
using ListaDeCompras.API.Models;
using ListaDeCompras.API.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ListaDeCompras.API.Controllers
{
    [Route("setores")]
    [ApiController]
    public class SetorController : ControllerBase
    {
        private readonly ISetoresRepository _setoresRepository;

        public SetorController(ISetoresRepository setorRepository)
        {
            this._setoresRepository = setorRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Setor>>> Get()
        {
            var setores = await _setoresRepository.GetAsync();
                        
            if (setores == null || setores.Count() == 0)
            {
                return new NoContentResult();
            }

            return new OkObjectResult(setores);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Setor>> Get(Guid id)
        {
            Setor setor = await _setoresRepository.GetAsync(id);

            if (setor == null)
            {
                return new NotFoundResult();
            }

            return new OkObjectResult(setor);
        }

        [HttpPost]
        public async Task<ActionResult<Setor>> Create([FromBody] Setor setor)
        {
            await _setoresRepository.CreateAsync(setor);

            return new CreatedResult($"setores/{setor.Id}", setor);  
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Setor>> UpdateAsync([FromBody] Setor setor, Guid id)
        {
            Setor setorDb = await _setoresRepository.UpdateAsync(setor, id);

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
