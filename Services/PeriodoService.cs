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
    public class PeriodoService
    {
        private readonly MembranaComunidadesBDContext _context;

        public PeriodoService(MembranaComunidadesBDContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PeriodoResponse>> GetAllPeriodosAsync()
        {
            return await _context.Periodos
                .Select(p => new PeriodoResponse
                {
                    IdPeriodo = p.IdPeriodo,
                    Nombre = p.Nombre,
                    Visible = p.Visible,
                    FechaRegistro = p.FechaRegistro,
                    FechaActualizacion = p.FechaActualizacion,
                    IdUsuarioRegistro = p.IdUsuarioRegistro,
                    IdUsuarioActualizacion = p.IdUsuarioActualizacion
                })
                .ToListAsync();
        }

        public async Task<PeriodoResponse> GetPeriodoByIdAsync(Guid id)
        {
            var periodo = await _context.Periodos.FindAsync(id);

            if (periodo == null)
            {
                return null;
            }

            return new PeriodoResponse
            {
                IdPeriodo = periodo.IdPeriodo,
                Nombre = periodo.Nombre,
                Visible = periodo.Visible,
                FechaRegistro = periodo.FechaRegistro,
                FechaActualizacion = periodo.FechaActualizacion,
                IdUsuarioRegistro = periodo.IdUsuarioRegistro,
                IdUsuarioActualizacion = periodo.IdUsuarioActualizacion
            };
        }

        public async Task<PeriodoResponse> CreatePeriodoAsync(PeriodoRequest request)
        {
            var periodo = new Periodo
            {
                IdPeriodo = Guid.NewGuid(),
                Nombre = request.Nombre,
                Visible = request.Visible,
                FechaRegistro = DateTime.Now,
                //FechaActualizacion = null,
                IdUsuarioRegistro = request.IdUsuarioRegistro,
                //IdUsuarioActualizacion = request.IdUsuarioActualizacion
            };

            _context.Periodos.Add(periodo);
            await _context.SaveChangesAsync();

            return new PeriodoResponse
            {
                IdPeriodo = Guid.NewGuid(),
                Nombre = periodo.Nombre,
                Visible = periodo.Visible,
                FechaRegistro = DateTime.Now,
                //FechaActualizacion = periodo.FechaActualizacion,
                IdUsuarioRegistro = periodo.IdUsuarioRegistro,
                //IdUsuarioActualizacion = periodo.IdUsuarioActualizacion
            };
        }

        public async Task<bool> UpdatePeriodoAsync(Guid id, PeriodoRequest request)
        {
            var periodo = await _context.Periodos.FindAsync(id);

            if (periodo == null)
            {
                return false;
            }

            periodo.Nombre = request.Nombre;
            periodo.Visible = request.Visible;
            periodo.FechaActualizacion = DateTime.Now;
            periodo.IdUsuarioActualizacion = request.IdUsuarioActualizacion;

            _context.Periodos.Update(periodo);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeletePeriodoAsync(Guid id)
        {
            var periodo = await _context.Periodos.FindAsync(id);

            if (periodo == null)
            {
                return false;
            }

            _context.Periodos.Remove(periodo);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}