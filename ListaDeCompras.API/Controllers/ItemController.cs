using ListaDeCompras.API.DTO;
using ListaDeCompras.API.Interfaces;
using ListaDeCompras.API.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ListaDeCompras.API.Controllers
{
    [Route("itens")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly IItemRepository _itemRepository;

        public ItemController(IItemRepository itemRepository)
        {
            this._itemRepository = itemRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Item>>> Get()
        {
            var itens = await _itemRepository.GetAsync();
                        
            if (itens == null || itens.Count() == 0)
            {
                return NoContent();
            }

            return Ok(itens);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Item>> Get(Guid id)
        {
            Item item = await _itemRepository.GetAsync(id);

            if (item == null)
            {
                return NotFound();
            }

            return Ok(item);
        }

        [HttpPost]
        public async Task<ActionResult<Item>> Create([FromBody] ItemDTO item)
        {
            Item novoItem = await _itemRepository.CreateAsync(item);

            if (novoItem == null)
            {
                return NotFound();
            }

            return new CreatedResult($"ambientes/{novoItem.Id}", novoItem);  
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Item>> UpdateAsync([FromBody] ItemDTO itemDTO, Guid id)
        {
            Item itemDb = await _itemRepository.UpdateAsync(itemDTO, id);

            if(itemDb == null)
            {
                return NotFound();
            }

            return Ok(itemDb);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            bool deletado = await _itemRepository.DeleteAsync(id);

            if (deletado)
            {
                return Ok();
                
            }

            return NotFound();
        }
    }
}
