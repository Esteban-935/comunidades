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
    public class ReporteService
    {
        private readonly MembranaComunidadesBDContext _context;

        public ReporteService(MembranaComunidadesBDContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ReporteResponse>> GetAllReportesAsync()
        {
            return await _context.Reportes
                .Select(r => new ReporteResponse
                {
                    IdReporte = r.IdReporte,
                    IdConcepto = r.IdConcepto,
                    Valor = r.Valor,
                    IdMes = r.IdMes,
                    IdPeriodo = r.IdPeriodo,
                    IdComunidad = r.IdComunidad,
                    FechaRegistro = r.FechaRegistro,
                    FechaActualizacion = r.FechaActualizacion,
                    IdUsuarioRegistro = r.IdUsuarioRegistro,
                    IdUsuarioActualizacion = r.IdUsuarioActualizacion
                })
                .ToListAsync();
        }

        public async Task<ReporteResponse> GetReporteByIdAsync(Guid id)
        {
            var reporte = await _context.Reportes.FindAsync(id);

            if (reporte == null)
            {
                return null;
            }

            return new ReporteResponse
            {
                IdReporte = reporte.IdReporte,
                IdConcepto = reporte.IdConcepto,
                Valor = reporte.Valor,
                IdMes = reporte.IdMes,
                IdPeriodo = reporte.IdPeriodo,
                IdComunidad = reporte.IdComunidad,
                FechaRegistro = reporte.FechaRegistro,
                FechaActualizacion = reporte.FechaActualizacion,
                IdUsuarioRegistro = reporte.IdUsuarioRegistro,
                IdUsuarioActualizacion = reporte.IdUsuarioActualizacion
            };
        }

        public async Task<ReporteResponse> CreateReporteAsync(ReporteRequest request)
        {
            var reporte = new Reporte
            {
                IdReporte = Guid.NewGuid(),
                IdConcepto = request.IdConcepto,
                Valor = request.Valor,
                IdMes = request.IdMes,
                IdPeriodo = request.IdPeriodo,
                IdComunidad = request.IdComunidad,
                FechaRegistro = DateTime.Now,
                IdUsuarioRegistro = request.IdUsuarioRegistro,
                //IdUsuarioActualizacion = request.IdUsuarioActualizacion
            };

            _context.Reportes.Add(reporte);
            await _context.SaveChangesAsync();

            return new ReporteResponse
            {
                IdReporte = Guid.NewGuid(),
                IdConcepto = reporte.IdConcepto,
                Valor = reporte.Valor,
                IdMes = reporte.IdMes,
                IdPeriodo = reporte.IdPeriodo,
                IdComunidad = reporte.IdComunidad,
                FechaRegistro = reporte.FechaRegistro,
                //FechaActualizacion = reporte.FechaActualizacion,
                IdUsuarioRegistro = reporte.IdUsuarioRegistro,
                //IdUsuarioActualizacion = reporte.IdUsuarioActualizacion
            };
        }

        public async Task<bool> UpdateReporteAsync(Guid id, ReporteRequest request)
        {
            var reporte = await _context.Reportes.FindAsync(id);

            if (reporte == null)
            {
                return false;
            }

            reporte.IdConcepto = request.IdConcepto;
            reporte.Valor = request.Valor;
            reporte.IdMes = request.IdMes;
            reporte.IdPeriodo = request.IdPeriodo;
            reporte.IdComunidad = request.IdComunidad;
            reporte.FechaActualizacion = DateTime.Now;
            reporte.IdUsuarioActualizacion = request.IdUsuarioActualizacion;

            _context.Reportes.Update(reporte);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteReporteAsync(Guid id)
        {
            var reporte = await _context.Reportes.FindAsync(id);

            if (reporte == null)
            {
                return false;
            }

            _context.Reportes.Remove(reporte);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}