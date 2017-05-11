using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DesafioMundiPagg.Application.DTOs;
using DesafioMundiPagg.Application.Interfaces.AppServices;
using Microsoft.Extensions.Logging;
using DesafioMundiPagg.Infra.CrossCutting.Logger;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DesafioMundiPagg.Service.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class ContatosController : Controller
    {
        private readonly IContatoAppService _contatoAppService;
        private readonly ILogger _logger;

        public ContatosController(IContatoAppService contatoAppService, ILogger<ContatosController> logger)
        {
            _contatoAppService = contatoAppService;
            _logger = logger;
        }

        // GET api/contatos
        [HttpGet]
        public IActionResult Get()
        {
            _logger.LogInformation(LoggingEvents.LISTAR, "Listando todos os contatos");
            var contatos = _contatoAppService.ObterTodos();
            if (contatos == null)
            {
                _logger.LogWarning(LoggingEvents.LISTAR_NOTFOUND, "Get() NOT FOUND");
                return NotFound();
            }

            return new ObjectResult(contatos);
        }

        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            _logger.LogInformation(LoggingEvents.OBTER_POR_ID, "Obter contato {ID}", id);

            var contato = _contatoAppService.ObterPorId(id);
            if (contato == null)
            {
                _logger.LogWarning(LoggingEvents.OBTER_POR_ID_NOTFOUND, "Get({ID}) NOT FOUND", id);
                return NotFound();
            }
            return new ObjectResult(contato);
        }

        // POST api/contatos
        [HttpPost]
        public IActionResult Post([FromBody] ContatoDTO contato)
        {
            if (ModelState.IsValid)
            {
                _contatoAppService.Adicionar(contato);
                _logger.LogInformation(LoggingEvents.ADICIONA, "Contato {ID} adicionado", contato.ContatoId);
                string url = $"api/contatos/{contato.ContatoId}";
                return Created(url, contato);
            }

            return BadRequest(ModelState);
        }

        // PUT api/contatos/5
        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody] ContatoDTO contato)
        {
            if (contato == null)
            {
                return BadRequest();
            }
            var entity = _contatoAppService.ObterPorId(id);
            if (entity == null)
            {
                _logger.LogWarning(LoggingEvents.OBTER_POR_ID_NOTFOUND, "Put({ID}) NOT FOUND", id);
                return NotFound();
            }

            _contatoAppService.Alterar(contato);
            _logger.LogInformation(LoggingEvents.ATUALIZAR, "Contato {ID} Atualizado", id);
            return new NoContentResult();
        }

        // DELETE api/contatos/5
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var entity = _contatoAppService.ObterPorId(id);
            if (entity == null)
            {
                _logger.LogWarning(LoggingEvents.OBTER_POR_ID_NOTFOUND, "Delete({ID}) NOT FOUND", id);
                return NotFound();
            }
            _contatoAppService.Remover(id);
            _logger.LogInformation(LoggingEvents.REMOVER, "Contato {ID} Deletado", id);

            return new OkResult();
        }
    }
}
