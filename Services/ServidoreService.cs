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
    public class ServidoreService
    {
        private readonly MembranaComunidadesBDContext _context;

        public ServidoreService(MembranaComunidadesBDContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ServidoreResponse>> GetAll()
        {
            var servidores = _context.Servidores.ToList();
            return servidores.Select(s => new ServidoreResponse
            {
                IdServidor = s.IdServidor,
                Nombres = s.Nombres,
                Apellidos = s.Apellidos,
               // Documento = s//.Documento,
                //IdLugarServicio = s.IdLugarservicio,
                IdEstatus = s.Idestatus,
                FechaRegistro = s.FechaRegistro,
                FechaUpdate = s.FechaUpdate,
                IdUsuarioRegistro = s.IdUsuarioregistro,
                IdUsuarioUpdate = s.IdUsuarioupdate
            });
        }

        public async Task<ServidoreResponse> GetById(Guid id)
        {
            var servidor = await _context.Servidores.FindAsync(id);
            if (servidor == null)
            {
                return null;
            }

            return new ServidoreResponse
            {
                IdServidor = servidor.IdServidor,
                Nombres = servidor.Nombres,
                Apellidos = servidor.Apellidos,
               // Documento = servidor//.Documento,
               // IdLugarServicio = servidor//.IdLugarservicio,
                IdEstatus = servidor.Idestatus,
                FechaRegistro = servidor.FechaRegistro,
                FechaUpdate = servidor.FechaUpdate,
                IdUsuarioRegistro = servidor.IdUsuarioregistro,
                IdUsuarioUpdate = servidor.IdUsuarioupdate
            };
        }

        public async Task<ServidoreResponse> Create(ServidoreRequest request)
        {
            var servidor = new Servidore
            {
                IdServidor = request.IdServidor,
                Nombres = request.Nombres,
                Apellidos = request.Apellidos,
               // Documento = request//.Documento,
               // IdLugarservicio = request//.IdLugarServicio,
                Idestatus = request.Idestatus,
                FechaRegistro = DateTime.Now,
                IdUsuarioregistro = request.IdUsuarioRegistro
            };

            _context.Servidores.Add(servidor);
            await _context.SaveChangesAsync();

            return new ServidoreResponse
            {
                IdServidor = servidor.IdServidor,
                Nombres = servidor.Nombres,
                Apellidos = servidor.Apellidos,
               // Documento = servidor//.Documento,
               // IdLugarServicio = servidor//.IdLugarservicio,
                IdEstatus = servidor.Idestatus,
                FechaRegistro = servidor.FechaRegistro,
                IdUsuarioRegistro = servidor.IdUsuarioregistro
            };
        }

        public async Task<ServidoreResponse> Update(Guid id, ServidoreRequest request)
        {
            var servidor = await _context.Servidores.FindAsync(id);
            if (servidor == null)
            {
                return null;
            }

            servidor.Nombres = request.Nombres;
            servidor.Apellidos = request.Apellidos;
            //servidor//.Documento = request//.Documento;
           // servidor//.IdLugarservicio = request//.IdLugarServicio;
            servidor.Idestatus = request.Idestatus;
            servidor.FechaUpdate = DateTime.Now;
            servidor.IdUsuarioupdate = request.IdUsuarioUpdate;

            await _context.SaveChangesAsync();

            return new ServidoreResponse
            {
                IdServidor = servidor.IdServidor,
                Nombres = servidor.Nombres,
                Apellidos = servidor.Apellidos,
               // Documento = servidor//.Documento,
               // IdLugarServicio = servidor//.IdLugarservicio,
                IdEstatus = servidor.Idestatus,
                FechaRegistro = servidor.FechaRegistro,
                FechaUpdate = servidor.FechaUpdate,
                IdUsuarioRegistro = servidor.IdUsuarioregistro,
                IdUsuarioUpdate = servidor.IdUsuarioupdate
            };
        }

        public async Task<bool> Delete(Guid id)
        {
            var servidor = await _context.Servidores.FindAsync(id);
            if (servidor == null)
            {
                return false;
            }

            _context.Servidores.Remove(servidor);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}