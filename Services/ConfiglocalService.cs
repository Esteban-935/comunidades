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
    public class ConfiglocalService
    {
        private readonly MembranaComunidadesBDContext _context;

        public ConfiglocalService(MembranaComunidadesBDContext context)
        {
            _context = context;
        }

        public async Task<List<ConfiglocalResponse>> GetAllConfiglocales()
        {
            return await _context.Configlocals
                .Select(c => new ConfiglocalResponse
                {
                    IdConfiglocal = c.IdConfiglocal,
                    IdEstatus = c.IdEstatus,
                    IdNombramiento = c.IdNombramiento,
                    FechaRegistro = DateTime.Now, //modificado
                    FechaUpdate = DateTime.Now, //modificado
                    IdUsuarioRegistro = c.IdUsuarioRegistro,
                    IdUsuarioActualizacion = c.IdUsuarioActualizacion,
                    DetallePoblacions = c.DetallePoblacions
                })
                .ToListAsync();
        }

        public async Task<ConfiglocalResponse> GetConfiglocalById(Guid id)
        {
            var configlocal = await _context.Configlocals.FindAsync(id);

            if (configlocal == null)
            {
                return null;
            }

            return new ConfiglocalResponse
            {
                IdConfiglocal = configlocal.IdConfiglocal,
                IdEstatus = configlocal.IdEstatus,
                IdNombramiento = configlocal.IdNombramiento,
                FechaRegistro = DateTime.Now, //modificado
                FechaUpdate = DateTime.Now, //modificado
                IdUsuarioRegistro = configlocal.IdUsuarioRegistro,
                IdUsuarioActualizacion = configlocal.IdUsuarioActualizacion,
                DetallePoblacions = configlocal.DetallePoblacions
            };
        }

        public async Task<ConfiglocalResponse> CreateConfiglocal(ConfiglocalRequest request)
        {
            var configlocal = new Configlocal
            {
                IdConfiglocal = Guid.NewGuid(),
                IdEstatus = request.IdEstatus,
                IdNombramiento = request.IdNombramiento,
                FechaRegistro = DateTime.Now, //modificado
                //FechaUpdate = DateTime.Now, //modificado
                IdUsuarioRegistro = request.IdUsuarioRegistro,
                IdUsuarioActualizacion = request.IdUsuarioActualizacion
            };

            _context.Configlocals.Add(configlocal);
            await _context.SaveChangesAsync();

            return new ConfiglocalResponse
            {
                IdConfiglocal = Guid.NewGuid(),
                IdEstatus = configlocal.IdEstatus,
                IdNombramiento = configlocal.IdNombramiento,
                FechaRegistro = DateTime.Now, //modificado
                //FechaUpdate = DateTime.Now, //modificado
                IdUsuarioRegistro = configlocal.IdUsuarioRegistro,
                IdUsuarioActualizacion = configlocal.IdUsuarioActualizacion
            };
        }

        public async Task<bool> UpdateConfiglocal(Guid id, ConfiglocalRequest request)
        {
            var configlocal = await _context.Configlocals.FindAsync(id);

            if (configlocal == null)
            {
                return false;
            }

            configlocal.IdEstatus = request.IdEstatus;
            configlocal.IdNombramiento = request.IdNombramiento;
            configlocal.FechaRegistro = DateTime.Now; //modificado
            configlocal.FechaUpdate = DateTime.Now; //modficado
            configlocal.IdUsuarioRegistro = request.IdUsuarioRegistro;
            configlocal.IdUsuarioActualizacion = request.IdUsuarioActualizacion;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteConfiglocal(Guid id)
        {
            var configlocal = await _context.Configlocals.FindAsync(id);

            if (configlocal == null)
            {
                return false;
            }

            _context.Configlocals.Remove(configlocal);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}