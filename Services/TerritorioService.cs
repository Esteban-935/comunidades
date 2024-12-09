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
    public class TerritorioService
    {
        private readonly MembranaComunidadesBDContext _context;

        public TerritorioService(MembranaComunidadesBDContext context)
        {
            _context = context;
        }

        public IEnumerable<TerritorioResponse> GetAll()
        {
            return _context.Territorios
                .Select(t => new TerritorioResponse
                {
                    IdTerritorio = t.IdTerritorio,
                    Nombre = t.Nombre,
                    IdEstatus = t.IdEstatus,
                    FechaRegistro = t.FechaRegistro,
                    FechaUpdate = t.FechaUpdate,
                    IdUsuarioregistro = t.IdUsuarioregistro,
                    IdUsuarioupdate = t.IdUsuarioupdate
                })
                .ToList();
        }

        public TerritorioResponse GetById(Guid id)
        {
            var territorio = _context.Territorios.Find(id);
            if (territorio == null)
            {
                return null;
            }

            return new TerritorioResponse
            {
                IdTerritorio = territorio.IdTerritorio,
                Nombre = territorio.Nombre,
                IdEstatus = territorio.IdEstatus,
                FechaRegistro = territorio.FechaRegistro,
                FechaUpdate = territorio.FechaUpdate,
                IdUsuarioregistro = territorio.IdUsuarioregistro,
                IdUsuarioupdate = territorio.IdUsuarioupdate
            };
        }

        public TerritorioResponse Create(TerritorioRequest request)
        {
            var territorio = new Territorio
            {
                IdTerritorio = request.IdTerritorio, //modificado
                Nombre = request.Nombre,
                IdEstatus = request.IdEstatus,
                FechaRegistro = DateTime.Now,
                IdUsuarioregistro = request.IdUsuarioregistro
            };

            _context.Territorios.Add(territorio);
            _context.SaveChanges();

            return new TerritorioResponse
            {
                IdTerritorio = territorio.IdTerritorio,
                Nombre = territorio.Nombre,
                IdEstatus = territorio.IdEstatus,
                FechaRegistro = territorio.FechaRegistro,
                IdUsuarioregistro = territorio.IdUsuarioregistro
            };
        }

        public bool Update(Guid id, TerritorioRequest request)
        {
            var territorio = _context.Territorios.Find(id);
            if (territorio == null)
            {
                return false;
            }

            territorio.Nombre = request.Nombre;
            territorio.IdEstatus = request.IdEstatus;
            territorio.FechaUpdate = DateTime.Now;
            territorio.IdUsuarioupdate = request.IdUsuarioregistro;

            _context.SaveChanges();
            return true;
        }

        public bool Delete(Guid id)
        {
            var territorio = _context.Territorios.Find(id);
            if (territorio == null)
            {
                return false;
            }

            _context.Territorios.Remove(territorio);
            _context.SaveChanges();
            return true;
        }
    }
}