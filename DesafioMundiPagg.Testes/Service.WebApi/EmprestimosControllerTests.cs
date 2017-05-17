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
    public class EmprestimosControllerTests : UnitTestsBase
    {
        private EmprestimosController controller;

        public EmprestimosControllerTests()
        {
            OverriderRegistration(x => Substitute.For<IEmprestimoAppService>());
            OverriderRegistration(x => Substitute.For<ILogger<EmprestimosController>>());
            controller = new EmprestimosController(InstanceOf<IEmprestimoAppService>(), InstanceOf<ILogger<EmprestimosController>>());
        }

        [Fact]
        public void ObterEmprestimosSucesso()
        {
            var emprestimoAppService = InstanceOf<IEmprestimoAppService>();
            emprestimoAppService.ObterTodos().Returns(new EmprestimoDTO[]
            {
                new EmprestimoDTO
                {
                    EmprestimoId = "123456",
                    DataDevolucao = DateTime.Now.ToString(),
                    DataEmprestimo = DateTime.Now.ToString(),
                    Item = new ItemDTO(),
                    Pessoa = new PessoaDTO()
            }
            });

            var result = (ObjectResult)controller.Get();
            IEnumerable<EmprestimoDTO> resultEmprestimos = (IEnumerable<EmprestimoDTO>)result.Value;

            Assert.NotNull(resultEmprestimos);
            Assert.Equal(1, resultEmprestimos.Count());

            var emprestimo = resultEmprestimos.First();
            Assert.NotEmpty(emprestimo.EmprestimoId);
            Assert.NotEmpty(emprestimo.DataEmprestimo);
            Assert.NotEmpty(emprestimo.DataDevolucao);
            Assert.NotNull(emprestimo.Item);
            Assert.NotNull(emprestimo.Pessoa);
        }

        [Fact]
        public void ObterEmprestimosSemSucesso()
        {
            var emprestimoAppService = InstanceOf<IEmprestimoAppService>();
            emprestimoAppService.ObterTodos().Returns((call) =>
            {
                return null;
            });

            var result = controller.Get();
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void ObterPorIdSucesso()
        {
            var emprestimoAppService = InstanceOf<IEmprestimoAppService>();
            emprestimoAppService.ObterPorId("123456").Returns(new EmprestimoDTO
            {
                EmprestimoId = "123456",
                DataDevolucao = DateTime.Now.ToString(),
                DataEmprestimo = DateTime.Now.ToString(),
                Item = new ItemDTO(),
                Pessoa = new PessoaDTO()
            });

            var result = (ObjectResult)controller.Get("123456");
            EmprestimoDTO resultEmprestimo = (EmprestimoDTO)result.Value;

            Assert.NotNull(resultEmprestimo);
            Assert.NotEmpty(resultEmprestimo.EmprestimoId);
            Assert.Equal("123456", resultEmprestimo.EmprestimoId);
            Assert.NotEmpty(resultEmprestimo.DataEmprestimo);
            Assert.NotEmpty(resultEmprestimo.DataDevolucao);
            Assert.NotNull(resultEmprestimo.Item);
            Assert.NotNull(resultEmprestimo.Pessoa);
        }

        [Fact]
        public void ObterEmprestimoPorIdSemSucesso()
        {
            var emprestimoAppService = InstanceOf<IEmprestimoAppService>();
            emprestimoAppService.ObterPorId("123").Returns((call) =>
            {
                throw new Exception();
            });

            var result = controller.Get("123456");
            Assert.IsType<NotFoundResult>(result);
        }


        [Fact]
        public void AdicionarEmprestimoSucesso()
        {
            var emprestimoAppService = InstanceOf<IEmprestimoAppService>();

            var emprestimo = new EmprestimoDTO
            {
                DataDevolucao = DateTime.Now.ToString(),
                DataEmprestimo = DateTime.Now.ToString(),
                Item = new ItemDTO(),
                Pessoa = new PessoaDTO()
            };
            var result = (CreatedResult)controller.Post(emprestimo);

            Assert.Equal(201, result.StatusCode);
            Assert.NotNull(result.Value);
        }

        [Fact]
        public void AlterarEmprestimoSucesso()
        {
            var emprestimoAppService = InstanceOf<IEmprestimoAppService>();

            emprestimoAppService.ObterPorId("123456").Returns(new EmprestimoDTO
            {
                EmprestimoId = "123456",
                DataDevolucao = DateTime.Now.ToString(),
                DataEmprestimo = DateTime.Now.ToString(),
                Item = new ItemDTO(),
                Pessoa = new PessoaDTO()
            });

            var emprestimo = new EmprestimoDTO
            {
                EmprestimoId = "123456",
                DataDevolucao = DateTime.Now.ToString(),
                DataEmprestimo = DateTime.Now.ToString(),
                Item = new ItemDTO(),
                Pessoa = new PessoaDTO()
            };

            var result = (NoContentResult)controller.Put("123456", emprestimo);

            Assert.NotNull(result);
            Assert.Equal(204, result.StatusCode);
        }

        [Fact]
        public void AlterarEmprestimoSemSucessoBadRequest()
        {
            var emprestimoAppService = InstanceOf<IEmprestimoAppService>();

            EmprestimoDTO emprestimo = null;

            var result = (BadRequestResult)controller.Put("123456", emprestimo);

            Assert.Equal(400, result.StatusCode);
        }

        [Fact]
        public void AlterarEmprestimoSemSucessoNotFound()
        {
            var emprestimoAppService = InstanceOf<IEmprestimoAppService>();

            emprestimoAppService.ObterPorId("123456").Returns((call) => null);

            var emprestimo = new EmprestimoDTO
            {
                EmprestimoId = "123456",
                DataDevolucao = DateTime.Now.ToString(),
                DataEmprestimo = DateTime.Now.ToString(),
                Item = new ItemDTO(),
                Pessoa = new PessoaDTO()
            };

            var result = (NotFoundResult)controller.Put("123456", emprestimo);

            Assert.Equal(404, result.StatusCode);
        }


        [Fact]
        public void RemoverEmprestimoSucesso()
        {
            var emprestimoAppService = InstanceOf<IEmprestimoAppService>();

            emprestimoAppService.ObterPorId("123456").Returns(new EmprestimoDTO());


            var result = (OkResult)controller.Delete("123456");

            Assert.Equal(200, result.StatusCode);
        }

        [Fact]
        public void RemoverEmprestimoSemSucesso()
        {
            var emprestimoAppService = InstanceOf<IEmprestimoAppService>();

            emprestimoAppService.ObterPorId("123456").Returns((call) => null);

            var result = (NotFoundResult)controller.Delete("123456");

            Assert.Equal(404, result.StatusCode);
        }

    }
}
