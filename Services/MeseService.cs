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
    public class MeseService
    {
        private readonly MembranaComunidadesBDContext _context;

        public MeseService(MembranaComunidadesBDContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<MeseResponse>> GetAllMesesAsync()
        {
            return await _context.Meses
                .Select(m => new MeseResponse
                {
                    IdMes = m.IdMes,
                    Nombre = m.Nombre,
                    FechaRegistro = m.FechaRegistro,
                    FechaActualizacion = m.FechaActualizacion,
                    IdUsuarioRegistro = m.IdUsuarioRegistro,
                    IdUsuarioActualizacion = m.IdUsuarioActualizacion
                })
                .ToListAsync();
        }

        public async Task<MeseResponse> GetMeseByIdAsync(string id)
        {
            var mese = await _context.Meses.FindAsync(id);

            if (mese == null)
            {
                return null;
            }

            return new MeseResponse
            {
                IdMes = mese.IdMes,
                Nombre = mese.Nombre,
                FechaRegistro = DateTime.Now,
                FechaActualizacion = DateTime.Now,
                IdUsuarioRegistro = mese.IdUsuarioRegistro,
                IdUsuarioActualizacion = mese.IdUsuarioActualizacion
            };
        }

        public async Task<MeseResponse> CreateMeseAsync(MeseRequest request)
        {
            var mese = new Mese
            {
                IdMes = request.IdMes,
                Nombre = request.Nombre,
                FechaRegistro = DateTime.Now,
                FechaActualizacion = DateTime.Now,
                IdUsuarioRegistro = request.IdUsuarioRegistro,
                //IdUsuarioActualizacion = request.IdUsuarioActualizacion
            };

            _context.Meses.Add(mese);
            await _context.SaveChangesAsync();

            return new MeseResponse
            {
                IdMes = mese.IdMes,
                Nombre = mese.Nombre,
                FechaRegistro = DateTime.Now,
                FechaActualizacion = DateTime.Now,
                IdUsuarioRegistro = mese.IdUsuarioRegistro,
                //IdUsuarioActualizacion = mese.IdUsuarioActualizacion
            };
        }

        public async Task<bool> UpdateMeseAsync(string id, MeseRequest request)
        {
            var mese = await _context.Meses.FindAsync(id);

            if (mese == null)
            {
                return false;
            }

            mese.Nombre = request.Nombre;
            mese.FechaActualizacion = DateTime.Now;
            mese.IdUsuarioActualizacion = request.IdUsuarioActualizacion;

            _context.Meses.Update(mese);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteMeseAsync(string id)
        {
            var mese = await _context.Meses.FindAsync(id);

            if (mese == null)
            {
                return false;
            }

            _context.Meses.Remove(mese);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}