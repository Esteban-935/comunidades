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
    public class RedeService
    {
        private readonly MembranaComunidadesBDContext _context;

        public RedeService(MembranaComunidadesBDContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<RedeResponse>> GetAll()
        {
            var redes = await _context.Redes
                .Select(r => new RedeResponse
                {
                    IdRed = r.IdRed,
                    Nombre = r.Nombre,
                    FechaRegistro = r.FechaRegistro,
                    FechaUpdate = r.FechaUpdate,
                    IdUsuario = r.IdUsuario
                })
                .ToListAsync();

            return redes;
        }

        public async Task<RedeResponse> GetById(Guid id)
        {
            var rede = await _context.Redes
                .Where(r => r.IdRed == id)
                .Select(r => new RedeResponse
                {
                    IdRed = r.IdRed,
                    Nombre = r.Nombre,
                    FechaRegistro = r.FechaRegistro,
                    FechaUpdate = r.FechaUpdate,
                    IdUsuario = r.IdUsuario
                })
                .FirstOrDefaultAsync();

            return rede;
        }

        public async Task<RedeResponse> Create(RedeRequest request)
        {
            var rede = new Rede
            {
                Nombre = request.Nombre,
                FechaRegistro = DateTime.Now,
                IdUsuario = request.IdUsuario
            };

            _context.Redes.Add(rede);
            await _context.SaveChangesAsync();

            return new RedeResponse
            {
                IdRed = rede.IdRed,
                Nombre = rede.Nombre,
                FechaRegistro = rede.FechaRegistro,
                IdUsuario = rede.IdUsuario
            };
        }

        public async Task<RedeResponse> Update(Guid id, RedeRequest request)
        {
            var rede = await _context.Redes.FindAsync(id);
            if (rede == null)
            {
                return null;
            }

            rede.Nombre = request.Nombre;
            rede.FechaUpdate = DateTime.Now;
            rede.IdUsuario = request.IdUsuario;

            _context.Redes.Update(rede);
            await _context.SaveChangesAsync();

            return new RedeResponse
            {
                IdRed = rede.IdRed,
                Nombre = rede.Nombre,
                FechaRegistro = rede.FechaRegistro,
                FechaUpdate = rede.FechaUpdate,
                IdUsuario = rede.IdUsuario
            };
        }

        public async Task<bool> Delete(Guid id)
        {
            var rede = await _context.Redes.FindAsync(id);
            if (rede == null)
            {
                return false;
            }

            _context.Redes.Remove(rede);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}