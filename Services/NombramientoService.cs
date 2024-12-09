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
    public class NombramientoService
    {
        private readonly MembranaComunidadesBDContext _context;

        public NombramientoService(MembranaComunidadesBDContext context)
        {
            _context = context;
        }

        public async Task<List<NombramientoResponse>> Get(Guid idNombramiento, DateTime? fechaInicio, DateTime? fechaTermino, Guid idEstatus, Guid idServidor, Guid? idComunidad, DateTime fechaRegistro, DateTime? fechaUpdate, Guid idUsuarioReg, Guid idLugarservicio, Guid idUsuarioUpdate, int page, int pageSize)
        {
            var nombramientos = await _context.Nombramientos
                .Where(n =>
                    (idNombramiento == default || n.IdNombramiento == idNombramiento) &&
                    (fechaInicio == default || n.FechaInicio == fechaInicio) &&
                    (fechaTermino == default || n.FechaTermino == fechaTermino) &&
                    (idEstatus == default || n.IdEstatus == idEstatus) &&
                    (idServidor == default || n.IdServidor == idServidor) &&
                    (idComunidad == default || n.IdComunidad == idComunidad) &&
                    (fechaRegistro == default || n.FechaRegistro == fechaRegistro) &&
                    //(fechaUpdate == default || n.FechaUpdate == fechaUpdate) &&
                    (idUsuarioReg == default || n.IdUsuarioregistro == idUsuarioReg) &&
                    (idLugarservicio == default || n.IdLugarservicio == idLugarservicio) &&
                    (idUsuarioUpdate == default || n.IdUsuarioupdate == idUsuarioUpdate))
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Select(n => new NombramientoResponse
                {
                    IdNombramiento = n.IdNombramiento,
                    FechaInicio = n.FechaInicio,
                    FechaTermino = n.FechaTermino,
                    Estatus = new {
                        idEstatus = n.IdEstatusNavigation.IdEstatus,
                        Nombre = n.IdEstatusNavigation.Nombre
                    },
                    Servidor = new{
                        idServidor = n.IdServidorNavigation.IdServidor,
                        nombre = n.IdServidorNavigation.Nombres,
                        apellido = n.IdServidorNavigation.Apellidos,
                    },
                    Comunidad = n.IdComunidadNavigation != null ? new{
                        idComunidad = n.IdComunidadNavigation.IdComunidad,
                        Nombre = n.IdComunidadNavigation.Nombre,
                        Distrito = new{
                            idDistrito = n.IdComunidadNavigation.IdDistritoNavigation.IdDistrito,
                            nombre = n.IdComunidadNavigation.IdDistritoNavigation.Nombre,
                            territorio = new{
                                idTerritorio = n.IdComunidadNavigation.IdDistritoNavigation.IdTerritorioNavigation.IdTerritorio,
                                nombre = n.IdComunidadNavigation.IdDistritoNavigation.IdTerritorioNavigation.Nombre
                            }
                        }
                    } : new {},
                    FechaRegistro = n.FechaRegistro,
                    IdUsuarioregistro = n.IdUsuarioregistro,
                    Lugarservicio = new{
                        idLugarservicio = n.IdLugarservicioNavigation.IdLugarservicio,
                        nombre = n.IdLugarservicioNavigation.Nombre
                    },
                    IdUsuarioUpdate = n.IdUsuarioupdate,
                }).ToListAsync();
            return nombramientos;
        }

        public NombramientoResponse Create(NombramientoRequest request)
        {
            var nombramiento = new Nombramiento
            {
                IdNombramiento = request.IdNombramiento,
                IdServidor = request.IdServidor,
                IdComunidad = request.IdComunidad,
                IdLugarservicio = request.IdLugarservicio,
                IdEstatus = request.IdEstatus,
                FechaInicio = request.FechaInicio,
                //FechaTermino = DateTime.Now, //modificado//request.FechaTermino,
                FechaRegistro = DateTime.Now,
                IdUsuarioregistro = request.IdUsuarioregistro
            };

            _context.Nombramientos.Add(nombramiento);
            _context.SaveChanges();

            return new NombramientoResponse
            {
                IdNombramiento = nombramiento.IdNombramiento,
                Servidor = nombramiento.IdServidor,
                Comunidad = nombramiento.IdComunidad,
                Lugarservicio = nombramiento.IdLugarservicio,
                Estatus = nombramiento.IdEstatus,
                FechaInicio = request.FechaInicio,
                //FechaTermino = DateTime.Now, //modificado//request.FechaTermino,
                FechaRegistro = DateTime.Now, //modificado //nombramiento.FechaRegistro,
                IdUsuarioregistro = nombramiento.IdUsuarioregistro
            };
        }

        public NombramientoResponse GetById(Guid id)
        {
            var nombramiento = _context.Nombramientos.Find(id);
            if (nombramiento == null)
            {
                return null;
            }

            return new NombramientoResponse
            {
                IdNombramiento = nombramiento.IdNombramiento,
                Servidor = nombramiento.IdServidor,
                Comunidad = nombramiento.IdComunidad,
                Lugarservicio = nombramiento.IdLugarservicio,
                Estatus = nombramiento.IdEstatus,
                FechaInicio = nombramiento.FechaInicio,
                FechaTermino = nombramiento.FechaTermino,
                FechaRegistro = nombramiento.FechaRegistro,
                IdUsuarioregistro = nombramiento.IdUsuarioregistro,
                IdUsuarioUpdate = nombramiento.IdUsuarioupdate
            };
        }

        public bool Update(Guid id, NombramientoRequest request)
        {
            var nombramiento = _context.Nombramientos.Find(id);
            if (nombramiento == null)
            {
                return false;
            }

            nombramiento.IdServidor = request.IdServidor;
            nombramiento.IdComunidad = request.IdComunidad;
            nombramiento.IdLugarservicio = request.IdLugarservicio;
            nombramiento.IdEstatus = request.IdEstatus;
            nombramiento.FechaInicio = request.FechaInicio;
            nombramiento.FechaTermino = DateTime.Now; //modificado//request.FechaTermino,
            nombramiento.FechaRegistro = DateTime.Now;
            nombramiento.IdUsuarioupdate = request.IdUsuarioupdate;

            _context.SaveChanges();
            return true;
        }

        public bool ChangeStatus(Guid id, Guid idEstatus, Guid idUsuarioUpdate)
        {
            var nombramiento = _context.Nombramientos.Find(id);
            if (nombramiento == null)
            {
                return false;
            }

            nombramiento.IdEstatus = idEstatus;
            nombramiento.IdUsuarioupdate = idUsuarioUpdate;
            nombramiento.FechaActualizacion = DateTime.Now;

            _context.SaveChanges();
            return true;
        }

    }
}