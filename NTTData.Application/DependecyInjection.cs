using Microsoft.Extensions.DependencyInjection;
using NTTData.Application.Interfaces.IServices;
using NTTData.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTTData.Application
{
    public static class DependecyInjection
    {
        public static IServiceCollection AddService(this IServiceCollection services)
        {
            services.AddScoped<IClienteServices, ClienteServices>();
            services.AddScoped<IMovimientosServices, MovimientoServices>();
            services.AddScoped<ICuentaServices, CuentaServicio>();

            return services;
        }

    }
}
