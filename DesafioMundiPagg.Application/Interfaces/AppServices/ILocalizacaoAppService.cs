using DesafioMundiPagg.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioMundiPagg.Application.Interfaces.AppServices
{
    public interface ILocalizacaoAppService
    {
        IEnumerable<LocalizacaoDTO> ObterTodos();
        LocalizacaoDTO ObterPorId(string id);
        void Adicionar(LocalizacaoDTO item);
        void Alterar(LocalizacaoDTO item);
        void Remover(string id);
    }
}
