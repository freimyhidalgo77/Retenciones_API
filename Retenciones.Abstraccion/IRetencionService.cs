using Retenciones.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Retenciones.Abstraccion
{
    public interface IRetencionService
    {
        Task<bool> Guardar(RetencionesDTO retenciones);
        Task<bool> Eliminar(int retencionId);
        Task<RetencionesDTO> Buscar(int id);
        Task<List<RetencionesDTO>> Listar(Expression<Func<RetencionesDTO, bool>> criterio);
        Task<bool> RetencionExiste(int id, string descripcion);


    }
}
