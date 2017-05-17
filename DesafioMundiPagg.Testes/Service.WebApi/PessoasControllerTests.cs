using DesafioMundiPagg.Application.DTOs;
using DesafioMundiPagg.Application.Interfaces.AppServices;
using DesafioMundiPagg.Domain.Entities;
using DesafioMundiPagg.Domain.Enum;
using DesafioMundiPagg.Domain.Services;
using DesafioMundiPagg.Service.WebApi.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Xunit;

namespace DesafioMundiPagg.Testes.Service.WebApi
{
    public class PessoasControllerTests : UnitTestsBase
    {
        private PessoasController controller;

        public PessoasControllerTests()
        {
            OverriderRegistration(x => Substitute.For<IPessoaAppService>());
            OverriderRegistration(x => Substitute.For<ILogger<PessoasController>>());
            controller = new PessoasController(InstanceOf<IPessoaAppService>(), InstanceOf<ILogger<PessoasController>>());
        }

        [Fact]
        public void ObterPessoasSucesso()
        {
            var pessoaAppService = InstanceOf<IPessoaAppService>();
            pessoaAppService.ObterTodos().Returns(new PessoaDTO[]
            {
                new PessoaDTO
                {
                    PessoaId = "123456",
                    Nome = "XPTO",
                    Contato = new ContatoDTO(),
                    Localizacao = new LocalizacaoDTO()
                }
            });

            var result = (ObjectResult)controller.Get();
            IEnumerable<PessoaDTO> resultPessoas = (IEnumerable<PessoaDTO>)result.Value;

            Assert.NotNull(resultPessoas);
            Assert.Equal(1, resultPessoas.Count());

            var pessoa = resultPessoas.First();
            Assert.NotEmpty(pessoa.PessoaId);
            Assert.NotEmpty(pessoa.Nome);
            Assert.NotNull(pessoa.Localizacao);
            Assert.NotNull(pessoa.Contato);
        }

        [Fact]
        public void ObterPessoasSemSucesso()
        {
            var pessoaAppService = InstanceOf<IPessoaAppService>();
            pessoaAppService.ObterTodos().Returns((call) =>
            {
                return null;
            });

            var result = controller.Get();
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void ObterPorIdSucesso()
        {
            var pessoaAppService = InstanceOf<IPessoaAppService>();
            pessoaAppService.ObterPorId("123456").Returns(new PessoaDTO
            {
                PessoaId = "123456",
                Nome = "XPTO",
                Contato = new ContatoDTO(),
                Localizacao = new LocalizacaoDTO()
            });

            var result = (ObjectResult)controller.Get("123456");
            PessoaDTO resultPessoa = (PessoaDTO)result.Value;

            Assert.NotNull(resultPessoa);
            Assert.NotEmpty(resultPessoa.PessoaId);
            Assert.Equal("123456", resultPessoa.PessoaId);
            Assert.NotEmpty(resultPessoa.Nome);
            Assert.NotNull(resultPessoa.Localizacao);
            Assert.NotNull(resultPessoa.Contato);
        }

        [Fact]
        public void ObterPessoaPorIdSemSucesso()
        {
            var pessoaAppService = InstanceOf<IPessoaAppService>();
            pessoaAppService.ObterPorId("123").Returns((call) =>
            {
                throw new Exception();
            });

            var result = controller.Get("123456");
            Assert.IsType<NotFoundResult>(result);
        }


        [Fact]
        public void AdicionarPessoaSucesso()
        {
            var pessoaAppService = InstanceOf<IPessoaAppService>();

            var pessoa = new PessoaDTO
            {
                Nome = "XPTO",
                Contato = new ContatoDTO(),
                Localizacao = new LocalizacaoDTO()
            };
            var result = (CreatedResult)controller.Post(pessoa);

            Assert.Equal(201, result.StatusCode);
            Assert.NotNull(result.Value);
        }

        [Fact]
        public void AlterarPessoaSucesso()
        {
            var pessoaAppService = InstanceOf<IPessoaAppService>();

            pessoaAppService.ObterPorId("123456").Returns(new PessoaDTO
            {
                PessoaId = "123456",
                Nome = "XPTO",
                Contato = new ContatoDTO(),
                Localizacao = new LocalizacaoDTO()
            });

            var pessoa = new PessoaDTO
            {
                PessoaId = "123456",
                Nome = "XPTO",
                Contato = new ContatoDTO(),
                Localizacao = new LocalizacaoDTO()
            };

            var result = (NoContentResult)controller.Put("123456", pessoa);

            Assert.NotNull(result);
            Assert.Equal(204, result.StatusCode);
        }

        [Fact]
        public void AlterarPessoaSemSucessoBadRequest()
        {
            var pessoaAppService = InstanceOf<IPessoaAppService>();

            PessoaDTO pessoa = null;

            var result = (BadRequestResult)controller.Put("123456", pessoa);

            Assert.Equal(400, result.StatusCode);
        }

        [Fact]
        public void AlterarPessoaSemSucessoNotFound()
        {
            var pessoaAppService = InstanceOf<IPessoaAppService>();

            pessoaAppService.ObterPorId("123456").Returns((call) => null);

            var pessoa = new PessoaDTO
            {
                PessoaId = "123456",
                Nome = "XPTO",
                Contato = new ContatoDTO(),
                Localizacao = new LocalizacaoDTO()
            };

            var result = (NotFoundResult)controller.Put("123456", pessoa);

            Assert.Equal(404, result.StatusCode);
        }


        [Fact]
        public void RemoverPessoaSucesso()
        {
            var pessoaAppService = InstanceOf<IPessoaAppService>();

            pessoaAppService.ObterPorId("123456").Returns(new PessoaDTO());
            

            var result = (OkResult)controller.Delete("123456");

            Assert.Equal(200, result.StatusCode);
        }

        [Fact]
        public void RemoverPessoaSemSucesso()
        {
            var pessoaAppService = InstanceOf<IPessoaAppService>();

            pessoaAppService.ObterPorId("123456").Returns((call) => null);

            var result = (NotFoundResult)controller.Delete("123456");

            Assert.Equal(404, result.StatusCode);
        }

    }
}
