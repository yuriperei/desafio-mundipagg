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
    public class EmprestimosController : Controller
    {
        private readonly IEmprestimoAppService _emprestimoAppService;

        public EmprestimosController(IEmprestimoAppService emprestimoAppService)
        {
            _emprestimoAppService = emprestimoAppService;
        }

        // GET api/itens
        [HttpGet]
        public IEnumerable<EmprestimoDTO> Get()
        {
            return _emprestimoAppService.ObterTodos();
        }

        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            var emprestimo = _emprestimoAppService.ObterPorId(id);

            if (emprestimo == null)
            {
                return NotFound();
            }
            return new ObjectResult(emprestimo);
        }

        // POST api/itens
        [HttpPost]
        public IActionResult Post([FromBody] EmprestimoDTO emprestimo)
        {
            if (ModelState.IsValid)
            {
                _emprestimoAppService.Adicionar(emprestimo);
                string url = $"api/emprestimos/{emprestimo.EmprestimoId}";
                return Created(url, emprestimo);
            }

            return BadRequest(ModelState);
        }

        // PUT api/itens/5
        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody] EmprestimoDTO emprestimo)
        {
            if (emprestimo == null)
            {
                return BadRequest();
            }
            var entity = _emprestimoAppService.ObterPorId(id);
            if (entity == null)
            {
                return NotFound();
            }
            _emprestimoAppService.Alterar(emprestimo);
            return new NoContentResult();
        }

        // DELETE api/itens/5
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var entity = _emprestimoAppService.ObterPorId(id);
            if (entity == null)
            {
                return NotFound();
            }
            _emprestimoAppService.Remover(id);
            return new NoContentResult();
        }
    }
}
