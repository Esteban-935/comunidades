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
    public class EstatusService
    {
        private readonly MembranaComunidadesBDContext _context;

        public EstatusService(MembranaComunidadesBDContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<EstatusResponse>> GetAll()
        {
            var estatus = await _context.Estatuses
                .Select(e => new EstatusResponse
                {
                    IdEstatus = e.IdEstatus,
                    Nombre = e.Nombre,
                    Tipo = e.Tipo,
                    FechaRegistro = e.FechaRegistro,
                    FechaUpdate = e.FechaUpdate,
                    IdUsuario = e.IdUsuarioRegistro
                })
                .ToListAsync();

            return estatus;
        }

        public async Task<EstatusResponse> GetById(Guid id)
        {
            var estatus = await _context.Estatuses
                .Where(e => e.IdEstatus == id)
                .Select(e => new EstatusResponse
                {
                    IdEstatus = e.IdEstatus,
                    Nombre = e.Nombre,
                    Tipo = e.Tipo,
                    FechaRegistro = e.FechaRegistro,
                    FechaUpdate = e.FechaUpdate,
                    IdUsuario = e.IdUsuarioRegistro
                })
                .FirstOrDefaultAsync();

            return estatus;
        }

        public async Task<EstatusResponse> Create(EstatusRequest request)
        {
            var estatus = new Estatus
            {
                Nombre = request.Nombre,
                Tipo = request.Tipo,
                FechaRegistro = DateTime.Now,
                IdUsuarioRegistro = request.IdUsuario
            };

            _context.Estatuses.Add(estatus);
            await _context.SaveChangesAsync();

            return new EstatusResponse
            {
                IdEstatus = estatus.IdEstatus,
                Nombre = estatus.Nombre,
                Tipo = estatus.Tipo,
                FechaRegistro = estatus.FechaRegistro,
                IdUsuario = estatus.IdUsuarioRegistro
            };
        }

        public async Task<EstatusResponse> Update(Guid id, EstatusRequest request)
        {
            var estatus = await _context.Estatuses.FindAsync(id);
            if (estatus == null)
            {
                return null;
            }

            estatus.Nombre = request.Nombre;
            estatus.Tipo = request.Tipo;
            estatus.FechaUpdate = DateTime.Now;
            estatus.IdUsuarioRegistro = request.IdUsuario;

            _context.Estatuses.Update(estatus);
            await _context.SaveChangesAsync();

            return new EstatusResponse
            {
                IdEstatus = estatus.IdEstatus,
                Nombre = estatus.Nombre,
                Tipo = estatus.Tipo,
                FechaRegistro = estatus.FechaRegistro,
                FechaUpdate = estatus.FechaUpdate,
                IdUsuario = estatus.IdUsuarioRegistro
            };
        }

        public async Task<bool> Delete(Guid id)
        {
            var estatus = await _context.Estatuses.FindAsync(id);
            if (estatus == null)
            {
                return false;
            }

            _context.Estatuses.Remove(estatus);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}