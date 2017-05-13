using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using DesafioMundiPagg.Domain.Entities;
using DesafioMundiPagg.Application.Interfaces.AppServices;
using DesafioMundiPagg.Domain.Interfaces.Services;
using DesafioMundiPagg.Application.AppServices;
using DesafioMundiPagg.Application.DTOs;
using Microsoft.Extensions.Logging;
using DesafioMundiPagg.Infra.CrossCutting.Logger;
using Microsoft.AspNetCore.Cors;

namespace DesafioMundiPagg.Service.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class ItensController : Controller
    {
        private readonly IItemAppService _itemAppService;
        private readonly ILogger _logger;

        public ItensController(IItemAppService itemAppService, ILogger<ItensController> logger)
        {
            _itemAppService = itemAppService;
            _logger = logger;
        }

        // GET api/itens
        [HttpGet]
        public IActionResult Get()
        {
            _logger.LogInformation(LoggingEvents.LISTAR, "Listando todos os itens");
            var itens = _itemAppService.ObterTodos();
            if(itens == null)
            {
                _logger.LogWarning(LoggingEvents.LISTAR_NOTFOUND, "Get() NOT FOUND");
                return NotFound();
            }

            return new ObjectResult(itens);
        }

        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            _logger.LogInformation(LoggingEvents.OBTER_POR_ID, "Obter item {ID}", id);

            var item = _itemAppService.ObterPorId(id);
            if (item == null)
            {
                _logger.LogWarning(LoggingEvents.OBTER_POR_ID_NOTFOUND, "Get({ID}) NOT FOUND", id);
                return NotFound();
            }
            return new ObjectResult(item);
        }

        // POST api/itens
        [HttpPost]
        public IActionResult Post([FromBody] ItemDTO item)
        {
            if (ModelState.IsValid)
            {
                _itemAppService.Adicionar(item);
                _logger.LogInformation(LoggingEvents.ADICIONA, "Item {ID} adicionado", item.ItemId);
                string url = $"api/itens/{item.ItemId}";
                return Created(url, item);
            }

            return BadRequest(ModelState);
        }

        // PUT api/itens/5
        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody] ItemDTO item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            var entity = _itemAppService.ObterPorId(id);
            if (entity == null)
            {
                _logger.LogWarning(LoggingEvents.OBTER_POR_ID_NOTFOUND, "Put({ID}) NOT FOUND", id);
                return NotFound();
            }

            _itemAppService.Alterar(item);
            _logger.LogInformation(LoggingEvents.ATUALIZAR, "Item {ID} Atualizado", id);
            return new NoContentResult();
        }

        // DELETE api/itens/5
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var entity = _itemAppService.ObterPorId(id);
            if (entity == null)
            {
                _logger.LogWarning(LoggingEvents.OBTER_POR_ID_NOTFOUND, "Delete({ID}) NOT FOUND", id);
                return NotFound();
            }
            _itemAppService.Remover(id);
            _logger.LogInformation(LoggingEvents.REMOVER, "Item {ID} Deletado", id);

            return new OkResult();
        }
    }
}
