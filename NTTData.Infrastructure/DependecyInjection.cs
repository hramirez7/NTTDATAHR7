using Microsoft.Extensions.DependencyInjection;
using NTTData.Application.Interfaces.IRepository;
using NTTData.Infrastructure.DATA.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTTData.Infrastructure
{
    public static class DependecyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {

            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IMovimientoRepository, MovimientoRepository>();
            services.AddScoped<ICuentaRepository, CuentaRepository>();

            return services;
        }
    }
}
