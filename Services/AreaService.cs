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
    public class AreaService
    {
        private readonly MembranaComunidadesBDContext _context;

        public AreaService(MembranaComunidadesBDContext context)
        {
            _context = context;
        }

        public async Task<List<AreaResponse>> GetAreasAsync()
        {
            return await _context.Areas
                .Select(a => new AreaResponse
                {
                    IdArea = a.IdArea,
                    Nombre = a.Nombre,
                    FechaRegistro = DateTime.Now,
                    FechaActualizacion = DateTime.Now,
                    IdUsuarioRegistro = a.IdUsuarioRegistro,
                    IdUsuarioActualizacion = a.IdUaurioActualizacion
                }).ToListAsync();
        }

        public async Task<AreaResponse> GetAreaByIdAsync(Guid id)
        {
            var area = await _context.Areas.FindAsync(id);

            if (area == null)
            {
                return null;
            }

            return new AreaResponse
            {
                IdArea = area.IdArea,
                Nombre = area.Nombre,
                FechaRegistro = DateTime.Now,
                FechaActualizacion = DateTime.Now,
                IdUsuarioRegistro = area.IdUsuarioRegistro,
                IdUsuarioActualizacion = area.IdUaurioActualizacion
            };
        }

        public async Task<AreaResponse> CreateAreaAsync(AreaRequest request)
        {
            var area = new Area
            {
                IdArea = Guid.NewGuid(),
                Nombre = request.Nombre,
                FechaRegistro = DateTime.Now,
                IdUsuarioRegistro = request.IdUsuarioRegistro,
                IdUaurioActualizacion = request.IdUsuarioActualizacion
            };

            _context.Areas.Add(area);
            await _context.SaveChangesAsync();

            return new AreaResponse
            {
                IdArea = area.IdArea,
                Nombre = area.Nombre,
                FechaRegistro = DateTime.Now,
                FechaActualizacion = DateTime.Now,
                IdUsuarioRegistro = area.IdUsuarioRegistro,
                IdUsuarioActualizacion = area.IdUaurioActualizacion
            };
        }

        public async Task<bool> UpdateAreaAsync(Guid id, AreaRequest request)
        {
            var area = await _context.Areas.FindAsync(id);

            if (area == null)
            {
                return false;
            }

            area.Nombre = request.Nombre;
            area.FechaActualizacion = DateTime.Now;
            area.IdUaurioActualizacion = request.IdUsuarioActualizacion;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAreaAsync(Guid id)
        {
            var area = await _context.Areas.FindAsync(id);

            if (area == null)
            {
                return false;
            }

            _context.Areas.Remove(area);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}