﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DAL.CursoEscuela.Models
{
    public partial class EscuelaContext : DbContext
    {
        public EscuelaContext()
        {
        }

        public EscuelaContext(DbContextOptions<EscuelaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Alumnos> Alumnos { get; set; }
        public virtual DbSet<Calificaciones> Calificaciones { get; set; }
        public virtual DbSet<Grupos> Grupos { get; set; }
        public virtual DbSet<Maestro> Maestro { get; set; }
        public virtual DbSet<Materias> Materias { get; set; }
        public virtual DbSet<Turnos> Turnos { get; set; }
       public virtual DbSet<ObtenerAlumnos> ObtenerAlumnos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server =DESKTOP-TNVIORP\\SQLEXPRESS;Database=Escuela; Trusted_Connection = True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Alumnos>(entity =>
            {
                entity.HasKey(e => e.IdAlumno);

                entity.Property(e => e.Matricula)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdTurnoNavigation)
                    .WithMany(p => p.Alumnos)
                    .HasForeignKey(d => d.IdTurno)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Alumnos_Turnos");
            });

            modelBuilder.Entity<Calificaciones>(entity =>
            {
                entity.HasKey(e => e.IdCalificaciones);

                entity.Property(e => e.IdCalificaciones).ValueGeneratedNever();

                entity.HasOne(d => d.IdAlumnoNavigation)
                    .WithMany(p => p.Calificaciones)
                    .HasForeignKey(d => d.IdAlumno)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Calificaciones_Alumnos");

                entity.HasOne(d => d.IdMateriaNavigation)
                    .WithMany(p => p.Calificaciones)
                    .HasForeignKey(d => d.IdMateria)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Calificaciones_Materias");
            });

            modelBuilder.Entity<Grupos>(entity =>
            {
                entity.HasKey(e => e.IdGrupos);

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdAlumnosNavigation)
                    .WithMany(p => p.Grupos)
                    .HasForeignKey(d => d.IdAlumnos)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Grupos_Alumnos");

                entity.HasOne(d => d.IdMateriaNavigation)
                    .WithMany(p => p.Grupos)
                    .HasForeignKey(d => d.IdMateria)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Grupos_Materias");
            });

            modelBuilder.Entity<Maestro>(entity =>
            {
                entity.HasKey(e => e.IdMaestro);

                entity.Property(e => e.IdMaestro).ValueGeneratedNever();

                entity.HasOne(d => d.IdMateriaNavigation)
                    .WithMany(p => p.Maestro)
                    .HasForeignKey(d => d.IdMateria)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Maestro_Materias");
            });

            modelBuilder.Entity<Materias>(entity =>
            {
                entity.HasKey(e => e.IdMateria);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Turnos>(entity =>
            {
                entity.HasKey(e => e.IdTurno);

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}