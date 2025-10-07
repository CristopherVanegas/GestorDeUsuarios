using System;
using System.Collections.Generic;
using API_REST.Models;
using Microsoft.EntityFrameworkCore;

namespace API_REST.Data;

public partial class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Persona> Personas { get; set; }

    public virtual DbSet<Rol> Rols { get; set; }

    public virtual DbSet<RolOpcione> RolOpciones { get; set; }

    public virtual DbSet<RolRolOpcione> RolRolOpciones { get; set; }

    public virtual DbSet<RolUsuario> RolUsuarios { get; set; }

    public virtual DbSet<Session> Sessions { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Persona>(entity =>
        {
            entity.HasKey(e => e.IdPersona).HasName("PK__PERSONA__228148B05BFF0349");

            entity.ToTable("PERSONA");

            entity.Property(e => e.IdPersona).HasColumnName("id_persona");
            entity.Property(e => e.Apellidos)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("apellidos");
            entity.Property(e => e.FechaNacimiento).HasColumnName("fecha_nacimiento");
            entity.Property(e => e.Identificacion)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("identificacion");
            entity.Property(e => e.Nombres)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("nombres");
        });

        modelBuilder.Entity<Rol>(entity =>
        {
            entity.HasKey(e => e.IdRol).HasName("PK__ROL__6ABCB5E0B1752131");

            entity.ToTable("ROL");

            entity.HasIndex(e => e.RolName, "Rol_IDX");

            entity.Property(e => e.IdRol).HasColumnName("id_rol");
            entity.Property(e => e.RolName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("rol_name");
            entity.Property(e => e.Status)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValue("A")
                .IsFixedLength()
                .HasColumnName("status");
        });

        modelBuilder.Entity<RolOpcione>(entity =>
        {
            entity.HasKey(e => e.IdOpcion).HasName("PK__ROL_OPCI__EFAF425872621AFF");

            entity.ToTable("ROL_OPCIONES");

            entity.Property(e => e.IdOpcion).HasColumnName("id_opcion");
            entity.Property(e => e.NombreOpciones)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre_opciones");
            entity.Property(e => e.Status)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValue("A")
                .IsFixedLength()
                .HasColumnName("status");
        });

        modelBuilder.Entity<RolRolOpcione>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("ROL_ROL_OPCIONES");

            entity.Property(e => e.RolIdRol).HasColumnName("rol_id_rol");
            entity.Property(e => e.RolOpcionesIdOpciones).HasColumnName("rol_opciones_id_opciones");

            entity.HasOne(d => d.RolIdRolNavigation).WithMany()
                .HasForeignKey(d => d.RolIdRol)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Rol_RolOpciones_Rol");

            entity.HasOne(d => d.RolOpcionesIdOpcionesNavigation).WithMany()
                .HasForeignKey(d => d.RolOpcionesIdOpciones)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Rol_RolOpciones_RolOpciones");
        });

        modelBuilder.Entity<RolUsuario>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("ROL_USUARIOS");

            entity.Property(e => e.RolIdRol).HasColumnName("rol_id_rol");
            entity.Property(e => e.UsuarioIdUsuario).HasColumnName("usuario_id_usuario");

            entity.HasOne(d => d.RolIdRolNavigation).WithMany()
                .HasForeignKey(d => d.RolIdRol)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Rol_Usuarios_Rol");

            entity.HasOne(d => d.UsuarioIdUsuarioNavigation).WithMany()
                .HasForeignKey(d => d.UsuarioIdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Rol_Usuarios_Usuarios");
        });

        modelBuilder.Entity<Session>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("SESSIONS");

            entity.Property(e => e.FechaCierre)
                .HasColumnType("datetime")
                .HasColumnName("fecha_cierre");
            entity.Property(e => e.FechaIngreso)
                .HasColumnType("datetime")
                .HasColumnName("fecha_ingreso");
            entity.Property(e => e.Status)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValue("A")
                .IsFixedLength()
                .HasColumnName("status");
            entity.Property(e => e.UsuarioIdUsuario).HasColumnName("usuario_id_usuario");

            entity.HasOne(d => d.UsuarioIdUsuarioNavigation).WithMany()
                .HasForeignKey(d => d.UsuarioIdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Sessions_Usuarios");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__USUARIOS__4E3E04AD5FC05962");

            entity.ToTable("USUARIOS");

            entity.HasIndex(e => e.UserName, "usuarios_IDX");

            entity.HasIndex(e => e.Mail, "usuarios_IDXv1");

            entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");
            entity.Property(e => e.Mail)
                .HasMaxLength(120)
                .IsUnicode(false)
                .HasColumnName("mail");
            entity.Property(e => e.Passcode)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("passcode");
            entity.Property(e => e.PersonaIdPersona2).HasColumnName("persona_id_persona2");
            entity.Property(e => e.SessionActive)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("session_active");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("status");
            entity.Property(e => e.UserName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("user_name");

            entity.HasOne(d => d.PersonaIdPersona2Navigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.PersonaIdPersona2)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Usuarios_Persona");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
