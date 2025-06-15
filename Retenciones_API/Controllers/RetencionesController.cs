using Microsoft.AspNetCore.Mvc;
using Retenciones.Abstraccion;
using Retenciones.Data.Context;
using Retenciones.Data.Model;
using Retenciones.Domain.DTO;
using Retenciones.Services;

namespace Retenciones_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class RetencionesController(IRetencionService retencionService) : ControllerBase
    {

        private readonly RetencionContext _context;

        // GET: api/retenciones
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RetencionesDTO>>> GetRetenciones()
        {
            return await retencionService.Listar(t => true);
        }

        // GET: api/Retenciones/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RetencionesDTO>> GetRetencion(int id)
        {
            return await retencionService.Buscar(id);
        }

        // PUT: api/Retenciones/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCliente(int id, RetencionesDTO retencionesDTO)
        {
            if (id != retencionesDTO.RetencionID)
            {
                return BadRequest();
            }

            // Actualizar la retencion
            await retencionService.Guardar(retencionesDTO);
            return NoContent();
        }

        // POST: api/Retenciones
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Retencion>> PostCliente(RetencionesDTO retencionesDTO)
        {
            await retencionService.Guardar(retencionesDTO);
            return CreatedAtAction("GetRetencion", new { id = retencionesDTO.RetencionID }, retencionesDTO);

        }

        // DELETE: api/Retenciones/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRetencion(int id)
        {
            await retencionService.Eliminar(id);
            return NoContent();
        }

        private bool RetencionExists(int id)
        {
            return _context.retencion.Any(e => e.RetencionId == id);
        }

    }
}
