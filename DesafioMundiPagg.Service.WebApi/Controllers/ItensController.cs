using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using DesafioMundiPagg.Domain.Entities;
using DesafioMundiPagg.Application.Interfaces.AppServices;
using DesafioMundiPagg.Domain.Interfaces.Services;
using DesafioMundiPagg.Application.AppServices;

namespace DesafioMundiPagg.Service.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class ItensController : Controller
    {
        private readonly IItemAppService _itemAppService;

        public ItensController(IItemAppService itemAppService)
        {
            _itemAppService = itemAppService;
        }

        // GET api/itens
        [HttpGet]
        public IEnumerable<Item> Get()
        {
            return _itemAppService.ObterTodos();
        }

        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            var item = _itemAppService.ObterPorId(id);

            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        // POST api/itens
        [HttpPost]
        public IActionResult Post([FromBody] Item item)
        {
            if (ModelState.IsValid)
            {
                _itemAppService.Adicionar(item);
                string url = $"api/itens/{item.ItemId}";
                return Created(url, item);
            }

            return BadRequest(ModelState);
        }

        // PUT api/itens/5
        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody] Item item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            var contactObj = _itemAppService.ObterPorId(id);
            if (contactObj == null)
            {
                return NotFound();
            }
            _itemAppService.Alterar(item);
            return new NoContentResult();
        }

        // DELETE api/itens/5
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var item = _itemAppService.ObterPorId(id);
            if (item == null)
            {
                return NotFound();
            }
            _itemAppService.Remover(id);
            return new NoContentResult();
        }
    }
}
