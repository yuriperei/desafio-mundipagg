using DesafioMundiPagg.Application.AutoMapper;
using DesafioMundiPagg.Infra.CrossCutting.IoC;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesafioMundiPagg.Testes
{
    public abstract class UnitTestsBase
    {
        private IServiceProvider provider;
        private IServiceCollection serviceCollection;

        public UnitTestsBase()
        {
            InitializerAutoMapper();
            ConfigureIoC();
        }

        private void InitializerAutoMapper()
        {
            AutoMapperConfig.RegisterMappings();
        }

        private void ConfigureIoC()
        {
            serviceCollection = new ServiceCollection();
            StartupIoC.RegisterIoC(serviceCollection);
            provider = serviceCollection.BuildServiceProvider();
        }

        public T InstanceOf<T>()
        {
            return provider.GetService<T>();
        }

        public void OverriderRegistration<T>(Func<IServiceProvider, T> implementationFactory) where T : class
        {
            var serviceDecriptor = serviceCollection.FirstOrDefault(x => x.ImplementationType == typeof(T));
            if (serviceCollection != null)
            {
                serviceCollection.Remove(serviceDecriptor);
            }
            serviceCollection.AddScoped<T>(implementationFactory);
            provider = serviceCollection.BuildServiceProvider();
        }

    }
}
