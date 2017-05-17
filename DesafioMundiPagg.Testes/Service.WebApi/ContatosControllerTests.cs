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
    public class ContatosControllerTests : UnitTestsBase
    {
        private ContatosController controller;

        public ContatosControllerTests()
        {
            OverriderRegistration(x => Substitute.For<IContatoAppService>());
            OverriderRegistration(x => Substitute.For<ILogger<ContatosController>>());
            controller = new ContatosController(InstanceOf<IContatoAppService>(), InstanceOf<ILogger<ContatosController>>());
        }

        [Fact]
        public void ObterContatosSucesso()
        {
            var contatoAppService = InstanceOf<IContatoAppService>();
            contatoAppService.ObterTodos().Returns(new ContatoDTO[]
            {
                new ContatoDTO
                {
                    ContatoId = "123456",
                    Tipo = "Email",
                    Valor = "abc@email.com"
                }
            });

            var result = (ObjectResult)controller.Get();
            IEnumerable<ContatoDTO> resultContatos = (IEnumerable<ContatoDTO>)result.Value;

            Assert.NotNull(resultContatos);
            Assert.Equal(1, resultContatos.Count());

            var contato = resultContatos.First();
            Assert.NotEmpty(contato.ContatoId);
            Assert.Equal("Email", contato.Tipo);
            Assert.Equal("abc@email.com", contato.Valor);
        }

        [Fact]
        public void ObterContatosSemSucesso()
        {
            var contatoAppService = InstanceOf<IContatoAppService>();
            contatoAppService.ObterTodos().Returns((call) =>
            {
                return null;
            });

            var result = controller.Get();
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void ObterPorIdSucesso()
        {
            var contatoAppService = InstanceOf<IContatoAppService>();
            contatoAppService.ObterPorId("123456").Returns(new ContatoDTO
            {
                ContatoId = "123456",
                Tipo = "Email",
                Valor = "abc@email.com"
            });

            var result = (ObjectResult)controller.Get("123456");
            ContatoDTO resultContato = (ContatoDTO)result.Value;

            Assert.NotNull(resultContato);
            Assert.NotEmpty(resultContato.ContatoId);
            Assert.Equal("123456", resultContato.ContatoId);
            Assert.Equal("Email", resultContato.Tipo);
            Assert.Equal("abc@email.com", resultContato.Valor);
        }

        [Fact]
        public void ObterContatoPorIdSemSucesso()
        {
            var contatoAppService = InstanceOf<IContatoAppService>();
            contatoAppService.ObterPorId("123").Returns((call) =>
            {
                throw new Exception();
            });

            var result = controller.Get("123456");
            Assert.IsType<NotFoundResult>(result);
        }


        [Fact]
        public void AdicionarContatoSucesso()
        {
            var contatoAppService = InstanceOf<IContatoAppService>();

            var contato = new ContatoDTO
            {
                Tipo = "Email",
                Valor = "abc@email.com"
            };
            var result = (CreatedResult)controller.Post(contato);

            Assert.Equal(201, result.StatusCode);
            Assert.NotNull(result.Value);
        }

        [Fact]
        public void AlterarContatoSucesso()
        {
            var contatoAppService = InstanceOf<IContatoAppService>();

            contatoAppService.ObterPorId("123456").Returns(new ContatoDTO
            {
                ContatoId = "123456",
                Tipo = "Email",
                Valor = "abc@email.com"
            });

            var contato = new ContatoDTO
            {
                ContatoId = "123456",
                Tipo = "Email",
                Valor = "abc@email.com"
            };

            var result = (NoContentResult)controller.Put("123456", contato);

            Assert.NotNull(result);
            Assert.Equal(204, result.StatusCode);
        }

        [Fact]
        public void AlterarContatoSemSucessoBadRequest()
        {
            var contatoAppService = InstanceOf<IContatoAppService>();

            ContatoDTO contato = null;

            var result = (BadRequestResult)controller.Put("123456", contato);

            Assert.Equal(400, result.StatusCode);
        }

        [Fact]
        public void AlterarContatoSemSucessoNotFound()
        {
            var contatoAppService = InstanceOf<IContatoAppService>();

            contatoAppService.ObterPorId("123456").Returns((call) => null);

            var contato = new ContatoDTO
            {
                ContatoId = "123456",
                Tipo = "Email",
                Valor = "abc@email.com"
            };

            var result = (NotFoundResult)controller.Put("123456", contato);

            Assert.Equal(404, result.StatusCode);
        }


        [Fact]
        public void RemoverContatoSucesso()
        {
            var contatoAppService = InstanceOf<IContatoAppService>();

            contatoAppService.ObterPorId("123456").Returns(new ContatoDTO());
            

            var result = (OkResult)controller.Delete("123456");

            Assert.Equal(200, result.StatusCode);
        }

        [Fact]
        public void RemoverContatoSemSucesso()
        {
            var contatoAppService = InstanceOf<IContatoAppService>();

            contatoAppService.ObterPorId("123456").Returns((call) => null);

            var result = (NotFoundResult)controller.Delete("123456");

            Assert.Equal(404, result.StatusCode);
        }

    }
}
