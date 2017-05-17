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
    public class ItensControllerTests : UnitTestsBase
    {
        private ItensController controller;

        public ItensControllerTests()
        {
            OverriderRegistration(x => Substitute.For<IItemAppService>());
            OverriderRegistration(x => Substitute.For<ILogger<ItensController>>());
            controller = new ItensController(InstanceOf<IItemAppService>(), InstanceOf<ILogger<ItensController>>());
        }

        [Fact]
        public void ObterItensSucesso()
        {
            var itemAppService = InstanceOf<IItemAppService>();
            itemAppService.ObterTodos().Returns(new ItemDTO[]
            {
                new ItemDTO
                {
                    ItemId = "123456",
                    IsEmprestado = false,
                    EmprestimoId = null,
                    Titulo = "Meu teste",
                    TipoItem = TipoItem.Livro,
                    Localizacao = new LocalizacaoDTO(),
                    PessoaLocalizacao = null
                }
            });

            var result = (ObjectResult)controller.Get();
            IEnumerable<ItemDTO> resultItens = (IEnumerable<ItemDTO>)result.Value;

            Assert.NotNull(resultItens);
            Assert.Equal(1, resultItens.Count());

            var item = resultItens.First();
            Assert.NotEmpty(item.ItemId);
            Assert.NotEmpty(item.Titulo);
            Assert.False(item.IsEmprestado);
            Assert.Null(item.EmprestimoId);
            Assert.NotNull(item.Localizacao);
            Assert.Null(item.PessoaLocalizacao);
        }

        [Fact]
        public void ObterItensSemSucesso()
        {
            var itemAppService = InstanceOf<IItemAppService>();
            itemAppService.ObterTodos().Returns((call) =>
            {
                return null;
            });

            var result = controller.Get();
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void ObterPorIdSucesso()
        {
            var itemAppService = InstanceOf<IItemAppService>();
            itemAppService.ObterPorId("123456").Returns(new ItemDTO
            {
                ItemId = "123456",
                IsEmprestado = false,
                EmprestimoId = null,
                Titulo = "Meu teste",
                TipoItem = TipoItem.Livro,
                Localizacao = new LocalizacaoDTO(),
                PessoaLocalizacao = null
            });

            var result = (ObjectResult)controller.Get("123456");
            ItemDTO resultItem = (ItemDTO)result.Value;

            Assert.NotNull(resultItem);
            Assert.NotEmpty(resultItem.ItemId);
            Assert.Equal("123456", resultItem.ItemId);
            Assert.NotEmpty(resultItem.Titulo);
            Assert.False(resultItem.IsEmprestado);
            Assert.Null(resultItem.EmprestimoId);
            Assert.NotNull(resultItem.Localizacao);
            Assert.Null(resultItem.PessoaLocalizacao);
        }

        [Fact]
        public void ObterItemPorIdSemSucesso()
        {
            var itemAppService = InstanceOf<IItemAppService>();
            itemAppService.ObterPorId("123").Returns((call) =>
            {
                throw new Exception();
            });

            var result = controller.Get("123456");
            Assert.IsType<NotFoundResult>(result);
        }


        [Fact]
        public void AdicionarItemSucesso()
        {
            var itemAppService = InstanceOf<IItemAppService>();

            var item = new ItemDTO
            {
                IsEmprestado = false,
                EmprestimoId = null,
                Titulo = "Meu teste",
                TipoItem = TipoItem.Livro,
                Localizacao = new LocalizacaoDTO(),
                PessoaLocalizacao = null
            };
            var result = (CreatedResult)controller.Post(item);

            Assert.Equal(201, result.StatusCode);
            Assert.NotNull(result.Value);
        }

        [Fact]
        public void AlterarItemSucesso()
        {
            var itemAppService = InstanceOf<IItemAppService>();

            itemAppService.ObterPorId("123456").Returns(new ItemDTO
            {
                ItemId = "123456",
                IsEmprestado = false,
                EmprestimoId = null,
                Titulo = "Meu teste",
                TipoItem = TipoItem.Livro,
                Localizacao = new LocalizacaoDTO(),
                PessoaLocalizacao = null
            });

            var item = new ItemDTO
            {
                ItemId = "123456",
                IsEmprestado = false,
                EmprestimoId = null,
                Titulo = "Meu teste",
                TipoItem = TipoItem.Livro,
                Localizacao = new LocalizacaoDTO(),
                PessoaLocalizacao = null
            };

            var result = (NoContentResult)controller.Put("123456", item);

            Assert.NotNull(result);
            Assert.Equal(204, result.StatusCode);
        }

        [Fact]
        public void AlterarItemSemSucessoBadRequest()
        {
            var itemAppService = InstanceOf<IItemAppService>();

            ItemDTO item = null;

            var result = (BadRequestResult)controller.Put("123456", item);

            Assert.Equal(400, result.StatusCode);
        }

        [Fact]
        public void AlterarItemSemSucessoNotFound()
        {
            var itemAppService = InstanceOf<IItemAppService>();

            itemAppService.ObterPorId("123456").Returns((call) => null);

            var item = new ItemDTO
            {
                ItemId = "123456",
                IsEmprestado = false,
                EmprestimoId = null,
                Titulo = "Meu teste",
                TipoItem = TipoItem.Livro,
                Localizacao = new LocalizacaoDTO(),
                PessoaLocalizacao = null
            };

            var result = (NotFoundResult)controller.Put("123456", item);

            Assert.Equal(404, result.StatusCode);
        }


        [Fact]
        public void RemoverItemSucesso()
        {
            var itemAppService = InstanceOf<IItemAppService>();

            itemAppService.ObterPorId("123456").Returns(new ItemDTO());
            

            var result = (OkResult)controller.Delete("123456");

            Assert.Equal(200, result.StatusCode);
        }

        [Fact]
        public void RemoverItemSemSucesso()
        {
            var itemAppService = InstanceOf<IItemAppService>();

            itemAppService.ObterPorId("123456").Returns((call) => null);

            var result = (NotFoundResult)controller.Delete("123456");

            Assert.Equal(404, result.StatusCode);
        }

    }
}
