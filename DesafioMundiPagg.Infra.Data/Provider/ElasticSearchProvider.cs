using DesafioMundiPagg.Domain.Entities;
using DesafioMundiPagg.Infra.Data.Mappings;
using ElasticsearchCRUD;
using Nest;
using System;

namespace DesafioMundiPagg.Infra.Data
{
    public class ElasticSearchProvider
    {
        private const string ConnectionString = "http://localhost:9200/";
        private ElasticsearchSerializerConfiguration _elasticsearchSerializerConfiguration;
        private IElasticsearchMappingResolver _elasticsearchMappingResolver;
        private readonly ElasticsearchContext _context;

        public ElasticSearchProvider(IElasticsearchMappingResolver elasticSearchMappingResolver)
        {
            InitializerSerializerConfiguration(elasticSearchMappingResolver);
            _context = new ElasticsearchContext(ConnectionString, _elasticsearchSerializerConfiguration);
        }

        private void InitializerSerializerConfiguration(IElasticsearchMappingResolver elasticSearchMappingResolver)
        {
            _elasticsearchMappingResolver = elasticSearchMappingResolver;

            //Mapeamento das entidades
            _elasticsearchMappingResolver.AddElasticSearchMappingForEntityType(typeof(Contato), new ContatoSearchMapping());
            _elasticsearchMappingResolver.AddElasticSearchMappingForEntityType(typeof(Emprestimo), new EmprestimoSearchMapping());
            _elasticsearchMappingResolver.AddElasticSearchMappingForEntityType(typeof(Item), new ItemSearchMapping());
            _elasticsearchMappingResolver.AddElasticSearchMappingForEntityType(typeof(Localizacao), new LocalizacaoSearchMapping());
            _elasticsearchMappingResolver.AddElasticSearchMappingForEntityType(typeof(Pessoa), new PessoaSearchMapping());

            _elasticsearchSerializerConfiguration = new ElasticsearchSerializerConfiguration(_elasticsearchMappingResolver, true, false);
        }

        public ElasticsearchContext Context()
        {
            return _context;
        }
    }
}
