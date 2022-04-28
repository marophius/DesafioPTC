using Desafio.Data;
using Desafio.Data.Repositories;
using Desafio.Domain.Interfaces;
using Desafio.Domain.Notificacoes;
using Desafio.Domain.Services;

namespace Desafio.WebApi.DependencyInjection
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<IMarcaRepository, MarcaRepository>();
            services.AddScoped<IProprietarioRepository, ProprietarioRepository>();
            services.AddScoped<IVeiculoRepository, VeiculoRepository>();
            services.AddScoped<INotificador, Notificador>();
            services.AddScoped<IMarcaService, MarcaService>();
            services.AddScoped<IProprietarioService, ProprietarioService>();
            services.AddScoped<IVeiculoService, VeiculoService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<DataContext>();

            return services;
        }
    }
}
