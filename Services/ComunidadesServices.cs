using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Comunidades.Data;
using Comunidades.Data.Models;
using Comunidades.Data.Request;
using Comunidades.Data.Response;
using Microsoft.EntityFrameworkCore;

namespace Comunidades.Services
{
    public class ComunidadeService
    {
        private readonly MembranaComunidadesBDContext _context;

        public ComunidadeService(MembranaComunidadesBDContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ComunidadeResponse>> GetAll()
        {
            var comunidades = await _context.Comunidades
                .Select(c => new ComunidadeResponse
                {
                    IdComunidad = c.IdComunidad,
                    Nombre = c.Nombre,
                    Cabecera = c.Cabecera,
                    Direccion = c.Direccion,
                    IdEstatus = c.IdEstatus,
                    IdDistrito = c.IdDistrito,
                    FechaRegistro = c.FechaRegistro,
                    FechaUpdate = c.FechaUpdate,
                    IdUsuario = c.IdUsuario,
                    IdUsuarioUpdate = c.IdUsuarioupdate
                })
                .ToListAsync();

            return comunidades;
        }

        public async Task<ComunidadeResponse> GetById(Guid id)
        {
            var comunidade = await _context.Comunidades
                .Where(c => c.IdComunidad == id)
                .Select(c => new ComunidadeResponse
                {
                    IdComunidad = c.IdComunidad,
                    Nombre = c.Nombre,
                    Cabecera = c.Cabecera,
                    Direccion = c.Direccion,
                    IdEstatus = c.IdEstatus,
                    IdDistrito = c.IdDistrito,
                    FechaRegistro = c.FechaRegistro,
                    FechaUpdate = c.FechaUpdate,
                    IdUsuario = c.IdUsuario,
                    IdUsuarioUpdate = c.IdUsuarioupdate
                })
                .FirstOrDefaultAsync();

            return comunidade;
        }

        public async Task<ComunidadeResponse> Create(ComunidadeRequest request)
        {
            var comunidad = new Comunidade
            {
                IdComunidad = request.IdComunidad, //modificado
                Nombre = request.Nombre,
                Cabecera = request.Cabecera,
                Direccion = request.Direccion,
                IdEstatus = request.IdEstatus,
                IdDistrito = request.IdDistrito,
                FechaRegistro = DateTime.Now,
                IdUsuario = request.IdUsuario,
               // IdUsuarioupdate = request.IdUsuarioUpdate
            };

            _context.Comunidades.Add(comunidad);
            await _context.SaveChangesAsync();

            return new ComunidadeResponse
            {
                IdComunidad = comunidad.IdComunidad,
                Nombre = comunidad.Nombre,
                Cabecera = comunidad.Cabecera,
                Direccion = comunidad.Direccion,
                IdEstatus = comunidad.IdEstatus,
                IdDistrito = comunidad.IdDistrito,
                FechaRegistro = comunidad.FechaRegistro,
                IdUsuario = comunidad.IdUsuario,
                IdUsuarioUpdate = comunidad.IdUsuarioupdate
            };
        }

        public async Task<ComunidadeResponse> Update(Guid id, ComunidadeRequest request)
        {
            var comunidad = await _context.Comunidades.FindAsync(id);
            if (comunidad == null)
            {
                return null;
            }

            // comunidad.IdComunidad = request.IdComunidad;  //modificado
            comunidad.Nombre = request.Nombre;
            comunidad.Cabecera = request.Cabecera;
            comunidad.Direccion = request.Direccion;
            comunidad.IdEstatus = request.IdEstatus;
            comunidad.IdDistrito = request.IdDistrito;
            comunidad.FechaUpdate = DateTime.Now;
           // comunidad.IdUsuarioUpdate = request.IdUsuarioupdate;
            comunidad.IdUsuarioupdate = request.IdUsuarioupdate; //modificado otra vez

            await _context.SaveChangesAsync();

            return new ComunidadeResponse
            {
                // IdComunidad = comunidad.IdComunidad,
                Nombre = comunidad.Nombre,
                Cabecera = comunidad.Cabecera,
                Direccion = comunidad.Direccion,
                IdEstatus = comunidad.IdEstatus,
                IdDistrito = comunidad.IdDistrito,
                FechaRegistro = comunidad.FechaRegistro,
                FechaUpdate = comunidad.FechaUpdate,
                IdUsuario = comunidad.IdUsuario,
                IdUsuarioUpdate = comunidad.IdUsuarioupdate
            };
        }

        public async Task<bool> Delete(Guid id)
        {
            var comunidad = await _context.Comunidades.FindAsync(id);
            if (comunidad == null)
            {
                return false;
            }

            _context.Comunidades.Remove(comunidad);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}