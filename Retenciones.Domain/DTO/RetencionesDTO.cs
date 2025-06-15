using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retenciones.Domain.DTO
{
    public class RetencionesDTO
    {
        public int RetencionID { get; set; }

        public string? descripcion { get; set; }

        public double monto { get; set; }

    }
}
