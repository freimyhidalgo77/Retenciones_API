using Microsoft.EntityFrameworkCore;
using Retenciones.Abstraccion;
using Retenciones.Data.Context;
using Retenciones.Data.Model;
using Retenciones.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;



namespace Retenciones.Services
{
    public class RetencionService(IDbContextFactory<RetencionContext> DbFactory) : IRetencionService
    {
        private async Task<bool> Existe(int retencionId)
        {
            await using var context = await DbFactory.CreateDbContextAsync();
            return await context.retencion.AnyAsync(e => e.RetencionId == retencionId);
        }

        private async Task<bool> Insertar(RetencionesDTO retencionDTO)
        {
            await using var context = await DbFactory.CreateDbContextAsync();
            var retencion = new Retencion()
            {
                RetencionId = retencionDTO.RetencionID,
                descripcion = retencionDTO.descripcion,
                monto = retencionDTO.monto,



            };
            context.retencion.Add(retencion);
            var save = await context.SaveChangesAsync() > 0;
            retencionDTO.RetencionID = retencionDTO.RetencionID;
            return save;
        }

        private async Task<bool> Modificar(RetencionesDTO retencionDTO)
        {
            await using var context = await DbFactory.CreateDbContextAsync();
            var retencion = new Retencion()
            {
                RetencionId = retencionDTO.RetencionID,
                descripcion = retencionDTO.descripcion,
                monto = retencionDTO.monto,

            };
            context.Update(retencion);
            var modificado = await context.SaveChangesAsync() > 0;
            return modificado;
        }

        public async Task<bool> Guardar(RetencionesDTO retencion)
        {
            if (!await Existe(retencion.RetencionID))
            {
                return await Insertar(retencion);
            }
            else
            {
                return await Modificar(retencion);
            }
        }

        public async Task<bool> Eliminar(int retencionId)
        {
            await using var context = await DbFactory.CreateDbContextAsync();
            return await context.retencion
                .Where(e => e.RetencionId == retencionId)
                .ExecuteDeleteAsync() > 0;
        }

        public async Task<RetencionesDTO> Buscar(int id)
        {
            await using var context = await DbFactory.CreateDbContextAsync();
            var retencion = await context.retencion
                .Where(e => e.RetencionId == id)
                .Select(c => new RetencionesDTO()
                {
                    RetencionID = c.RetencionId,
                    descripcion = c.descripcion,
                    monto = c.monto,



                }).FirstOrDefaultAsync();

            return retencion ?? new RetencionesDTO();
        }

        public async Task<List<RetencionesDTO>> Listar(Expression<Func<RetencionesDTO, bool>> criterio)
        {
            await using var context = await DbFactory.CreateDbContextAsync();
            return await context.retencion
                .Select(c => new RetencionesDTO()
                {
                    RetencionID = c.RetencionId,
                    descripcion = c.descripcion,
                    monto = c.monto,


                })
                .Where(criterio)
                .ToListAsync();
        }

        public async Task<bool> RetencionExiste(int id, string descripcion)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.retencion
                .AnyAsync(e => e.RetencionId != id && e.descripcion.ToLower().Equals(descripcion.ToLower()));
        }


    }
}
