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
    public class LocalizacoesController : Controller
    {
        private readonly ILocalizacaoAppService _localizacaoAppService;
        private readonly ILogger _logger;

        public LocalizacoesController(ILocalizacaoAppService localizacaoAppService, ILogger<LocalizacoesController> logger)
        {
            _localizacaoAppService = localizacaoAppService;
            _logger = logger;
        }

        // GET api/localizacoes
        [HttpGet]
        public IEnumerable<LocalizacaoDTO> Get()
        {
            _logger.LogInformation(LoggingEvents.LISTAR, "Listando todas as localizações");
            return _localizacaoAppService.ObterTodos();
        }

        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            _logger.LogInformation(LoggingEvents.OBTER_POR_ID, "Obter localização {ID}", id);

            var localizacao = _localizacaoAppService.ObterPorId(id);
            if (localizacao == null)
            {
                _logger.LogWarning(LoggingEvents.OBTER_POR_ID_NOTFOUND, "Get({ID}) NOT FOUND", id);
                return NotFound();
            }
            return new ObjectResult(localizacao);
        }

        // POST api/localizacoes
        [HttpPost]
        public IActionResult Post([FromBody] LocalizacaoDTO localizacao)
        {
            if (ModelState.IsValid)
            {
                _localizacaoAppService.Adicionar(localizacao);
                _logger.LogInformation(LoggingEvents.ADICIONA, "Localização {ID} adicionada", localizacao.LocalizacaoId);
                string url = $"api/localizacoes/{localizacao.LocalizacaoId}";
                return Created(url, localizacao);
            }

            return BadRequest(ModelState);
        }

        // PUT api/localizacoes/5
        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody] LocalizacaoDTO localizacao)
        {
            if (localizacao == null)
            {
                return BadRequest();
            }
            var entity = _localizacaoAppService.ObterPorId(id);
            if (entity == null)
            {
                _logger.LogWarning(LoggingEvents.OBTER_POR_ID_NOTFOUND, "Put({ID}) NOT FOUND", id);
                return NotFound();
            }

            _localizacaoAppService.Alterar(localizacao);
            _logger.LogInformation(LoggingEvents.ATUALIZAR, "Localização {ID} Atualizada", id);
            return new NoContentResult();
        }

        // DELETE api/localizacoes/5
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var entity = _localizacaoAppService.ObterPorId(id);
            if (entity == null)
            {
                _logger.LogWarning(LoggingEvents.OBTER_POR_ID_NOTFOUND, "Delete({ID}) NOT FOUND", id);
                return NotFound();
            }
            _localizacaoAppService.Remover(id);
            _logger.LogInformation(LoggingEvents.REMOVER, "Localização {ID} Deletada", id);

            return new OkResult();
        }
    }
}
