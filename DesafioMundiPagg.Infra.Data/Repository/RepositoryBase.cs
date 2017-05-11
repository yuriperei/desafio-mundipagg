using DesafioMundiPagg.Domain.Entities;
using DesafioMundiPagg.Domain.Interfaces.Repositories;
using ElasticsearchCRUD.Model.SearchModel;
using ElasticsearchCRUD.Model.SearchModel.Queries;
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

        public RepositoryBase(ElasticSearchProvider provider)
        {
            _provider = provider;
        }

        public void Adicionar(T entity, string id)
        {
            _provider.Context().AddUpdateDocument(entity, id);
            _provider.Context().SaveChanges();
        }

        public void Alterar(T entity, string id)
        {
            _provider.Context().AddUpdateDocument(entity, id);
            _provider.Context().SaveChanges();
        }

        public T ObterPorId(string id)
        {
            try
            {
                return _provider.Context().GetDocument<T>(id);
            }catch(Exception ex)
            {
                return null;
            }
        }

        public IEnumerable<T> ObterTodos()
        {
            try
            {
                var results = _provider.Context().Search<T>("");
                return results.PayloadResult.Hits.HitsResult.Select(t => t.Source);
            }
            catch
            {
                return null;
            }
            
        }

        public void Remover(string id)
        {
            _provider.Context().DeleteDocument<T>(id);
            _provider.Context().SaveChangesAsync();
        }
    }
}