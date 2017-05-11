using DesafioMundiPagg.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioMundiPagg.Application.Interfaces.AppServices
{
    public interface IEmprestimoAppService
    {
        IEnumerable<EmprestimoDTO> ObterTodos();
        EmprestimoDTO ObterPorId(string id);
        void Adicionar(EmprestimoDTO item);
        void Alterar(EmprestimoDTO item);
        void Remover(string id);
    }
}
