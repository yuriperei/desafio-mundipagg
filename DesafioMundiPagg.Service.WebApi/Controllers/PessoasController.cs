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
    public class PessoasController : Controller
    {
        private readonly IPessoaAppService _pessoaAppService;
        private readonly ILogger _logger;

        public PessoasController(IPessoaAppService pessoaAppService, ILogger<PessoasController> logger)
        {
            _pessoaAppService = pessoaAppService;
            _logger = logger;
        }

        // GET api/pessoas
        [HttpGet]
        public IActionResult Get()
        {
            _logger.LogInformation(LoggingEvents.LISTAR, "Listando todas as pessoas");
            var pessoas = _pessoaAppService.ObterTodos();
            if (pessoas == null)
            {
                _logger.LogWarning(LoggingEvents.LISTAR_NOTFOUND, "Get() NOT FOUND");
                return NotFound();
            }

            return new ObjectResult(pessoas);
        }

        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            _logger.LogInformation(LoggingEvents.OBTER_POR_ID, "Obter pessoa {ID}", id);

            var pessoa = _pessoaAppService.ObterPorId(id);
            if (pessoa == null)
            {
                _logger.LogWarning(LoggingEvents.OBTER_POR_ID_NOTFOUND, "Get({ID}) NOT FOUND", id);
                return NotFound();
            }
            return new ObjectResult(pessoa);
        }

        // POST api/pessoas
        [HttpPost]
        public IActionResult Post([FromBody] PessoaDTO pessoa)
        {
            if (ModelState.IsValid)
            {
                _pessoaAppService.Adicionar(pessoa);
                _logger.LogInformation(LoggingEvents.ADICIONA, "Pessoa {ID} adicionada", pessoa.PessoaId);
                string url = $"api/pessoas/{pessoa.PessoaId}";
                return Created(url, pessoa);
            }

            return BadRequest(ModelState);
        }

        // PUT api/pessoas/5
        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody] PessoaDTO pessoa)
        {
            if (pessoa == null)
            {
                return BadRequest();
            }
            var entity = _pessoaAppService.ObterPorId(id);
            if (entity == null)
            {
                _logger.LogWarning(LoggingEvents.OBTER_POR_ID_NOTFOUND, "Put({ID}) NOT FOUND", id);
                return NotFound();
            }

            _pessoaAppService.Alterar(pessoa);
            _logger.LogInformation(LoggingEvents.ATUALIZAR, "Pessoa {ID} Atualizada", id);
            return new NoContentResult();
        }

        // DELETE api/pessoas/5
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var entity = _pessoaAppService.ObterPorId(id);
            if (entity == null)
            {
                _logger.LogWarning(LoggingEvents.OBTER_POR_ID_NOTFOUND, "Delete({ID}) NOT FOUND", id);
                return NotFound();
            }
            _pessoaAppService.Remover(id);
            _logger.LogInformation(LoggingEvents.REMOVER, "Pessoa {ID} Deletada", id);

            return new OkResult();
        }
    }
}
