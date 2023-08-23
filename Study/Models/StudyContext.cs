using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Study.Models;

public partial class StudyContext : DbContext
{
    public StudyContext()
    {
    }

    public StudyContext(DbContextOptions<StudyContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Estadistica> Estadisticas { get; set; }

    public virtual DbSet<Ingreso> Ingresos { get; set; }

    public virtual DbSet<Materia> Materia { get; set; }

    public virtual DbSet<Modulo> Modulos { get; set; }

    public virtual DbSet<Persona> Personas { get; set; }

    public virtual DbSet<Pregunta> Pregunta { get; set; }

    public virtual DbSet<Prueba> Pruebas { get; set; }

    public virtual DbSet<Rol> Rols { get; set; }

    public virtual DbSet<RolPermiso> RolPermisos { get; set; }

    public virtual DbSet<Tema> Temas { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-L9O0M6O\\SQLEXPRESS;Database=Study; Trusted_Connection=True; TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Estadistica>(entity =>
        {
            entity.HasKey(e => e.IdEstadistica).HasName("PK__Estadist__AA8B7E15F9988D5A");

            entity.ToTable("Estadistica");

            entity.Property(e => e.IdEstadistica).HasColumnName("ID_Estadistica");
            entity.Property(e => e.IdUsuario).HasColumnName("ID_Usuario");
            entity.Property(e => e.MejorMateria)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PeorMateria)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Estadisticas)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("FK__Estadisti__ID_Us__6FE99F9F");
        });

        modelBuilder.Entity<Ingreso>(entity =>
        {
            entity.HasKey(e => e.IdIngreso).HasName("PK__Ingreso__2B7A7D35C90E4E02");

            entity.ToTable("Ingreso");

            entity.Property(e => e.IdIngreso).HasColumnName("ID_Ingreso");
            entity.Property(e => e.Fecha)
                .HasColumnType("datetime")
                .HasColumnName("fecha");
            entity.Property(e => e.IdUsuario).HasColumnName("ID_Usuario");
            entity.Property(e => e.Tipo)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Ingresos)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("FK__Ingreso__ID_Usua__6477ECF3");
        });

        modelBuilder.Entity<Materia>(entity =>
        {
            entity.HasKey(e => e.IdMateria).HasName("PK__Materia__4BAC7BD912345780");

            entity.Property(e => e.IdMateria).HasColumnName("ID_Materia");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Modulo>(entity =>
        {
            entity.HasKey(e => e.IdModulo).HasName("PK__Modulo__E498BA6BEAA4522F");

            entity.ToTable("Modulo");

            entity.Property(e => e.IdModulo).HasColumnName("ID_Modulo");
            entity.Property(e => e.DescripcionMod)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Persona>(entity =>
        {
            entity.HasKey(e => e.IdPersona).HasName("PK__Persona__E9916EC182DD75D0");

            entity.ToTable("Persona");

            entity.Property(e => e.IdPersona).HasColumnName("ID_Persona");
            entity.Property(e => e.Apellido)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Cc).HasColumnName("CC");
            entity.Property(e => e.Correo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Genero)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.IdRol).HasColumnName("ID_Rol");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.Personas)
                .HasForeignKey(d => d.IdRol)
                .HasConstraintName("FK__Persona__ID_Rol__5BE2A6F2");
        });

        modelBuilder.Entity<Pregunta>(entity =>
        {
            entity.HasKey(e => e.IdPregunta).HasName("PK__Pregunta__1034DF213C0B3BE8");

            entity.Property(e => e.IdPregunta).HasColumnName("ID_Pregunta");
            entity.Property(e => e.Enunciado)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.IdTema).HasColumnName("ID_Tema");
            entity.Property(e => e.OpcionA)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.OpcionB)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.OpcionC)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.Respuesta)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.IdTemaNavigation).WithMany(p => p.Pregunta)
                .HasForeignKey(d => d.IdTema)
                .HasConstraintName("FK__Pregunta__ID_Tem__7A672E12");
        });

        modelBuilder.Entity<Prueba>(entity =>
        {
            entity.HasKey(e => e.IdPrueba).HasName("PK__Prueba__FCB047EE691CF024");

            entity.ToTable("Prueba");

            entity.Property(e => e.IdPrueba).HasColumnName("ID_Prueba");
            entity.Property(e => e.FechaPrueba).HasColumnType("datetime");
            entity.Property(e => e.IdMateria).HasColumnName("ID_Materia");
            entity.Property(e => e.IdUsuario).HasColumnName("ID_Usuario");

            entity.HasOne(d => d.IdMateriaNavigation).WithMany(p => p.Pruebas)
                .HasForeignKey(d => d.IdMateria)
                .HasConstraintName("FK__Prueba__ID_Mater__7D439ABD");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Pruebas)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("FK__Prueba__ID_Usuar__7E37BEF6");
        });

        modelBuilder.Entity<Rol>(entity =>
        {
            entity.HasKey(e => e.IdRol).HasName("PK__Rol__202AD220E81F4BF4");

            entity.ToTable("Rol");

            entity.Property(e => e.IdRol).HasColumnName("ID_Rol");
            entity.Property(e => e.DescripcionRol)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<RolPermiso>(entity =>
        {
            entity.HasKey(e => e.IdRolPermiso).HasName("PK__Rol_Perm__0891A9C3CC8EB9A3");

            entity.ToTable("Rol_Permiso");

            entity.Property(e => e.IdRolPermiso).HasColumnName("ID_Rol_Permiso");
            entity.Property(e => e.IdModulo).HasColumnName("ID_Modulo");
            entity.Property(e => e.IdRol).HasColumnName("ID_Rol");
            entity.Property(e => e.PermisoDelete).HasColumnName("Permiso_Delete");
            entity.Property(e => e.PermisoGet).HasColumnName("Permiso_Get");
            entity.Property(e => e.PermisoGetById).HasColumnName("Permiso_GetById");
            entity.Property(e => e.PermisoPost).HasColumnName("Permiso_Post");
            entity.Property(e => e.PermisoPut).HasColumnName("Permiso_Put");

            entity.HasOne(d => d.IdModuloNavigation).WithMany(p => p.RolPermisos)
                .HasForeignKey(d => d.IdModulo)
                .HasConstraintName("FK__Rol_Permi__ID_Mo__4E88ABD4");

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.RolPermisos)
                .HasForeignKey(d => d.IdRol)
                .HasConstraintName("FK__Rol_Permi__ID_Ro__4D94879B");
        });

        modelBuilder.Entity<Tema>(entity =>
        {
            entity.HasKey(e => e.IdTema).HasName("PK__Tema__D659FE8F2EB9C72A");

            entity.ToTable("Tema");

            entity.Property(e => e.IdTema).HasColumnName("ID_Tema");
            entity.Property(e => e.Contenido)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.IdMateria).HasColumnName("ID_Materia");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.IdMateriaNavigation).WithMany(p => p.Temas)
                .HasForeignKey(d => d.IdMateria)
                .HasConstraintName("FK__Tema__ID_Materia__74AE54BC");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__Usuario__DE4431C54B066082");

            entity.ToTable("Usuario");

            entity.Property(e => e.IdUsuario).HasColumnName("ID_Usuario");
            entity.Property(e => e.Contraseña)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.IdPersona).HasColumnName("ID_Persona");
            entity.Property(e => e.Nickname)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.IdPersonaNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdPersona)
                .HasConstraintName("FK__Usuario__ID_Pers__5EBF139D");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
