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
            services.AddTransient<IItemRepository, ItemRepository>();

            //Application Services Dependencies
            services.AddTransient<IItemAppService, ItemAppService>();

            //Domain Services Dependencies
            services.AddTransient<IItemService, ItemService>();
        }
    }
}
