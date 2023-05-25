﻿// <auto-generated />
using System;
using MagicVilla_API.Datos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MagicVilla_API.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    partial class ApplicationDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("MagicVilla_API.Modelos.Villa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Amenidad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Detalle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaActualizacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<string>("ImagenURL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MetrosCuadrados")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Ocupantes")
                        .HasColumnType("int");

                    b.Property<double>("Tarifa")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Villas");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Amenidad = "",
                            Detalle = "Villa del Real Madrid",
                            FechaActualizacion = new DateTime(2023, 5, 25, 9, 31, 28, 169, DateTimeKind.Local).AddTicks(2913),
                            FechaCreacion = new DateTime(2023, 5, 25, 9, 31, 28, 169, DateTimeKind.Local).AddTicks(2895),
                            ImagenURL = "",
                            MetrosCuadrados = 2000,
                            Nombre = "Villa Real",
                            Ocupantes = 100,
                            Tarifa = 220.0
                        },
                        new
                        {
                            Id = 2,
                            Amenidad = "",
                            Detalle = "Villa con buena vista",
                            FechaActualizacion = new DateTime(2023, 5, 25, 9, 31, 28, 169, DateTimeKind.Local).AddTicks(2920),
                            FechaCreacion = new DateTime(2023, 5, 25, 9, 31, 28, 169, DateTimeKind.Local).AddTicks(2918),
                            ImagenURL = "",
                            MetrosCuadrados = 200,
                            Nombre = "Villa Rica",
                            Ocupantes = 10,
                            Tarifa = 120.0
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
