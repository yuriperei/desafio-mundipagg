using AutoMapper;
using DesafioMundiPagg.Application.DTOs;
using DesafioMundiPagg.Application.Interfaces.AppServices;
using DesafioMundiPagg.Domain.Entities;
using DesafioMundiPagg.Domain.Interfaces.Services;
using DesafioMundiPagg.Domain.Services;
using DesafioMundiPagg.Infra.CrossCutting.Logger;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;E
using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioMundiPagg.Application.AppServices
{
    public class ItemAppService : IItemAppService
    {
        private readonly IItemService _itemService;
        private readonly ILogger _logger;

        public ItemAppService(IItemService itemService, ILogger<ItemAppService> logger)
        {
            _itemService = itemService;
            _logger = logger;
        }

        public void Adicionar(ItemDTO itemDto)
        {
            _logger.LogInformation(LoggingEvents.ADICIONA, "Item {ID} adicionado", itemDto.ItemId);
            itemDto.ItemId = UtilService.GerarID();
            var itemDomain = MapToDomain(itemDto);
            _itemService.Adicionar(itemDomain, itemDomain.ItemId);
        }

        public void Alterar(ItemDTO itemDto)
        {
            _logger.LogInformation(LoggingEvents.ATUALIZAR, "Item {ID} alterado", itemDto.ItemId);
            var itemDomain = MapToDomain(itemDto);
            _itemService.Alterar(itemDomain, itemDomain.ItemId);
        }

        public ItemDTO ObterPorId(string id)
        {
            _logger.LogInformation(LoggingEvents.OBTER_POR_ID, "Obter Item {ID}", id);
            var itemDomain = _itemService.ObterPorId(id);
            return MapToDTO(itemDomain);
        }

        public IEnumerable<ItemDTO> ObterTodos()
        {
            _logger.LogInformation(LoggingEvents.LISTAR, "Obter todos os Itens");
            var itemsDomain = _itemService.ObterTodos();
            return MapToDTOList(itemsDomain);
        }

        public void Remover(string id)
        {
            _logger.LogInformation(LoggingEvents.REMOVER, "Remover Item {ID}", id);
            _itemService.Remover(id);
        }

        private Item MapToDomain(ItemDTO dto)
        {
            return Mapper.Map<Item>(dto);
        }

        private ItemDTO MapToDTO(Item domain)
        {
            return Mapper.Map<ItemDTO>(domain);
        }

        private IEnumerable<Item> MapToDomainList(IEnumerable<ItemDTO> dto)
        {
            return Mapper.Map<IEnumerable<Item>>(dto);
        }

        private IEnumerable<ItemDTO> MapToDTOList(IEnumerable<Item> domain)
        {
            return Mapper.Map<IEnumerable<ItemDTO>>(domain);
        }
    }
}
