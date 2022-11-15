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
    public class SetoresController : ControllerBase
    {
        private readonly ISetoresRepository _setoresRepository;

        public SetoresController(ISetoresRepository setorRepository)
        {
            this._setoresRepository = setorRepository;
        }

        // GET: /<SetoresController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Setor>>> Get()
        {
            return await _setoresRepository.GetAsync();
        }

        // GET /<SetoresController>/5aas-dhalk-sdalkj
        [HttpGet("{id}")]
        public async Task<ActionResult<Setor>> Get(Guid id)
        {
            return await _setoresRepository.GetAsync(id);
        }

        // POST /<SetoresController>
        [HttpPost]
        public async Task<ActionResult<Setor>> Create([FromBody] Setor setor)
        {
            return await _setoresRepository.CreateAsync(setor);
        }

        // PUT /<SetoresController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Setor>> UpdateAsync([FromBody] Setor setor, Guid id)
        {
            return await _setoresRepository.UpdateAsync(setor, id);
        }

        // DELETE /<SetoresController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            return await _setoresRepository.DeleteAsync(id);
        }
    }
}
