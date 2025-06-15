using Microsoft.EntityFrameworkCore;
using Retenciones.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retenciones.Data.Context
{
    public class RetencionContext: DbContext
    {

        public RetencionContext(DbContextOptions<RetencionContext> options) : base(options) { }

        public DbSet<Retencion> retencion { get; set; }


    }
}
