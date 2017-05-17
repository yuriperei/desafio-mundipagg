using DesafioMundiPagg.Domain.Interfaces.Repositories;
using DesafioMundiPagg.Domain.Interfaces.Services;
using DesafioMundiPagg.Infra.CrossCutting.Logger;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioMundiPagg.Domain.Services
{
    public class ServiceBase<T> : IServiceBase<T> where T : class
    {
        private readonly IRepositoryBase<T> _repositoryBase;
        private readonly ILogger _logger;

        public ServiceBase(IRepositoryBase<T> repositoryBase, ILogger logger)
        {
            _repositoryBase = repositoryBase;
            _logger = logger;
        }

        public void Adicionar(T entity, string id)
        {
            _logger.LogInformation(LoggingEvents.ADICIONA, "{TIPO} {ID} adicionado", typeof(T), id);
            _repositoryBase.Adicionar(entity, id);
        }

        public void Alterar(T entity, string id)
        {
            _logger.LogInformation(LoggingEvents.ATUALIZAR, "{TIPO} {ID} alterado", typeof(T), id);
            _repositoryBase.Alterar(entity, id);
        }

        public T ObterPorId(string id)
        {
            _logger.LogInformation(LoggingEvents.OBTER_POR_ID, "Obter {TIPO} {ID}", typeof(T), id);
            return _repositoryBase.ObterPorId(id);
        }

        public IEnumerable<T> ObterTodos()
        {
            _logger.LogInformation(LoggingEvents.LISTAR, "Obter todos {TIPO}", typeof(T));
            return _repositoryBase.ObterTodos();
        }

        public void Remover(string id)
        {
            _logger.LogInformation(LoggingEvents.REMOVER, "Remover {TIPO} {ID}", typeof(T), id);
            _repositoryBase.Remover(id);
        }
    }
}
