using DesafioMundiPagg.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioMundiPagg.Application.Interfaces.AppServices
{
    public interface IContatoAppService
    {
        IEnumerable<ContatoDTO> ObterTodos();
        ContatoDTO ObterPorId(string id);
        void Adicionar(ContatoDTO item);
        void Alterar(ContatoDTO item);
        void Remover(string id);
    }
}
