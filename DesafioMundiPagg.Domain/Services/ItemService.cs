using DesafioMundiPagg.Domain.Entities;
using DesafioMundiPagg.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;
using DesafioMundiPagg.Domain.Interfaces.Repositories;

namespace DesafioMundiPagg.Domain.Services
{
    public class ItemService : ServiceBase<Item>, IItemService
    {
        //private readonly IItemRepository _itemRepository;

        public ItemService(IItemRepository itemRepository) : base(itemRepository)
        {
            //_itemRepository = itemRepository;
        }
    }
}
