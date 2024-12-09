using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Comunidades.Data;
using Comunidades.Data.Models;
using Comunidades.Data.Request;
using Comunidades.Data.Response;
using Microsoft.EntityFrameworkCore;

namespace Comunidades.Services
{
    public class DetallePoblacionService
    {
        private readonly MembranaComunidadesBDContext _context;

        public DetallePoblacionService(MembranaComunidadesBDContext context)
        {
            _context = context;
        }

        public async Task<List<DetallePoblacionResponse>> GetAllDetallePoblacionAsync()
        {
            var detallesPoblacion = await _context.DetallePoblacions
                .Select(dp => new DetallePoblacionResponse
                {
                    IdDetallePoblacion = dp.IdDetallePoblacion,
                    IdCatalogoPoblacion = dp.IdCatalogoPoblacion,
                    Cantidad = dp.Cantidad,
                    IdConfiguracionlocal = dp.IdConfiguracionlocal,
                    FechaRegistro = DateTime.Now,
                    FechaActualizacion = DateTime.Now,
                    IdUsuarioRegistro = dp.IdUsuarioRegistro,
                    IdUsuarioActualizacion = dp.IdUsuarioActualizacion,
                    FechaSesion = dp.FechaSesion
                }).ToListAsync();
            return detallesPoblacion;
        }

        public async Task<DetallePoblacionResponse> GetDetallePoblacionByIdAsync(Guid id)
        {
            var detallePoblacion = await _context.DetallePoblacions
                .FirstOrDefaultAsync(dp => dp.IdDetallePoblacion == id);

            if (detallePoblacion == null)
            {
                return null;
            }

            return new DetallePoblacionResponse
            {
                IdDetallePoblacion = detallePoblacion.IdDetallePoblacion,
                IdCatalogoPoblacion = detallePoblacion.IdCatalogoPoblacion,
                Cantidad = detallePoblacion.Cantidad,
                IdConfiguracionlocal = detallePoblacion.IdConfiguracionlocal,
                FechaRegistro = DateTime.Now,
                FechaActualizacion = DateTime.Now,
                IdUsuarioRegistro = detallePoblacion.IdUsuarioRegistro,
                IdUsuarioActualizacion = detallePoblacion.IdUsuarioActualizacion,
                FechaSesion = detallePoblacion.FechaSesion
            };
        }

        public async Task<DetallePoblacionResponse> CreateDetallePoblacionAsync(DetallePoblacionRequest request)
        {
            var detallePoblacion = new DetallePoblacion
            {
                IdDetallePoblacion = Guid.NewGuid(),
                IdCatalogoPoblacion = request.IdCatalogoPoblacion,
                Cantidad = request.Cantidad,
                IdConfiguracionlocal = request.IdConfiguracionlocal,
                FechaRegistro = DateTime.Now,
                IdUsuarioRegistro = request.IdUsuarioRegistro,
                IdUsuarioActualizacion = request.IdUsuarioActualizacion,
                FechaSesion = request.FechaSesion
            };

            _context.DetallePoblacions.Add(detallePoblacion);
            await _context.SaveChangesAsync();

            return new DetallePoblacionResponse
            {
                IdDetallePoblacion = Guid.NewGuid(),
                IdCatalogoPoblacion = detallePoblacion.IdCatalogoPoblacion,
                Cantidad = detallePoblacion.Cantidad,
                IdConfiguracionlocal = detallePoblacion.IdConfiguracionlocal,
                FechaRegistro = DateTime.Now,
                FechaActualizacion = DateTime.Now,
                IdUsuarioRegistro = detallePoblacion.IdUsuarioRegistro,
                IdUsuarioActualizacion = detallePoblacion.IdUsuarioActualizacion,
                FechaSesion = detallePoblacion.FechaSesion
            };
        }

        public async Task<bool> UpdateDetallePoblacionAsync(Guid id, DetallePoblacionRequest request)
        {
            var detallePoblacion = await _context.DetallePoblacions.FindAsync(id);

            if (detallePoblacion == null)
            {
                return false;
            }

            detallePoblacion.IdCatalogoPoblacion = request.IdCatalogoPoblacion;
            detallePoblacion.Cantidad = request.Cantidad;
            detallePoblacion.IdConfiguracionlocal = request.IdConfiguracionlocal;
            detallePoblacion.FechaActualizacion = DateTime.Now;
            detallePoblacion.IdUsuarioActualizacion = request.IdUsuarioActualizacion;
            detallePoblacion.FechaSesion = request.FechaSesion;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteDetallePoblacionAsync(Guid id)
        {
            var detallePoblacion = await _context.DetallePoblacions.FindAsync(id);

            if (detallePoblacion == null)
            {
                return false;
            }

            _context.DetallePoblacions.Remove(detallePoblacion);
            await _context.SaveChangesAsync();
            return true;
        }

    }
}