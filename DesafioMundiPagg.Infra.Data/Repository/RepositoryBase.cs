using DesafioMundiPagg.Domain.Entities;
using DesafioMundiPagg.Domain.Interfaces.Repositories;
using DesafioMundiPagg.Infra.CrossCutting.Logger;
using ElasticsearchCRUD.Model.SearchModel;
using ElasticsearchCRUD.Model.SearchModel.Queries;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace DesafioMundiPagg.Infra.Data.Repository
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        private readonly ElasticSearchProvider _provider;
        private readonly ILogger _logger;

        public RepositoryBase(ElasticSearchProvider provider, ILogger logger)
        {
            _provider = provider;
            _logger = logger;
        }

        public void Adicionar(T entity, string id)
        {
            try
            {
                _logger.LogInformation(LoggingEvents.ADICIONA, "{TIPO} {ID} adicionado", typeof(T), id);
                _provider.Context().AddUpdateDocument(entity, id);
                _provider.Context().SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogWarning(LoggingEvents.ADICIONA, "Não foi possível adicionar {TIPO} de ID {ID} devido ao erro: ", typeof(T), id, ex.Message);
            }
            
        }

        public void Alterar(T entity, string id)
        {
            try
            {
                _logger.LogInformation(LoggingEvents.ATUALIZAR, "{TIPO} {ID} alterado", typeof(T), id);
                _provider.Context().AddUpdateDocument(entity, id);
                _provider.Context().SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogWarning(LoggingEvents.ATUALIZAR, "Não foi possível alterar {TIPO} de ID {ID} devido ao erro: ", typeof(T), id, ex.Message);
            }
            
        }

        public T ObterPorId(string id)
        {
            try
            {
                _logger.LogInformation(LoggingEvents.OBTER_POR_ID, "Obter {TIPO} {ID}", typeof(T), id);
                return _provider.Context().GetDocument<T>(id);
            }catch(Exception ex)
            {
                _logger.LogWarning(LoggingEvents.OBTER_POR_ID, "Não foi possível obter {TIPO} de ID {ID} devido ao erro: ", typeof(T), id, ex.Message);
                return null;
            }
        }

        public IEnumerable<T> ObterTodos()
        {
            try
            {
                _logger.LogInformation(LoggingEvents.LISTAR, "Obter todos {TIPO}", typeof(T));
                var results = _provider.Context().Search<T>("");
                return results.PayloadResult.Hits.HitsResult.Select(t => t.Source);
            }
            catch (Exception ex)
            {
                _logger.LogWarning(LoggingEvents.OBTER_POR_ID, "Não foi possível obter todos {TIPO} devido ao erro: ", typeof(T), ex.Message);
                return null;
            }
            
        }

        public void Remover(string id)
        {
            try
            {
                _logger.LogInformation(LoggingEvents.REMOVER, "Remover {TIPO} {ID}", typeof(T), id);
                _provider.Context().DeleteDocument<T>(id);
                _provider.Context().SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogWarning(LoggingEvents.OBTER_POR_ID, "Não foi possível remover {TIPO} de ID {ID} devido ao erro: ", typeof(T), id, ex.Message);
                throw;
            }
            
        }
    }
}