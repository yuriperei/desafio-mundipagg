using DesafioMundiPagg.Domain.Entities;
using DesafioMundiPagg.Domain.Interfaces.Repositories;
using DesafioMundiPagg.Domain.Interfaces.Services;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioMundiPagg.Domain.Services
{
    public class ContatoService : ServiceBase<Contato>, IContatoService
    {
        public ContatoService(IContatoRepository contatoRepository, ILogger<ContatoService> logger) : base(contatoRepository, logger){}
    }
}
