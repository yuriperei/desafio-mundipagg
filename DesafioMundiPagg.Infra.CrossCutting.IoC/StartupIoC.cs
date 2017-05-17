using DesafioMundiPagg.Application.AppServices;
using DesafioMundiPagg.Application.Interfaces.AppServices;
using DesafioMundiPagg.Domain.Interfaces.Repositories;
using DesafioMundiPagg.Domain.Interfaces.Services;
using DesafioMundiPagg.Domain.Services;
using DesafioMundiPagg.Infra.Data;
using DesafioMundiPagg.Infra.Data.Repository;
using ElasticsearchCRUD;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioMundiPagg.Infra.CrossCutting.IoC
{
    public class StartupIoC
    {
        public static void RegisterIoC(IServiceCollection services)
        {
            //ElasticSearch Dependencies
            services.AddTransient<IElasticsearchMappingResolver, ElasticsearchMappingResolver>();
            services.AddTransient<ElasticSearchProvider>();

            //Repository Dependencies
            services.AddTransient<IItemRepository, ItemRepository>();
            services.AddTransient<IContatoRepository, ContatoRepository>();
            services.AddTransient<IEmprestimoRepository, EmprestimoRepository>();
            services.AddTransient<ILocalizacaoRepository, LocalizacaoRepository>();
            services.AddTransient<IPessoaRepository, PessoaRepository>();

            //Application Services Dependencies
            services.AddTransient<IItemAppService, ItemAppService>();
            services.AddTransient<IContatoAppService, ContatoAppService>();
            services.AddTransient<IEmprestimoAppService, EmprestimoAppService>();
            services.AddTransient<ILocalizacaoAppService, LocalizacaoAppService>();
            services.AddTransient<IPessoaAppService, PessoaAppService>();

            //Domain Services Dependencies
            services.AddTransient<IItemService, ItemService>();
            services.AddTransient<IContatoService, ContatoService>();
            services.AddTransient<IEmprestimoService, EmprestimoService>();
            services.AddTransient<ILocalizacaoService, LocalizacaoService>();
            services.AddTransient<IPessoaService, PessoaService>();
        }
    }
}
