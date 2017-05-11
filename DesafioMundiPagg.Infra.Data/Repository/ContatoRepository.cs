using DesafioMundiPagg.Domain.Entities;
using DesafioMundiPagg.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioMundiPagg.Infra.Data.Repository
{
    public class ContatoRepository : RepositoryBase<Contato>, IContatoRepository
    {
        public ContatoRepository(ElasticSearchProvider provider) : base(provider)
        {
        }
    }
}
