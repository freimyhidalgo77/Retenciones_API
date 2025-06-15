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

        // GET: api/Clientes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RetencionesDTO>>> GetRetenciones()
        {
            return await retencionService.Listar(t => true);
        }

        // GET: api/Clientes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RetencionesDTO>> GetRetencion(int id)
        {
            return await retencionService.Buscar(id);
        }

        // PUT: api/Clientes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCliente(int id, RetencionesDTO retencionesDTO)
        {
            if (id != retencionesDTO.RetencionID)
            {
                return BadRequest();
            }

            // Actualizar el cliente
            await retencionService.Guardar(retencionesDTO);
            return NoContent();
        }

        // POST: api/Clientes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Retencion>> PostCliente(RetencionesDTO retencionesDTO)
        {
            await retencionService.Guardar(retencionesDTO);
            return CreatedAtAction("GetClientes", new { id = retencionesDTO.RetencionID }, retencionesDTO);

        }

        // DELETE: api/Clientes/5
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
