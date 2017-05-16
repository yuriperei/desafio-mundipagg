using DesafioMundiPagg.Domain.Entities;
using DesafioMundiPagg.Domain.Interfaces.Repositories;
using DesafioMundiPagg.Domain.Interfaces.Services;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioMundiPagg.Domain.Services
{
    public class LocalizacaoService : ServiceBase<Localizacao>, ILocalizacaoService
    {
        public LocalizacaoService(ILocalizacaoRepository localizacaoRepository, ILogger<LocalizacaoService> logger) : base(localizacaoRepository, logger){}
    }
}
