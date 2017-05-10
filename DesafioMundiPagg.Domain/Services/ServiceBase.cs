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

        public void Adicionar(T entity, string id)
        {
            _repositoryBase.Adicionar(entity, id);
        }

        public void Alterar(T entity, string id)
        {
            _repositoryBase.Alterar(entity, id);
        }

        public T ObterPorId(string id)
        {
            return _repositoryBase.ObterPorId(id);
        }

        public IEnumerable<T> ObterTodos()
        {
            return _repositoryBase.ObterTodos();
        }

        public void Remover(string id)
        {
            _repositoryBase.Remover(id);
        }
    }
}
