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
    public class FormularioService
    {
        private readonly MembranaComunidadesBDContext _context;

        public FormularioService(MembranaComunidadesBDContext context)
        {
            _context = context;
        }

        public async Task<List<FormularioResponse>> GetFormulariosAsync()
        {
            var formularios = await _context.Formularios
                .Select(f => new FormularioResponse
                {
                    IdFormulario = Guid.NewGuid(),
                    Nombre = f.Nombre,
                    IdPeriodo = f.IdPeriodo,
                    FechaRegistro = f.FechaRegistro,
                    FechaActualizacion = f.FechaActualizacion,
                    IdUsuarioRegistro = f.IdUsuarioRegistro,
                    IdUsuarioActualizacion = f.IdUsuarioActualizacion
                }).ToListAsync();
            return formularios;
        }

        public async Task<FormularioResponse> GetFormularioByIdAsync(Guid id)
        {
            var formulario = await _context.Formularios.FindAsync(id);
            if (formulario == null)
            {
                return null;
            }

            return new FormularioResponse
            {
                IdFormulario = formulario.IdFormulario,
                Nombre = formulario.Nombre,
                IdPeriodo = formulario.IdPeriodo,
                FechaRegistro = DateTime.Now,
                FechaActualizacion = DateTime.Now,
                IdUsuarioRegistro = formulario.IdUsuarioRegistro,
                IdUsuarioActualizacion = formulario.IdUsuarioActualizacion
            };
        }

        public async Task<FormularioResponse> CreateFormularioAsync(FormularioRequest request)
        {
            var formulario = new Formulario
            {
                IdFormulario = Guid.NewGuid(),
                Nombre = request.Nombre,
                IdPeriodo = request.IdPeriodo,
                FechaRegistro = DateTime.Now,
                IdUsuarioRegistro = request.IdUsuarioRegistro,
                IdUsuarioActualizacion = request.IdUsuarioActualizacion
            };

            _context.Formularios.Add(formulario);
            await _context.SaveChangesAsync();

            return new FormularioResponse
            {
                IdFormulario = Guid.NewGuid(),
                Nombre = formulario.Nombre,
                IdPeriodo = formulario.IdPeriodo,
                FechaRegistro = DateTime.Now,
                FechaActualizacion = DateTime.Now,
                IdUsuarioRegistro = formulario.IdUsuarioRegistro,
                IdUsuarioActualizacion = formulario.IdUsuarioActualizacion
            };
        }

        public async Task<bool> UpdateFormularioAsync(Guid id, FormularioRequest request)
        {
            var formulario = await _context.Formularios.FindAsync(id);
            if (formulario == null)
            {
                return false;
            }

            formulario.Nombre = request.Nombre;
            formulario.IdPeriodo = request.IdPeriodo;
            formulario.FechaActualizacion = DateTime.Now;
            formulario.IdUsuarioActualizacion = request.IdUsuarioActualizacion;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteFormularioAsync(Guid id)
        {
            var formulario = await _context.Formularios.FindAsync(id);
            if (formulario == null)
            {
                return false;
            }

            _context.Formularios.Remove(formulario);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}