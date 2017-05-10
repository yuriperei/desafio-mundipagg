using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioMundiPagg.Domain.Interfaces.Services
{
    public interface IServiceBase<T>
    {
        IEnumerable<T> ObterTodos();
        T ObterPorId(string id);
        void Adicionar(T entity, string id);
        void Alterar(T entity, string id);
        void Remover(string id);
    }
}
