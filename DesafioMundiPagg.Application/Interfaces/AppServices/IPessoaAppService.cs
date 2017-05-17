using DesafioMundiPagg.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioMundiPagg.Application.Interfaces.AppServices
{
    public interface IPessoaAppService
    {
        IEnumerable<PessoaDTO> ObterTodos();
        PessoaDTO ObterPorId(string id);
        void Adicionar(PessoaDTO item);
        void Alterar(PessoaDTO item);
        void Remover(string id);
    }
}
