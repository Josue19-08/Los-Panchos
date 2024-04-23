﻿// <auto-generated />
using System;
using LosPanchosDB;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BDLosPanchos.Migrations
{
    [DbContext(typeof(LosPanchosContext))]
    [Migration("20240418011111_UpdateEntityDB")]
    partial class UpdateEntityDB
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BDLosPanchos.Viaje", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("busID")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<float>("costo")
                        .HasColumnType("real");

                    b.Property<int>("duracionMinutos")
                        .HasColumnType("int");

                    b.Property<DateOnly>("fechaViaje")
                        .HasColumnType("date");

                    b.Property<DateTime>("horaViaje")
                        .HasColumnType("datetime2");

                    b.Property<int>("rutaRamalID")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("busID");

                    b.HasIndex("rutaRamalID");

                    b.ToTable("Viaje", (string)null);
                });

            modelBuilder.Entity("LosPanchosDB.Asiento", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("busID")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("tiqueteID")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("busID");

                    b.HasIndex("tiqueteID");

                    b.ToTable("Asiento", (string)null);
                });

            modelBuilder.Entity("LosPanchosDB.Bus", b =>
                {
                    b.Property<string>("placa")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("modelo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("placa");

                    b.ToTable("Bus", (string)null);
                });

            modelBuilder.Entity("LosPanchosDB.Ramal", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("paradas")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Ramal", (string)null);
                });

            modelBuilder.Entity("LosPanchosDB.Ruta", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("destino")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("km")
                        .HasColumnType("int");

                    b.Property<string>("origen")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Ruta", (string)null);
                });

            modelBuilder.Entity("LosPanchosDB.RutaRamal", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("ramalID")
                        .HasColumnType("int");

                    b.Property<int>("rutaID")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("ramalID");

                    b.HasIndex("rutaID");

                    b.ToTable("RutaRamal", (string)null);
                });

            modelBuilder.Entity("LosPanchosDB.Tiquete", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("viajeID")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("viajeID");

                    b.ToTable("Tiquete", (string)null);
                });

            modelBuilder.Entity("BDLosPanchos.Viaje", b =>
                {
                    b.HasOne("LosPanchosDB.Bus", "Bus")
                        .WithMany()
                        .HasForeignKey("busID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LosPanchosDB.Ruta", "Ruta")
                        .WithMany()
                        .HasForeignKey("rutaRamalID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Bus");

                    b.Navigation("Ruta");
                });

            modelBuilder.Entity("LosPanchosDB.Asiento", b =>
                {
                    b.HasOne("LosPanchosDB.Bus", "Bus")
                        .WithMany()
                        .HasForeignKey("busID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LosPanchosDB.Tiquete", "Tiquete")
                        .WithMany("Asientos")
                        .HasForeignKey("tiqueteID");

                    b.Navigation("Bus");

                    b.Navigation("Tiquete");
                });

            modelBuilder.Entity("LosPanchosDB.RutaRamal", b =>
                {
                    b.HasOne("LosPanchosDB.Ramal", "Ramal")
                        .WithMany()
                        .HasForeignKey("ramalID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LosPanchosDB.Ruta", "Ruta")
                        .WithMany()
                        .HasForeignKey("rutaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ramal");

                    b.Navigation("Ruta");
                });

            modelBuilder.Entity("LosPanchosDB.Tiquete", b =>
                {
                    b.HasOne("BDLosPanchos.Viaje", "Viaje")
                        .WithMany()
                        .HasForeignKey("viajeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Viaje");
                });

            modelBuilder.Entity("LosPanchosDB.Tiquete", b =>
                {
                    b.Navigation("Asientos");
                });
#pragma warning restore 612, 618
        }
    }
}
