using DesafioMundiPagg.Domain.Entities;
using DesafioMundiPagg.Domain.Interfaces.Repositories;
using DesafioMundiPagg.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioMundiPagg.Domain.Services
{
    public class LocalizacaoService : ServiceBase<Localizacao>, ILocalizacaoService
    {
        public LocalizacaoService(ILocalizacaoRepository localizacaoRepository) : base(localizacaoRepository){}
    }
}
