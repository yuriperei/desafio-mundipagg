using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioMundiPagg.Domain.Interfaces.Repositories
{
    public interface IRepositoryBase<T> where T : class
    {
        IEnumerable<T> ObterTodos();
        T ObterPorId(string id);
        void Adicionar(T entity, string id);
        void Alterar(T entity, string id);
        void Remover(string id);
    }
}
