using DesafioMundiPagg.Domain.Entities;
using DesafioMundiPagg.Domain.Interfaces.Repositories;
using DesafioMundiPagg.Domain.Interfaces.Services;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioMundiPagg.Domain.Services
{
    public class PessoaService : ServiceBase<Pessoa>, IPessoaService
    {
        public PessoaService(IPessoaRepository pessoaRepository, ILogger<PessoaService> logger) : base(pessoaRepository, logger) {}
    }
}
