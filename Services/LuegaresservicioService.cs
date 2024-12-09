using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Comunidades.Data;
using Comunidades.Data.Models;
using Comunidades.Data.Request;
using Comunidades.Data.Response;

namespace Comunidades.Services
{
    public class LugaresservicioService
    {
        private readonly MembranaComunidadesBDContext _context;

        public LugaresservicioService(MembranaComunidadesBDContext context)
        {
            _context = context;
        }

        public IEnumerable<LugaresservicioResponse> GetAll()
        {
            return _context.Lugaresservicios
                .Select(ls => new LugaresservicioResponse
                {
                    IdLugarservicio = ls.IdLugarservicio,
                    Nombre = ls.Nombre,
                    Tipo = ls.Tipo,
                    FechaRegistro = ls.FechaRegistro,
                    FechaUpdate = ls.FechaUpdate,
                    IdUsuarioregistro = ls.IdUsuarioregistro,
                    IdUsuarioupdate = ls.IdUsuarioupdate,
                    Vigencia = ls.Vigencia
                })
                .ToList();
        }

        public LugaresservicioResponse GetById(Guid id)
        {
            var lugaresservicio = _context.Lugaresservicios.Find(id);
            if (lugaresservicio == null)
            {
                return null;
            }

            return new LugaresservicioResponse
            {
                IdLugarservicio = lugaresservicio.IdLugarservicio,
                Nombre = lugaresservicio.Nombre,
                Tipo = lugaresservicio.Tipo,
                FechaRegistro = lugaresservicio.FechaRegistro,
                FechaUpdate = lugaresservicio.FechaUpdate,
                IdUsuarioregistro = lugaresservicio.IdUsuarioregistro,
                IdUsuarioupdate = lugaresservicio.IdUsuarioupdate,
                Vigencia = lugaresservicio.Vigencia
            };
        }

        public LugaresservicioResponse Create(LugaresservicioRequest request)
        {
            var lugaresservicio = new Lugaresservicio
            {
                IdLugarservicio = Guid.NewGuid(),
                Nombre = request.Nombre,
                Tipo = request.Tipo,
                FechaRegistro = DateTime.Now,
                IdUsuarioregistro = request.IdUsuarioregistro,
                Vigencia = true // Valor por defecto
            };

            _context.Lugaresservicios.Add(lugaresservicio);
            _context.SaveChanges();

            return new LugaresservicioResponse
            {
                IdLugarservicio = lugaresservicio.IdLugarservicio,
                Nombre = lugaresservicio.Nombre,
                Tipo = lugaresservicio.Tipo,
                FechaRegistro = lugaresservicio.FechaRegistro,
                IdUsuarioregistro = lugaresservicio.IdUsuarioregistro,
                Vigencia = lugaresservicio.Vigencia
            };
        }

        public bool Update(Guid id, LugaresservicioRequest request)
        {
            var lugaresservicio = _context.Lugaresservicios.Find(id);
            if (lugaresservicio == null)
            {
                return false;
            }

            lugaresservicio.Nombre = request.Nombre;
            lugaresservicio.Tipo = request.Tipo;
            lugaresservicio.FechaUpdate = DateTime.Now;
            lugaresservicio.IdUsuarioupdate = request.IdUsuarioregistro;

            _context.SaveChanges();
            return true;
        }

        public bool Delete(Guid id)
        {
            var lugaresservicio = _context.Lugaresservicios.Find(id);
            if (lugaresservicio == null)
            {
                return false;
            }

            _context.Lugaresservicios.Remove(lugaresservicio);
            _context.SaveChanges();
            return true;
        }
    }
}