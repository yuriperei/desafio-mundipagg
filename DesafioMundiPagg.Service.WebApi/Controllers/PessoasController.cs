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
    public class PessoasController : Controller
    {
        private readonly IPessoaAppService _pessoaAppService;

        public PessoasController(IPessoaAppService pessoaAppService)
        {
            _pessoaAppService = pessoaAppService;
        }

        // GET api/itens
        [HttpGet]
        public IEnumerable<PessoaDTO> Get()
        {
            return _pessoaAppService.ObterTodos();
        }

        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            var pessoa = _pessoaAppService.ObterPorId(id);

            if (pessoa == null)
            {
                return NotFound();
            }
            return new ObjectResult(pessoa);
        }

        // POST api/itens
        [HttpPost]
        public IActionResult Post([FromBody] PessoaDTO pessoa)
        {
            if (ModelState.IsValid)
            {
                _pessoaAppService.Adicionar(pessoa);
                string url = $"api/pessoas/{pessoa.PessoaId}";
                return Created(url, pessoa);
            }

            return BadRequest(ModelState);
        }

        // PUT api/itens/5
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
                return NotFound();
            }
            _pessoaAppService.Alterar(pessoa);
            return new NoContentResult();
        }

        // DELETE api/itens/5
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var entity = _pessoaAppService.ObterPorId(id);
            if (entity == null)
            {
                return NotFound();
            }
            _pessoaAppService.Remover(id);
            return new NoContentResult();
        }
    }
}
