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
    public class DistritoService
    {
        private readonly MembranaComunidadesBDContext _context;

        public DistritoService(MembranaComunidadesBDContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<DistritoResponse>> GetAll()
        {
            var distritos = await _context.Distritos
                .Select(d => new DistritoResponse
                {
                    IdDistrito = d.IdDistrito,
                    Nombre = d.Nombre,
                    Entidad = d.Entidad,
                    IdEstatus = d.IdEstatus,
                    IdTerritorio = d.IdTerritorio,
                    FechaRegistro = d.FechaRegistro,
                    FechaUpdate = d.FechaUpdate,
                    IdUsuarioRegistro = d.IdUsuarioregistro,
                    IdUsuarioUpdate = d.IdUsuarioupdate
                })
                .ToListAsync();

            return distritos;
        }

        public async Task<DistritoResponse> GetById(Guid id)
        {
            var distrito = await _context.Distritos
                .Where(d => d.IdDistrito == id)
                .Select(d => new DistritoResponse
                {
                    IdDistrito = d.IdDistrito,
                    Nombre = d.Nombre,
                    Entidad = d.Entidad,
                    IdEstatus = d.IdEstatus,
                    IdTerritorio = d.IdTerritorio,
                    FechaRegistro = d.FechaRegistro,
                    FechaUpdate = d.FechaUpdate,
                    IdUsuarioRegistro = d.IdUsuarioregistro,
                    IdUsuarioUpdate = d.IdUsuarioupdate
                })
                .FirstOrDefaultAsync();

            return distrito;
        }

        public async Task<DistritoResponse> Create(DistritoRequest request)
        {
            var distrito = new Distrito
            {
                //agregar id resjistro
                //agregar id usuario
                IdDistrito = request.IdDistrito,
                Nombre = request.Nombre,
                Entidad = request.Entidad,
                IdEstatus = request.IdEstatus,
                IdTerritorio = request.IdTerritorio,
                FechaRegistro = DateTime.Now,
                IdUsuarioregistro = request.IdUsuarioRegistro
            };

            _context.Distritos.Add(distrito);
            await _context.SaveChangesAsync();

            return new DistritoResponse
            {
                IdDistrito = distrito.IdDistrito,
                Nombre = distrito.Nombre,
                Entidad = distrito.Entidad,
                IdEstatus = distrito.IdEstatus,
                IdTerritorio = distrito.IdTerritorio,
                FechaRegistro = distrito.FechaRegistro,
                IdUsuarioRegistro = distrito.IdUsuarioregistro
            };
        }

        public async Task<DistritoResponse> Update(Guid id, DistritoRequest request)
        {
            var distrito = await _context.Distritos.FindAsync(id);
            if (distrito == null)
            {
                return null;
            }

            distrito.Nombre = request.Nombre;
            distrito.Entidad = request.Entidad;
            distrito.IdEstatus = request.IdEstatus;
            distrito.IdTerritorio = request.IdTerritorio;
            distrito.FechaUpdate = DateTime.Now;
            distrito.IdUsuarioupdate = request.IdUsuarioUpdate;

            _context.Distritos.Update(distrito);
            await _context.SaveChangesAsync();

            return new DistritoResponse
            {
                IdDistrito = distrito.IdDistrito,
                Nombre = distrito.Nombre,
                Entidad = distrito.Entidad,
                IdEstatus = distrito.IdEstatus,
                IdTerritorio = distrito.IdTerritorio,
                FechaRegistro = distrito.FechaRegistro,
                FechaUpdate = distrito.FechaUpdate,
                IdUsuarioRegistro = distrito.IdUsuarioregistro,
                IdUsuarioUpdate = distrito.IdUsuarioupdate
            };
        }

        public async Task<bool> Delete(Guid id)
        {
            var distrito = await _context.Distritos.FindAsync(id);
            if (distrito == null)
            {
                return false;
            }

            _context.Distritos.Remove(distrito);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}