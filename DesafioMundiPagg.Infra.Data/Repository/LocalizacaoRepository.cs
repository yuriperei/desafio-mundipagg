using DesafioMundiPagg.Domain.Entities;
using DesafioMundiPagg.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioMundiPagg.Infra.Data.Repository
{
    public class LocalizacaoRepository : RepositoryBase<Localizacao>, ILocalizacaoRepository
    {
        public LocalizacaoRepository(ElasticSearchProvider provider) : base(provider)
        {
             
        }
    }
}
