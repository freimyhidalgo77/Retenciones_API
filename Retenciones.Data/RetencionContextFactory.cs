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

            var connectionString = "workstation id=freimyDbo.mssql.somee.com;packet size=4096;user id=freimyHidalgo77;pwd=srt10db9;data source=freimyDbo.mssql.somee.com;persist security info=False;initial catalog=freimyDbo;TrustServerCertificate=True;";

            optionsBuilder.UseSqlServer(connectionString);

            return new RetencionContext(optionsBuilder.Options);
        }
    }
}
