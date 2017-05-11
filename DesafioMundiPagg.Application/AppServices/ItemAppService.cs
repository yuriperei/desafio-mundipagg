using AutoMapper;
using DesafioMundiPagg.Application.DTOs;
using DesafioMundiPagg.Application.Interfaces.AppServices;
using DesafioMundiPagg.Domain.Entities;
using DesafioMundiPagg.Domain.Interfaces.Services;
using DesafioMundiPagg.Domain.Services;
using DesafioMundiPagg.Infra.CrossCutting.Logger;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioMundiPagg.Application.AppServices
{
    public class ItemAppService : IItemAppService
    {
        private readonly IItemService _itemService;

        public ItemAppService(IItemService itemService)
        {
            _itemService = itemService;
        }

        public void Adicionar(ItemDTO itemDto)
        {
            itemDto.ItemId = UtilService.GerarID();
            var itemDomain = MapToDomain(itemDto); 
            _itemService.Adicionar(itemDomain, itemDomain.ItemId);
        }

        public void Alterar(ItemDTO itemDto)
        {
            var itemDomain = MapToDomain(itemDto);
            _itemService.Alterar(itemDomain, itemDomain.ItemId);
        }

        public ItemDTO ObterPorId(string id)
        {
            var itemDomain = _itemService.ObterPorId(id);
            return MapToDTO(itemDomain);
        }

        public IEnumerable<ItemDTO> ObterTodos()
        {
            var itensDomain = _itemService.ObterTodos();
            return MapToDTOList(itensDomain);
        }

        public void Remover(string id)
        {
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
