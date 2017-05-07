using DesafioMundiPagg.Domain.Interfaces.Repositories;
using DesafioMundiPagg.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioMundiPagg.Domain.Services
{
    public class ServiceBase<T> : IServiceBase<T> where T : class
    {
        private readonly IRepositoryBase<T> _repositoryBase;

        public ServiceBase(IRepositoryBase<T> repositoryBase)
        {
            _repositoryBase = repositoryBase;
        }

        public void Adicionar(T entity)
        {
            _repositoryBase.Adicionar(entity);
        }

        public void Alterar(T entity)
        {
            _repositoryBase.Alterar(entity);
        }

        public T ObterPorId(int? id)
        {
            return _repositoryBase.ObterPorId(id);
        }

        public IEnumerable<T> ObterTodos()
        {
            return _repositoryBase.ObterTodos();
        }

        public void Remover(int? id)
        {
            _repositoryBase.Remover(id);
        }

        public void Remover(T entity)
        {
            _repositoryBase.Remover(entity);
        }
    }
}
