using DesafioMundiPagg.Domain.Entities;
using DesafioMundiPagg.Domain.Interfaces.Repositories;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioMundiPagg.Infra.Data.Repository
{
    public class LocalizacaoRepository : RepositoryBase<Localizacao>, ILocalizacaoRepository
    {
        public LocalizacaoRepository(ElasticSearchProvider provider, ILogger<LocalizacaoRepository> logger) : base(provider, logger){ }
    }
}
