﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Serialization;
using DesafioMundiPagg.Infra.CrossCutting.IoC;
using ElasticsearchCRUD;
using DesafioMundiPagg.Domain.Interfaces.Repositories;
using DesafioMundiPagg.Infra.Data.Repository;
using DesafioMundiPagg.Infra.Data;
using DesafioMundiPagg.Domain.Interfaces.Services;
using DesafioMundiPagg.Application.Interfaces.AppServices;
using DesafioMundiPagg.Application.AppServices;
using DesafioMundiPagg.Domain.Services;
using DesafioMundiPagg.Application.AutoMapper;

namespace DesafioMundiPagg.Service.WebApi
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();

            AutoMapperConfig.RegisterMappings();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());
            });

            // Add framework services.
            services.AddMvc().AddJsonOptions(a => a.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver());
           
            //Registrar IoC
            StartupIoC.RegisterIoC(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            app.UseCors("CorsPolicy");

            app.UseCors(builder =>
            {
                builder.AllowAnyHeader();
                builder.AllowAnyMethod();
                builder.AllowAnyOrigin();
            }
            );

            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseMvc();
        }
    }
}
