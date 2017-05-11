using DesafioMundiPagg.Application.DTOs;
using DesafioMundiPagg.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioMundiPagg.Application.Interfaces.AppServices
{
    public interface IItemAppService
    {
        IEnumerable<ItemDTO> ObterTodos();
        ItemDTO ObterPorId(string id);
        void Adicionar(ItemDTO item);
        void Alterar(ItemDTO item);
        void Remover(string id);
    }
}
