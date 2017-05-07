using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioMundiPagg.Domain.Interfaces.Repositories
{
    public interface IRepositoryBase<T> where T : class
    {
        IEnumerable<T> ObterTodos();

        T ObterPorId(int? id);

        void Adicionar(T entity);

        void Alterar(T entity);

        void Remover(T entity);

        void Remover(int? id);
    }
}
