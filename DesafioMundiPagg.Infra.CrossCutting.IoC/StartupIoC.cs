using DesafioMundiPagg.Application.AppServices;
using DesafioMundiPagg.Application.Interfaces.AppServices;
using DesafioMundiPagg.Domain.Interfaces.Repositories;
using DesafioMundiPagg.Domain.Interfaces.Services;
using DesafioMundiPagg.Domain.Services;
using DesafioMundiPagg.Infra.Data;
using DesafioMundiPagg.Infra.Data.Repository;
using ElasticsearchCRUD;
using Microsoft.Extensions.DependencyInjection;
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
            services.AddSingleton<IElasticsearchMappingResolver, ElasticsearchMappingResolver>();
            services.AddSingleton<ElasticSearchProvider>();

            //Repository Dependencies
            services.AddSingleton<IItemRepository, ItemRepository>();
            services.AddSingleton<IContatoRepository, ContatoRepository>();
            services.AddSingleton<IEmprestimoRepository, EmprestimoRepository>();
            services.AddSingleton<ILocalizacaoRepository, LocalizacaoRepository>();
            services.AddSingleton<IPessoaRepository, PessoaRepository>();

            //Application Services Dependencies
            services.AddSingleton<IItemAppService, ItemAppService>();
            services.AddSingleton<IContatoAppService, ContatoAppService>();
            services.AddSingleton<IEmprestimoAppService, EmprestimoAppService>();
            services.AddSingleton<ILocalizacaoAppService, LocalizacaoAppService>();
            services.AddSingleton<IPessoaAppService, PessoaAppService>();

            //Domain Services Dependencies
            services.AddSingleton<IItemService, ItemService>();
            services.AddSingleton<IContatoService, ContatoService>();
            services.AddSingleton<IEmprestimoService, EmprestimoService>();
            services.AddSingleton<ILocalizacaoService, LocalizacaoService>();
            services.AddSingleton<IPessoaService, PessoaService>();
        }
    }
}
