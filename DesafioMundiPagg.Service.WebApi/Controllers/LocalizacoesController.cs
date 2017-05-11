using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DesafioMundiPagg.Application.Interfaces.AppServices;
using DesafioMundiPagg.Application.DTOs;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DesafioMundiPagg.Service.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class LocalizacoesController : Controller
    {
        private readonly ILocalizacaoAppService _localizacaoAppService;

        public LocalizacoesController(ILocalizacaoAppService localizacaoAppService)
        {
            _localizacaoAppService = localizacaoAppService;
        }

        // GET api/itens
        [HttpGet]
        public IEnumerable<LocalizacaoDTO> Get()
        {
            return _localizacaoAppService.ObterTodos();
        }

        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            var localizacao = _localizacaoAppService.ObterPorId(id);

            if (localizacao == null)
            {
                return NotFound();
            }
            return new ObjectResult(localizacao);
        }

        // POST api/itens
        [HttpPost]
        public IActionResult Post([FromBody] LocalizacaoDTO localizacao)
        {
            if (ModelState.IsValid)
            {
                _localizacaoAppService.Adicionar(localizacao);
                string url = $"api/localizacoes/{localizacao.LocalizacaoId}";
                return Created(url, localizacao);
            }

            return BadRequest(ModelState);
        }

        // PUT api/itens/5
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
                return NotFound();
            }
            _localizacaoAppService.Alterar(localizacao);
            return new NoContentResult();
        }

        // DELETE api/itens/5
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var entity = _localizacaoAppService.ObterPorId(id);
            if (entity == null)
            {
                return NotFound();
            }
            _localizacaoAppService.Remover(id);
            return new NoContentResult();
        }
    }
}
