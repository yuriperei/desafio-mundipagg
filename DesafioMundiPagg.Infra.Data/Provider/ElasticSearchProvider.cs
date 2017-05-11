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
            _elasticsearchSerializerConfiguration = new ElasticsearchSerializerConfiguration(_elasticsearchMappingResolver, true, false);
        }

        public ElasticsearchContext Context()
        {
            return _context;
        }
    }
}
