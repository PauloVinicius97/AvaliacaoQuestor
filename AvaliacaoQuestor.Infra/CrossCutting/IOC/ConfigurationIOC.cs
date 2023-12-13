using Autofac;
using AvaliacaoQuestor.Application.AppServices;
using AvaliacaoQuestor.Application.Interfaces;
using AvaliacaoQuestor.Domain.Interfaces.Repositories;
using AvaliacaoQuestor.Domain.Interfaces.Services;
using AvaliacaoQuestor.Domain.Services;
using AvaliacaoQuestor.Infra.Data.Repositories;

namespace AvaliacaoQuestor.Infra.CrossCutting.IOC
{
    public class ConfigurationIOC
    {
        public static void Load(ContainerBuilder builder)
        {
            // Application
            builder.RegisterType<BancoAppService>().As<IBancoAppService>();
            builder.RegisterType<BoletoAppService>().As<IBoletoAppService>();

            // Services
            builder.RegisterType<ServiceBanco>().As<IServiceBanco>();
            builder.RegisterType<ServiceBoleto>().As<IServiceBoleto>();

            // Repositories
            builder.RegisterType<RepositoryBanco>().As<IRepositoryBanco>();
            builder.RegisterType<RepositoryBoleto>().As<IRepositoryBoleto>();
        }
    }
}
