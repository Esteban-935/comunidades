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
    public class CatalogoPoblacionService
    {
        private readonly MembranaComunidadesBDContext _context;

        public CatalogoPoblacionService(MembranaComunidadesBDContext context)
        {
            _context = context;
        }

        public async Task<List<CatalogoPoblacionResponse>> GetCatalogoPoblacionesAsync()
        {
            return await _context.CatalogoPoblacions
                .Select(cp => new CatalogoPoblacionResponse
                {
                    IdCatalogoPoblacion = cp.IdCatalogoPoblacion,
                    Grupo = cp.Grupo,
                    Tipo = cp.Tipo,
                    FechaRegistro = DateTime.Now,
                    FechaActualizacion = DateTime.Now,
                    IdUsuarioRegistro = cp.IdUsuarioRegistro,
                    IdUsuarioActualizacion = cp.IdUsuarioActualizacion
                }).ToListAsync();
        }

        public async Task<CatalogoPoblacionResponse> GetCatalogoPoblacionByIdAsync(Guid id)
        {
            var catalogoPoblacion = await _context.CatalogoPoblacions.FindAsync(id);

            if (catalogoPoblacion == null)
            {
                return null;
            }

            return new CatalogoPoblacionResponse
            {
                IdCatalogoPoblacion = catalogoPoblacion.IdCatalogoPoblacion,
                Grupo = catalogoPoblacion.Grupo,
                Tipo = catalogoPoblacion.Tipo,
                FechaRegistro = DateTime.Now,
                FechaActualizacion = DateTime.Now,
                IdUsuarioRegistro = catalogoPoblacion.IdUsuarioRegistro,
                IdUsuarioActualizacion = catalogoPoblacion.IdUsuarioActualizacion
            };
        }

        public async Task<CatalogoPoblacionResponse> CreateCatalogoPoblacionAsync(CatalogoPoblacionRequest request)
        {
            var catalogoPoblacion = new CatalogoPoblacion
            {
                IdCatalogoPoblacion = Guid.NewGuid(),
                Grupo = request.Grupo,
                Tipo = request.Tipo,
                FechaRegistro = DateTime.Now,
                IdUsuarioRegistro = request.IdUsuarioRegistro,
                //IdUsuarioActualizacion = request.IdUsuarioActualizacion
            };

            _context.CatalogoPoblacions.Add(catalogoPoblacion);
            await _context.SaveChangesAsync();

            return new CatalogoPoblacionResponse
            {
                IdCatalogoPoblacion = Guid.NewGuid(),
                Grupo = catalogoPoblacion.Grupo,
                Tipo = catalogoPoblacion.Tipo,
                FechaRegistro = DateTime.Now,
                //FechaActualizacion = DateTime.Now,
                IdUsuarioRegistro = catalogoPoblacion.IdUsuarioRegistro,
                //IdUsuarioActualizacion = catalogoPoblacion.IdUsuarioActualizacion
            };
        }

        public async Task<bool> UpdateCatalogoPoblacionAsync(Guid id, CatalogoPoblacionRequest request)
        {
            var catalogoPoblacion = await _context.CatalogoPoblacions.FindAsync(id);

            if (catalogoPoblacion == null)
            {
                return false;
            }

            catalogoPoblacion.Grupo = request.Grupo;
            catalogoPoblacion.Tipo = request.Tipo;
            catalogoPoblacion.FechaActualizacion = DateTime.Now;
            catalogoPoblacion.IdUsuarioActualizacion = request.IdUsuarioActualizacion;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteCatalogoPoblacionAsync(Guid id)
        {
            var catalogoPoblacion = await _context.CatalogoPoblacions.FindAsync(id);

            if (catalogoPoblacion == null)
            {
                return false;
            }

            _context.CatalogoPoblacions.Remove(catalogoPoblacion);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}