using Retenciones.Abstraccion;
using Retenciones.Data.DI;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retenciones.Services.DI
{
    public static class ServiceRegistrar
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.RegisterDbContextFactory();
            services.AddScoped<IRetencionService, RetencionService>();
            return services;
        }
    }
}
