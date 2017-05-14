using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DesafioMundiPagg.Application.Interfaces.AppServices;
using DesafioMundiPagg.Application.DTOs;
using Microsoft.Extensions.Logging;
using DesafioMundiPagg.Infra.CrossCutting.Logger;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DesafioMundiPagg.Service.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class EmprestimosController : Controller
    {
        private readonly IEmprestimoAppService _emprestimoAppService;
        private readonly ILogger _logger;

        public EmprestimosController(IEmprestimoAppService emprestimoAppService, ILogger<EmprestimosController> logger)
        {
            _emprestimoAppService = emprestimoAppService;
            _logger = logger;
        }

        // GET api/emprestimos
        [HttpGet]
        public IActionResult Get()
        {
            _logger.LogInformation(LoggingEvents.LISTAR, "Listando todos os emprestimos");
            var emprestimos = _emprestimoAppService.ObterTodos();
            if (emprestimos == null)
            {
                _logger.LogWarning(LoggingEvents.LISTAR_NOTFOUND, "Get() NOT FOUND");
                return NotFound();
            }

            return new ObjectResult(emprestimos);
        }

        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            _logger.LogInformation(LoggingEvents.OBTER_POR_ID, "Obter emprestimo {ID}", id);

            var emprestimo = _emprestimoAppService.ObterPorId(id);
            if (emprestimo == null)
            {
                _logger.LogWarning(LoggingEvents.OBTER_POR_ID_NOTFOUND, "Get({ID}) NOT FOUND", id);
                return NotFound();
            }
            return new ObjectResult(emprestimo);
        }

        // POST api/emprestimos
        [HttpPost]
        public IActionResult Post([FromBody] ItemDTO emprestimo)
        {
            if (ModelState.IsValid)
            {
                _emprestimoAppService.Adicionar(emprestimo);
                _logger.LogInformation(LoggingEvents.ADICIONA, "Item {ID} adicionado", emprestimo.ItemId);
                string url = $"api/emprestimos/{emprestimo.ItemId}";
                return Created(url, emprestimo);
            }

            return BadRequest(ModelState);
        }

        // PUT api/emprestimos/5
        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody] ItemDTO emprestimo)
        {
            if (emprestimo == null)
            {
                return BadRequest();
            }
            var entity = _emprestimoAppService.ObterPorId(id);
            if (entity == null)
            {
                _logger.LogWarning(LoggingEvents.OBTER_POR_ID_NOTFOUND, "Put({ID}) NOT FOUND", id);
                return NotFound();
            }

            _emprestimoAppService.Alterar(emprestimo);
            _logger.LogInformation(LoggingEvents.ATUALIZAR, "Emprestimo {ID} Atualizado", id);
            return new NoContentResult();
        }

        // DELETE api/emprestimos/5
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var entity = _emprestimoAppService.ObterPorId(id);
            if (entity == null)
            {
                _logger.LogWarning(LoggingEvents.OBTER_POR_ID_NOTFOUND, "Delete({ID}) NOT FOUND", id);
                return NotFound();
            }
            _emprestimoAppService.Remover(id);
            _logger.LogInformation(LoggingEvents.REMOVER, "Emprestimo {ID} Deletado", id);

            return new OkResult();
        }
    }
}
