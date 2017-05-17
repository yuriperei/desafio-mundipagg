using DesafioMundiPagg.Domain.Entities;
using DesafioMundiPagg.Domain.Interfaces.Repositories;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioMundiPagg.Infra.Data.Repository
{
    public class EmprestimoRepository : RepositoryBase<Emprestimo>, IEmprestimoRepository
    {
        public EmprestimoRepository(ElasticSearchProvider provider, ILogger<EmprestimoRepository> logger) : base(provider, logger){ }
    }
}
