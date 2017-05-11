using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DesafioMundiPagg.Application.DTOs;
using DesafioMundiPagg.Application.Interfaces.AppServices;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DesafioMundiPagg.Service.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class ContatosController : Controller
    {
        private readonly IContatoAppService _contatoAppService;

        public ContatosController(IContatoAppService contatoAppService)
        {
            _contatoAppService = contatoAppService;
        }

        // GET api/itens
        [HttpGet]
        public IEnumerable<ContatoDTO> Get()
        {
            return _contatoAppService.ObterTodos();
        }

        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            var contato = _contatoAppService.ObterPorId(id);

            if (contato == null)
            {
                return NotFound();
            }
            return new ObjectResult(contato);
        }

        // POST api/itens
        [HttpPost]
        public IActionResult Post([FromBody] ContatoDTO contato)
        {
            if (ModelState.IsValid)
            {
                _contatoAppService.Adicionar(contato);
                string url = $"api/contatos/{contato.ContatoId}";
                return Created(url, contato);
            }

            return BadRequest(ModelState);
        }

        // PUT api/itens/5
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
                return NotFound();
            }
            _contatoAppService.Alterar(contato);
            return new NoContentResult();
        }

        // DELETE api/itens/5
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var entity = _contatoAppService.ObterPorId(id);
            if (entity == null)
            {
                return NotFound();
            }
            _contatoAppService.Remover(id);
            return new NoContentResult();
        }
    }
}
