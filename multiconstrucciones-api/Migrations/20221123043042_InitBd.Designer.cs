﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using multiconstrucciones_api.Models;

#nullable disable

namespace multiconstruccionesapi.Migrations
{
    [DbContext(typeof(MulticonstruccionesContext))]
    [Migration("20221123043042_InitBd")]
    partial class InitBd
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("multiconstrucciones_api.Models.Defectos", b =>
                {
                    b.Property<int>("ClvDefecto")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ClvDefecto"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ClvDefecto");

                    b.ToTable("Defectos");
                });

            modelBuilder.Entity("multiconstrucciones_api.Models.Empleado", b =>
                {
                    b.Property<int>("NumEmpleado")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("NumEmpleado"));

                    b.Property<string>("Amaterno")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("AMaterno");

                    b.Property<string>("Apaterno")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("APaterno");

                    b.Property<string>("NomEmpleado")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Puesto")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("NumEmpleado")
                        .HasName("PK__Empleado__750AE395C1EF9E85");

                    b.ToTable("Empleados");
                });

            modelBuilder.Entity("multiconstrucciones_api.Models.Obra", b =>
                {
                    b.Property<int>("ClvObra")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ClvObra"));

                    b.Property<int>("CantidadVigas")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaObra")
                        .HasColumnType("datetime");

                    b.Property<string>("NomObra")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<int>("NumEmpleado")
                        .HasColumnType("int");

                    b.HasKey("ClvObra")
                        .HasName("PK__Obra__355616BEF08982B0");

                    b.ToTable("Obra", (string)null);
                });

            modelBuilder.Entity("multiconstrucciones_api.Models.Proceso", b =>
                {
                    b.Property<int>("ClvProceso")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ClvProceso"));

                    b.Property<string>("ProcesoNombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ClvProceso");

                    b.ToTable("Proceso");
                });

            modelBuilder.Entity("multiconstrucciones_api.Models.Proceso_Detalle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ClvObra")
                        .HasColumnType("int");

                    b.Property<int>("ClvProceso")
                        .HasColumnType("int");

                    b.Property<int>("ClvViga")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaProcesoInicia")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaProcesoSalida")
                        .HasColumnType("datetime2");

                    b.Property<int>("NumEmpleado")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Proceso_Detalle");
                });

            modelBuilder.Entity("multiconstrucciones_api.Models.Usuario", b =>
                {
                    b.Property<string>("Contraseña")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)");

                    b.Property<int>("NumEmpleado")
                        .HasColumnType("int");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("multiconstrucciones_api.Models.Viga", b =>
                {
                    b.Property<int>("ClvViga")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ClvViga"));

                    b.Property<int?>("ClvDefecto")
                        .HasColumnType("int");

                    b.Property<int>("ClvObra")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaViga")
                        .HasColumnType("datetime");

                    b.Property<double>("LargoViga")
                        .HasColumnType("float");

                    b.Property<string>("Material")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<int>("NumEmpleado")
                        .HasColumnType("int");

                    b.Property<double>("PesoViga")
                        .HasColumnType("float");

                    b.HasKey("ClvViga")
                        .HasName("PK__Viga__0277C515A9A9E17F");

                    b.ToTable("Viga", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
