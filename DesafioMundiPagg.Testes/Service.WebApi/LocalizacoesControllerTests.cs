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
    public class LocalizacoesControllerTests : UnitTestsBase
    {
        private LocalizacoesController controller;

        public LocalizacoesControllerTests()
        {
            OverriderRegistration(x => Substitute.For<ILocalizacaoAppService>());
            OverriderRegistration(x => Substitute.For<ILogger<LocalizacoesController>>());
            controller = new LocalizacoesController(InstanceOf<ILocalizacaoAppService>(), InstanceOf<ILogger<LocalizacoesController>>());
        }

        [Fact]
        public void ObterLocalizacoesSucesso()
        {
            var localizacaoAppService = InstanceOf<ILocalizacaoAppService>();
            localizacaoAppService.ObterTodos().Returns(new LocalizacaoDTO[]
            {
                new LocalizacaoDTO
                {
                    LocalizacaoId = "123456",
                    Nome = "Casa do XPTO",
                    Endereco = "Rua XPTO, 123",
                    Cidade = "Rio de Janeiro",
                    Estado = "Rio de Janeiro",
                    Pais = "Brasil"
                }
            });

            var result = (ObjectResult)controller.Get();
            IEnumerable<LocalizacaoDTO> resultLocalizacoes = (IEnumerable<LocalizacaoDTO>)result.Value;

            Assert.NotNull(resultLocalizacoes);
            Assert.Equal(1, resultLocalizacoes.Count());

            var localizacao = resultLocalizacoes.First();
            Assert.NotEmpty(localizacao.LocalizacaoId);
            Assert.NotEmpty(localizacao.Nome);
            Assert.NotEmpty(localizacao.Endereco);
            Assert.NotEmpty(localizacao.Cidade);
            Assert.NotEmpty(localizacao.Estado);
            Assert.NotEmpty(localizacao.Pais);
        }

        [Fact]
        public void ObterLocalizacoesSemSucesso()
        {
            var localizacaoAppService = InstanceOf<ILocalizacaoAppService>();
            localizacaoAppService.ObterTodos().Returns((call) =>
            {
                return null;
            });

            var result = controller.Get();
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void ObterPorIdSucesso()
        {
            var localizacaoAppService = InstanceOf<ILocalizacaoAppService>();
            localizacaoAppService.ObterPorId("123456").Returns(new LocalizacaoDTO
            {
                LocalizacaoId = "123456",
                Nome = "Casa do XPTO",
                Endereco = "Rua XPTO, 123",
                Cidade = "Rio de Janeiro",
                Estado = "Rio de Janeiro",
                Pais = "Brasil"
            });

            var result = (ObjectResult)controller.Get("123456");
            LocalizacaoDTO resultLocalizacao = (LocalizacaoDTO)result.Value;

            Assert.NotNull(resultLocalizacao);
            Assert.NotEmpty(resultLocalizacao.LocalizacaoId);
            Assert.Equal("123456", resultLocalizacao.LocalizacaoId);
            Assert.NotEmpty(resultLocalizacao.Nome);
            Assert.NotEmpty(resultLocalizacao.Endereco);
            Assert.NotEmpty(resultLocalizacao.Cidade);
            Assert.NotEmpty(resultLocalizacao.Estado);
            Assert.NotEmpty(resultLocalizacao.Pais);
        }

        [Fact]
        public void ObterLocalizacaoPorIdSemSucesso()
        {
            var localizacaoAppService = InstanceOf<ILocalizacaoAppService>();
            localizacaoAppService.ObterPorId("123").Returns((call) =>
            {
                throw new Exception();
            });

            var result = controller.Get("123456");
            Assert.IsType<NotFoundResult>(result);
        }


        [Fact]
        public void AdicionarLocalizacaoSucesso()
        {
            var localizacaoAppService = InstanceOf<ILocalizacaoAppService>();

            var localizacao = new LocalizacaoDTO
            {
                    Nome = "Casa do XPTO",
                    Endereco = "Rua XPTO, 123",
                    Cidade = "Rio de Janeiro",
                    Estado = "Rio de Janeiro",
                    Pais = "Brasil"
            };
            var result = (CreatedResult)controller.Post(localizacao);

            Assert.Equal(201, result.StatusCode);
            Assert.NotNull(result.Value);
        }

        [Fact]
        public void AlterarLocalizacaoSucesso()
        {
            var localizacaoAppService = InstanceOf<ILocalizacaoAppService>();

            localizacaoAppService.ObterPorId("123456").Returns(new LocalizacaoDTO
            {
                LocalizacaoId = "123456",
                Endereco = "Rua XPTO, 123",
                Cidade = "Rio de Janeiro",
                Estado = "Rio de Janeiro",
                Pais = "Brasil"
            });

            var localizacao = new LocalizacaoDTO
            {
                LocalizacaoId = "123456",
                Endereco = "Rua XPTO, 123",
                Cidade = "Rio de Janeiro",
                Estado = "Rio de Janeiro",
                Pais = "Brasil"
            };

            var result = (NoContentResult)controller.Put("123456", localizacao);

            Assert.NotNull(result);
            Assert.Equal(204, result.StatusCode);
        }

        [Fact]
        public void AlterarLocalizacaoSemSucessoBadRequest()
        {
            var localizacaoAppService = InstanceOf<ILocalizacaoAppService>();

            LocalizacaoDTO localizacao = null;

            var result = (BadRequestResult)controller.Put("123456", localizacao);

            Assert.Equal(400, result.StatusCode);
        }

        [Fact]
        public void AlterarLocalizacaoSemSucessoNotFound()
        {
            var localizacaoAppService = InstanceOf<ILocalizacaoAppService>();

            localizacaoAppService.ObterPorId("123456").Returns((call) => null);

            var localizacao = new LocalizacaoDTO
            {
                LocalizacaoId = "123456",
                Endereco = "Rua XPTO, 123",
                Cidade = "Rio de Janeiro",
                Estado = "Rio de Janeiro",
                Pais = "Brasil"
            };

            var result = (NotFoundResult)controller.Put("123456", localizacao);

            Assert.Equal(404, result.StatusCode);
        }


        [Fact]
        public void RemoverLocalizacaoSucesso()
        {
            var localizacaoAppService = InstanceOf<ILocalizacaoAppService>();

            localizacaoAppService.ObterPorId("123456").Returns(new LocalizacaoDTO());
            

            var result = (OkResult)controller.Delete("123456");

            Assert.Equal(200, result.StatusCode);
        }

        [Fact]
        public void RemoverLocalizacaoSemSucesso()
        {
            var localizacaoAppService = InstanceOf<ILocalizacaoAppService>();

            localizacaoAppService.ObterPorId("123456").Returns((call) => null);

            var result = (NotFoundResult)controller.Delete("123456");

            Assert.Equal(404, result.StatusCode);
        }

    }
}
