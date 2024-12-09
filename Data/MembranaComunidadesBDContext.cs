using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Comunidades.Data.Models;

namespace Comunidades.Data
{
    public partial class MembranaComunidadesBDContext : DbContext
    {
        public MembranaComunidadesBDContext()
        {
        }

        public MembranaComunidadesBDContext(DbContextOptions<MembranaComunidadesBDContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Area> Areas { get; set; } = null!;
        public virtual DbSet<CatalogoPoblacion> CatalogoPoblacions { get; set; } = null!;
        public virtual DbSet<Comunidade> Comunidades { get; set; } = null!;
        public virtual DbSet<Concepto> Conceptos { get; set; } = null!;
        public virtual DbSet<Configlocal> Configlocals { get; set; } = null!;
        public virtual DbSet<DetallePoblacion> DetallePoblacions { get; set; } = null!;
        public virtual DbSet<Distrito> Distritos { get; set; } = null!;
        public virtual DbSet<Estatus> Estatuses { get; set; } = null!;
        public virtual DbSet<Formulario> Formularios { get; set; } = null!;
        public virtual DbSet<Lugaresservicio> Lugaresservicios { get; set; } = null!;
        public virtual DbSet<Mese> Meses { get; set; } = null!;
        public virtual DbSet<Nombramiento> Nombramientos { get; set; } = null!;
        public virtual DbSet<Periodo> Periodos { get; set; } = null!;
        public virtual DbSet<Rede> Redes { get; set; } = null!;
        public virtual DbSet<Reporte> Reportes { get; set; } = null!;
        public virtual DbSet<Servidore> Servidores { get; set; } = null!;
        public virtual DbSet<Territorio> Territorios { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("workstation id=MembranaComunidadesBD.mssql.somee.com;packet size=4096;user id=membrana0003_SQLLogin_1;pwd=2d9i5elqtp;data source=MembranaComunidadesBD.mssql.somee.com;persist security info=False;initial catalog=MembranaComunidadesBD;TrustServerCertificate=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Area>(entity =>
            {
                entity.HasKey(e => e.IdArea);

                entity.ToTable("area");

                entity.Property(e => e.IdArea)
                    .ValueGeneratedNever()
                    .HasColumnName("id_area");

                entity.Property(e => e.FechaActualizacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha_actualizacion");

                entity.Property(e => e.FechaRegistro)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha_registro");

                entity.Property(e => e.IdUaurioActualizacion).HasColumnName("id_uaurio_actualizacion");

                entity.Property(e => e.IdUsuarioRegistro).HasColumnName("id_usuario_registro");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(25)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<CatalogoPoblacion>(entity =>
            {
                entity.HasKey(e => e.IdCatalogoPoblacion);

                entity.ToTable("catalogo_poblacion");

                entity.Property(e => e.IdCatalogoPoblacion)
                    .ValueGeneratedNever()
                    .HasColumnName("id_catalogo_poblacion");

                entity.Property(e => e.FechaActualizacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha_actualizacion");

                entity.Property(e => e.FechaRegistro)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha_registro");

                entity.Property(e => e.Grupo)
                    .HasMaxLength(2)
                    .HasColumnName("grupo");

                entity.Property(e => e.IdUsuarioActualizacion).HasColumnName("id_usuario_actualizacion");

                entity.Property(e => e.IdUsuarioRegistro).HasColumnName("id_usuario_registro");

                entity.Property(e => e.Tipo)
                    .HasMaxLength(12)
                    .HasColumnName("tipo");
            });

            modelBuilder.Entity<Comunidade>(entity =>
            {
                entity.HasKey(e => e.IdComunidad);

                entity.ToTable("comunidades");

                entity.Property(e => e.IdComunidad)
                    .ValueGeneratedNever()
                    .HasColumnName("id_comunidad");

                entity.Property(e => e.Cabecera).HasColumnName("cabecera");

                entity.Property(e => e.Direccion)
                    .HasMaxLength(186)
                    .HasColumnName("direccion");

                entity.Property(e => e.FechaRegistro)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha_registro");

                entity.Property(e => e.FechaUpdate)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha_update");

                entity.Property(e => e.IdDistrito).HasColumnName("id_distrito");

                entity.Property(e => e.IdEstatus).HasColumnName("id_estatus");

                entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");

                entity.Property(e => e.IdUsuarioupdate).HasColumnName("id_usuarioupdate");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(70)
                    .HasColumnName("nombre");

                entity.HasOne(d => d.IdDistritoNavigation)
                    .WithMany(p => p.Comunidades)
                    .HasForeignKey(d => d.IdDistrito)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_comunidades_distritos");

                entity.HasOne(d => d.IdEstatusNavigation)
                    .WithMany(p => p.Comunidades)
                    .HasForeignKey(d => d.IdEstatus)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_comunidades_estatus");
            });

            modelBuilder.Entity<Concepto>(entity =>
            {
                entity.HasKey(e => e.IdConcepto);

                entity.Property(e => e.IdConcepto)
                    .ValueGeneratedNever()
                    .HasColumnName("id_concepto");

                entity.Property(e => e.FechaActualizacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha_actualizacion");

                entity.Property(e => e.FechaRegistro)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha_registro");

                entity.Property(e => e.IdArea).HasColumnName("id_area");

                entity.Property(e => e.IdFormulario).HasColumnName("id_formulario");

                entity.Property(e => e.IdUsuarioActualizacion).HasColumnName("id_usuario_actualizacion");

                entity.Property(e => e.IdUsuarioRegistro).HasColumnName("id_usuario_registro");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(70)
                    .HasColumnName("nombre");

                entity.HasOne(d => d.IdAreaNavigation)
                    .WithMany(p => p.Conceptos)
                    .HasForeignKey(d => d.IdArea)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Conceptos_area");

                entity.HasOne(d => d.IdFormularioNavigation)
                    .WithMany(p => p.Conceptos)
                    .HasForeignKey(d => d.IdFormulario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Conceptos_Formularios");
            });

            modelBuilder.Entity<Configlocal>(entity =>
            {
                entity.HasKey(e => e.IdConfiglocal);

                entity.ToTable("configlocal");

                entity.Property(e => e.IdConfiglocal)
                    .ValueGeneratedNever()
                    .HasColumnName("id_configlocal");

                entity.Property(e => e.FechaRegistro)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha_registro");

                entity.Property(e => e.FechaUpdate)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha_update");

                entity.Property(e => e.IdEstatus).HasColumnName("id_estatus");

                entity.Property(e => e.IdNombramiento).HasColumnName("id_nombramiento");

                entity.Property(e => e.IdUsuarioActualizacion).HasColumnName("id_usuario_actualizacion");

                entity.Property(e => e.IdUsuarioRegistro).HasColumnName("id_usuario_registro");

                entity.HasOne(d => d.IdEstatusNavigation)
                    .WithMany(p => p.Configlocals)
                    .HasForeignKey(d => d.IdEstatus)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_configlocal_estatus");

                entity.HasOne(d => d.IdNombramientoNavigation)
                    .WithMany(p => p.Configlocals)
                    .HasForeignKey(d => d.IdNombramiento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_configlocal_nombramiento");
            });

            modelBuilder.Entity<DetallePoblacion>(entity =>
            {
                entity.HasKey(e => e.IdDetallePoblacion);

                entity.ToTable("detalle_poblacion");

                entity.Property(e => e.IdDetallePoblacion)
                    .ValueGeneratedNever()
                    .HasColumnName("id_detalle_poblacion");

                entity.Property(e => e.Cantidad)
                    .HasMaxLength(3)
                    .HasColumnName("cantidad");

                entity.Property(e => e.FechaActualizacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha_actualizacion");

                entity.Property(e => e.FechaRegistro)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha_registro");

                entity.Property(e => e.FechaSesion)
                    .HasMaxLength(10)
                    .HasColumnName("fecha_sesion");

                entity.Property(e => e.IdCatalogoPoblacion).HasColumnName("id_catalogo_poblacion");

                entity.Property(e => e.IdConfiguracionlocal).HasColumnName("id_configuracionlocal");

                entity.Property(e => e.IdUsuarioActualizacion).HasColumnName("id_usuario_actualizacion");

                entity.Property(e => e.IdUsuarioRegistro).HasColumnName("id_usuario_registro");

                entity.HasOne(d => d.IdCatalogoPoblacionNavigation)
                    .WithMany(p => p.DetallePoblacions)
                    .HasForeignKey(d => d.IdCatalogoPoblacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_detalle_poblacion_catalogo_poblacion");

                entity.HasOne(d => d.IdConfiguracionlocalNavigation)
                    .WithMany(p => p.DetallePoblacions)
                    .HasForeignKey(d => d.IdConfiguracionlocal)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_detalle_poblacion_configlocal");
            });

            modelBuilder.Entity<Distrito>(entity =>
            {
                entity.HasKey(e => e.IdDistrito);

                entity.ToTable("distritos");

                entity.Property(e => e.IdDistrito)
                    .ValueGeneratedNever()
                    .HasColumnName("id_distrito");

                entity.Property(e => e.Entidad)
                    .HasMaxLength(50)
                    .HasColumnName("entidad");

                entity.Property(e => e.FechaRegistro)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha_registro");

                entity.Property(e => e.FechaUpdate)
                    .HasColumnType("date")
                    .HasColumnName("fecha_update");

                entity.Property(e => e.IdEstatus).HasColumnName("id_estatus");

                entity.Property(e => e.IdTerritorio).HasColumnName("id_territorio");

                entity.Property(e => e.IdUsuarioregistro).HasColumnName("id_usuarioregistro");

                entity.Property(e => e.IdUsuarioupdate).HasColumnName("id_usuarioupdate");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .HasColumnName("nombre");

                entity.HasOne(d => d.IdEstatusNavigation)
                    .WithMany(p => p.Distritos)
                    .HasForeignKey(d => d.IdEstatus)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_distritos_estatus");

                entity.HasOne(d => d.IdTerritorioNavigation)
                    .WithMany(p => p.Distritos)
                    .HasForeignKey(d => d.IdTerritorio)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_distritos_Territorios");
            });

            modelBuilder.Entity<Estatus>(entity =>
            {
                entity.HasKey(e => e.IdEstatus);

                entity.ToTable("estatus");

                entity.Property(e => e.IdEstatus)
                    .ValueGeneratedNever()
                    .HasColumnName("id_estatus");

                entity.Property(e => e.FechaRegistro)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha_registro");

                entity.Property(e => e.FechaUpdate)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha_update");

                entity.Property(e => e.IdUsuarioRegistro).HasColumnName("id_usuario_registro");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(25)
                    .HasColumnName("nombre");

                entity.Property(e => e.Tipo)
                    .HasMaxLength(10)
                    .HasColumnName("tipo");
            });

            modelBuilder.Entity<Formulario>(entity =>
            {
                entity.HasKey(e => e.IdFormulario);

                entity.Property(e => e.IdFormulario)
                    .ValueGeneratedNever()
                    .HasColumnName("id_formulario");

                entity.Property(e => e.FechaActualizacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha_actualizacion");

                entity.Property(e => e.FechaRegistro)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha_registro");

                entity.Property(e => e.IdPeriodo).HasColumnName("id_periodo");

                entity.Property(e => e.IdUsuarioActualizacion).HasColumnName("id_usuario_actualizacion");

                entity.Property(e => e.IdUsuarioRegistro).HasColumnName("id_usuario_registro");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(2)
                    .HasColumnName("nombre")
                    .IsFixedLength();
            });

            modelBuilder.Entity<Lugaresservicio>(entity =>
            {
                entity.HasKey(e => e.IdLugarservicio);

                entity.ToTable("lugaresservicios");

                entity.Property(e => e.IdLugarservicio)
                    .ValueGeneratedNever()
                    .HasColumnName("id_lugarservicio");

                entity.Property(e => e.FechaRegistro)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha_registro");

                entity.Property(e => e.FechaUpdate)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha_update");

                entity.Property(e => e.IdUsuarioregistro).HasColumnName("id_usuarioregistro");

                entity.Property(e => e.IdUsuarioupdate).HasColumnName("id_usuarioupdate");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(25)
                    .HasColumnName("nombre");

                entity.Property(e => e.Tipo)
                    .HasMaxLength(20)
                    .HasColumnName("tipo");

                entity.Property(e => e.Vigencia).HasColumnName("vigencia");
            });

            modelBuilder.Entity<Mese>(entity =>
            {
                entity.HasKey(e => e.IdMes);

                entity.Property(e => e.IdMes)
                    .HasMaxLength(5)
                    .HasColumnName("id_mes");

                entity.Property(e => e.FechaActualizacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha_actualizacion");

                entity.Property(e => e.FechaRegistro)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha_registro");

                entity.Property(e => e.IdUsuarioActualizacion).HasColumnName("id_usuario_actualizacion");

                entity.Property(e => e.IdUsuarioRegistro).HasColumnName("id_usuario_registro");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(10)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<Nombramiento>(entity =>
            {
                entity.HasKey(e => e.IdNombramiento);

                entity.ToTable("nombramiento");

                entity.Property(e => e.IdNombramiento)
                    .ValueGeneratedNever()
                    .HasColumnName("id_nombramiento");

                entity.Property(e => e.FechaActualizacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha_actualizacion");

                entity.Property(e => e.FechaInicio)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha_inicio");

                entity.Property(e => e.FechaRegistro)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha_registro");

                entity.Property(e => e.FechaTermino)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha_termino");

                entity.Property(e => e.IdComunidad).HasColumnName("id_comunidad");

                entity.Property(e => e.IdEstatus).HasColumnName("id_estatus");

                entity.Property(e => e.IdLugarservicio).HasColumnName("id_lugarservicio");

                entity.Property(e => e.IdServidor).HasColumnName("id_servidor");

                entity.Property(e => e.IdUsuarioregistro).HasColumnName("id_usuarioregistro");

                entity.Property(e => e.IdUsuarioupdate).HasColumnName("id_usuarioupdate");

                entity.HasOne(d => d.IdComunidadNavigation)
                    .WithMany(p => p.Nombramientos)
                    .HasForeignKey(d => d.IdComunidad)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_nombramiento_comunidades");

                entity.HasOne(d => d.IdEstatusNavigation)
                    .WithMany(p => p.Nombramientos)
                    .HasForeignKey(d => d.IdEstatus)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_nombramiento_estatus");

                entity.HasOne(d => d.IdLugarservicioNavigation)
                    .WithMany(p => p.Nombramientos)
                    .HasForeignKey(d => d.IdLugarservicio)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_nombramiento_lugaresservicios");

                entity.HasOne(d => d.IdServidorNavigation)
                    .WithMany(p => p.Nombramientos)
                    .HasForeignKey(d => d.IdServidor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_nombramiento_servidores");
            });

            modelBuilder.Entity<Periodo>(entity =>
            {
                entity.HasKey(e => e.IdPeriodo);

                entity.ToTable("periodo");

                entity.Property(e => e.IdPeriodo)
                    .ValueGeneratedNever()
                    .HasColumnName("id_periodo");

                entity.Property(e => e.FechaActualizacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha_actualizacion");

                entity.Property(e => e.FechaRegistro)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha_registro");

                entity.Property(e => e.IdUsuarioActualizacion).HasColumnName("id_usuario_actualizacion");

                entity.Property(e => e.IdUsuarioRegistro).HasColumnName("id_usuario_registro");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(9)
                    .HasColumnName("nombre");

                entity.Property(e => e.Visible).HasColumnName("visible");
            });

            modelBuilder.Entity<Rede>(entity =>
            {
                entity.HasKey(e => e.IdRed);

                entity.ToTable("redes");

                entity.Property(e => e.IdRed)
                    .ValueGeneratedNever()
                    .HasColumnName("id_red");

                entity.Property(e => e.FechaRegistro)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha_registro");

                entity.Property(e => e.FechaUpdate)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha_update");

                entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .HasColumnName("nombre")
                    .IsFixedLength();
            });

            modelBuilder.Entity<Reporte>(entity =>
            {
                entity.HasKey(e => e.IdReporte);

                entity.ToTable("reportes");

                entity.Property(e => e.IdReporte)
                    .ValueGeneratedNever()
                    .HasColumnName("id_reporte");

                entity.Property(e => e.FechaActualizacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha_actualizacion");

                entity.Property(e => e.FechaRegistro)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha_registro");

                entity.Property(e => e.IdComunidad).HasColumnName("id_comunidad");

                entity.Property(e => e.IdConcepto).HasColumnName("id_concepto");

                entity.Property(e => e.IdMes)
                    .HasMaxLength(5)
                    .HasColumnName("id_mes");

                entity.Property(e => e.IdPeriodo).HasColumnName("id_periodo");

                entity.Property(e => e.IdUsuarioActualizacion).HasColumnName("id_usuario_actualizacion");

                entity.Property(e => e.IdUsuarioRegistro).HasColumnName("id_usuario_registro");

                entity.Property(e => e.Valor)
                    .HasMaxLength(5)
                    .HasColumnName("valor");

                entity.HasOne(d => d.IdComunidadNavigation)
                    .WithMany(p => p.Reportes)
                    .HasForeignKey(d => d.IdComunidad)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_reportes_comunidades");

                entity.HasOne(d => d.IdConceptoNavigation)
                    .WithMany(p => p.Reportes)
                    .HasForeignKey(d => d.IdConcepto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_reportes_Conceptos");

                entity.HasOne(d => d.IdMesNavigation)
                    .WithMany(p => p.Reportes)
                    .HasForeignKey(d => d.IdMes)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_reportes_Meses");

                entity.HasOne(d => d.IdPeriodoNavigation)
                    .WithMany(p => p.Reportes)
                    .HasForeignKey(d => d.IdPeriodo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_reportes_periodo");
            });

            modelBuilder.Entity<Servidore>(entity =>
            {
                entity.HasKey(e => e.IdServidor);

                entity.ToTable("servidores");

                entity.Property(e => e.IdServidor)
                    .ValueGeneratedNever()
                    .HasColumnName("id_servidor");

                entity.Property(e => e.Apellidos)
                    .HasMaxLength(50)
                    .HasColumnName("apellidos");

                entity.Property(e => e.FechaRegistro)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha_registro");

                entity.Property(e => e.FechaUpdate)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha_update");

                entity.Property(e => e.IdUsuarioregistro).HasColumnName("id_usuarioregistro");

                entity.Property(e => e.IdUsuarioupdate).HasColumnName("id_usuarioupdate");

                entity.Property(e => e.Idestatus).HasColumnName("idestatus");

                entity.Property(e => e.Nombres)
                    .HasMaxLength(50)
                    .HasColumnName("nombres");
            });

            modelBuilder.Entity<Territorio>(entity =>
            {
                entity.HasKey(e => e.IdTerritorio);

                entity.Property(e => e.IdTerritorio)
                    .ValueGeneratedNever()
                    .HasColumnName("id_territorio");

                entity.Property(e => e.FechaRegistro)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha_registro");

                entity.Property(e => e.FechaUpdate)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha_update");

                entity.Property(e => e.IdEstatus).HasColumnName("id_estatus");

                entity.Property(e => e.IdUsuarioregistro).HasColumnName("id_usuarioregistro");

                entity.Property(e => e.IdUsuarioupdate).HasColumnName("id_usuarioupdate");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .HasColumnName("nombre");

                entity.HasOne(d => d.IdEstatusNavigation)
                    .WithMany(p => p.Territorios)
                    .HasForeignKey(d => d.IdEstatus)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Territorios_estatus");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
