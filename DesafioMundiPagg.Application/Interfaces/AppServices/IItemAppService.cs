using DesafioMundiPagg.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioMundiPagg.Application.Interfaces.AppServices
{
    public interface IItemAppService
    {
        IEnumerable<Item> ObterTodos();
        Item ObterPorId(string id);
        void Adicionar(Item item);
        void Alterar(Item item);
        void Remover(string id);
    }
}
