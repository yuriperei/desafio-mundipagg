using DesafioMundiPagg.Domain.Entities;
using DesafioMundiPagg.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;
using DesafioMundiPagg.Domain.Interfaces.Repositories;
using Microsoft.Extensions.Logging;

namespace DesafioMundiPagg.Domain.Services
{
    public class ItemService : ServiceBase<Item>, IItemService
    {
        public ItemService(IItemRepository itemRepository, ILogger<ItemService> logger) : base(itemRepository, logger){ }
    }
}
