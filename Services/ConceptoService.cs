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
    public class ConceptoService
    {
        private readonly MembranaComunidadesBDContext _context;

        public ConceptoService(MembranaComunidadesBDContext context)
        {
            _context = context;
        }

        public async Task<List<ConceptoResponse>> GetConceptosAsync()
        {
            return await _context.Conceptos
                .Select(c => new ConceptoResponse
                {
                    IdConcepto = c.IdConcepto,
                    Nombre = c.Nombre,
                    IdArea = c.IdArea,
                    IdFormulario = c.IdFormulario,
                    FechaRegistro = c.FechaRegistro,
                    FechaActualizacion = c.FechaActualizacion,
                    IdUsuarioRegistro = c.IdUsuarioRegistro,
                    IdUsuarioActualizacion = c.IdUsuarioActualizacion
                })
                .ToListAsync();
        }

        public async Task<ConceptoResponse> GetConceptoByIdAsync(Guid id)
        {
            var concepto = await _context.Conceptos.FindAsync(id);

            if (concepto == null)
            {
                return null;
            }

            return new ConceptoResponse
            {
                IdConcepto = concepto.IdConcepto,
                Nombre = concepto.Nombre,
                IdArea = concepto.IdArea,
                IdFormulario = concepto.IdFormulario,
                FechaRegistro = concepto.FechaRegistro,
                FechaActualizacion = concepto.FechaActualizacion,
                IdUsuarioRegistro = concepto.IdUsuarioRegistro,
                IdUsuarioActualizacion = concepto.IdUsuarioActualizacion
            };
        }

        public async Task<ConceptoResponse> CreateConceptoAsync(ConceptoRequest request)
        {
            var concepto = new Concepto
            {
                IdConcepto = Guid.NewGuid(),
                Nombre = request.Nombre,
                IdArea = request.IdArea,
                IdFormulario = request.IdFormulario,
                FechaRegistro = DateTime.Now,
                IdUsuarioRegistro = request.IdUsuarioRegistro,
                IdUsuarioActualizacion = request.IdUsuarioActualizacion
            };

            _context.Conceptos.Add(concepto);
            await _context.SaveChangesAsync();

            return new ConceptoResponse
            {
                IdConcepto = Guid.NewGuid(),
                Nombre = concepto.Nombre,
                IdArea = concepto.IdArea,
                IdFormulario = concepto.IdFormulario,
                FechaRegistro = concepto.FechaRegistro,
                FechaActualizacion = concepto.FechaActualizacion,
                IdUsuarioRegistro = concepto.IdUsuarioRegistro,
                IdUsuarioActualizacion = concepto.IdUsuarioActualizacion
            };
        }

        public async Task<bool> UpdateConceptoAsync(Guid id, ConceptoRequest request)
        {
            var concepto = await _context.Conceptos.FindAsync(id);

            if (concepto == null)
            {
                return false;
            }

            concepto.Nombre = request.Nombre;
            concepto.IdArea = request.IdArea;
            concepto.IdFormulario = request.IdFormulario;
            concepto.FechaActualizacion = DateTime.Now;
            concepto.IdUsuarioActualizacion = request.IdUsuarioActualizacion;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteConceptoAsync(Guid id)
        {
            var concepto = await _context.Conceptos.FindAsync(id);

            if (concepto == null)
            {
                return false;
            }

            _context.Conceptos.Remove(concepto);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}