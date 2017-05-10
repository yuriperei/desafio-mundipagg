using DesafioMundiPagg.Application.Interfaces.AppServices;
using DesafioMundiPagg.Domain.Entities;
using DesafioMundiPagg.Domain.Interfaces.Services;
using DesafioMundiPagg.Domain.Services;
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

        public void Adicionar(Item item)
        {
            item.ItemId = UtilService.GerarID();
            _itemService.Adicionar(item, item.ItemId);
        }

        public void Alterar(Item item)
        {
            _itemService.Alterar(item, item.ItemId);
        }

        public Item ObterPorId(string id)
        {
            return _itemService.ObterPorId(id);
        }

        public IEnumerable<Item> ObterTodos()
        {
            return _itemService.ObterTodos();
        }

        public void Remover(string id)
        {
            _itemService.Remover(id);
        }
    }
}
