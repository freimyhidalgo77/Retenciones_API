using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Retenciones.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retenciones.Data.DI
{
    public static class DBContextRegistrar
    {
        public static IServiceCollection RegisterDbContextFactory(this IServiceCollection services)
        {
            services.AddDbContextFactory<RetencionContext>(o => o.UseSqlServer("Name=sqlConStr"));
            return services;
        }

    }
}
