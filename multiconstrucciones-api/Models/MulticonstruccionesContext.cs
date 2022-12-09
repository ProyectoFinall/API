using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace multiconstrucciones_api.Models;

public partial class MulticonstruccionesContext : DbContext
{
    public MulticonstruccionesContext()
    {
    }

    public MulticonstruccionesContext(DbContextOptions<MulticonstruccionesContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Empleado> Empleados { get; set; }

    public virtual DbSet<Obra> Obras { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    public virtual DbSet<Viga> Vigas { get; set; }
    public virtual DbSet<Defectos> Defectos { get; set; }
    public virtual DbSet<Proceso> Proceso { get; set; }
    public virtual DbSet<Proceso_Detalle> Proceso_Detalle { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=129.146.118.224, 1433;Database=MULTICONSTRUCCIONES;User Id= sa; Password=CHufe6uT;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Empleado>(entity =>
        {
            entity.HasKey(e => e.NumEmpleado).HasName("PK__Empleado__750AE395C1EF9E85");

            entity.Property(e => e.Amaterno)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("AMaterno");
            entity.Property(e => e.Apaterno)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("APaterno");
            entity.Property(e => e.NomEmpleado)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Puesto)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Obra>(entity =>
        {
            entity.HasKey(e => e.ClvObra).HasName("PK__Obra__355616BEF08982B0");

            entity.ToTable("Obra");

            entity.Property(e => e.FechaObra).HasColumnType("datetime");
            entity.Property(e => e.NomObra)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Usuario__355616BEF08982B0");

            entity.Property(e => e.Contraseña)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Viga>(entity =>
        {
            entity.HasKey(e => e.ClvViga).HasName("PK__Viga__0277C515A9A9E17F");

            entity.ToTable("Viga");

            entity.Property(e => e.FechaViga).HasColumnType("datetime");
            entity.Property(e => e.Material)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
