using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Retenciones.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retenciones.Data
{
    public class RetencionContextFactory : IDesignTimeDbContextFactory<RetencionContext>
    {
        public RetencionContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<RetencionContext>();

            var connectionString = "Server=tcp:cotzdb.database.windows.net,1433;Initial Catalog=CotizacionesDb;Persist Security Info=False;User ID=freimyHidalgo;Password=srt10db9&;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

            optionsBuilder.UseSqlServer(connectionString);

            return new RetencionContext(optionsBuilder.Options);
        }
    }
}
