﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using mf_apis_web_services_fuel_manager.Models;

#nullable disable

namespace mf_apis_web_services_fuel_manager.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240913215133_M02")]
    partial class M02
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.8");

            modelBuilder.Entity("mf_apis_web_services_fuel_manager.Models.Consumo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Data")
                        .HasColumnType("TEXT");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Tipo")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("VeiculoId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("VeiculoId");

                    b.ToTable("Consumos");
                });

            modelBuilder.Entity("mf_apis_web_services_fuel_manager.Models.LinkDto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ConsumoId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Href")
                        .HasColumnType("TEXT");

                    b.Property<string>("Metodo")
                        .HasColumnType("TEXT");

                    b.Property<string>("Rel")
                        .HasColumnType("TEXT");

                    b.Property<int?>("VeiculoId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ConsumoId");

                    b.HasIndex("VeiculoId");

                    b.ToTable("LinkDto");
                });

            modelBuilder.Entity("mf_apis_web_services_fuel_manager.Models.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Perfil")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("mf_apis_web_services_fuel_manager.Models.Veiculo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AnoFabricacao")
                        .HasColumnType("INTEGER");

                    b.Property<int>("AnoModelo")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Marca")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Modelo")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Placa")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Veiculos");
                });

            modelBuilder.Entity("mf_apis_web_services_fuel_manager.Models.VeiculoUsuarios", b =>
                {
                    b.Property<int>("VeiculoId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ConsumoId")
                        .HasColumnType("INTEGER");

                    b.HasKey("VeiculoId", "UsuarioId");

                    b.HasIndex("ConsumoId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("VeiculoUsuarios");
                });

            modelBuilder.Entity("mf_apis_web_services_fuel_manager.Models.Consumo", b =>
                {
                    b.HasOne("mf_apis_web_services_fuel_manager.Models.Veiculo", "Veiculo")
                        .WithMany("Consumos")
                        .HasForeignKey("VeiculoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Veiculo");
                });

            modelBuilder.Entity("mf_apis_web_services_fuel_manager.Models.LinkDto", b =>
                {
                    b.HasOne("mf_apis_web_services_fuel_manager.Models.Consumo", null)
                        .WithMany("Links")
                        .HasForeignKey("ConsumoId");

                    b.HasOne("mf_apis_web_services_fuel_manager.Models.Veiculo", null)
                        .WithMany("Links")
                        .HasForeignKey("VeiculoId");
                });

            modelBuilder.Entity("mf_apis_web_services_fuel_manager.Models.VeiculoUsuarios", b =>
                {
                    b.HasOne("mf_apis_web_services_fuel_manager.Models.Consumo", null)
                        .WithMany("Usuarios")
                        .HasForeignKey("ConsumoId");

                    b.HasOne("mf_apis_web_services_fuel_manager.Models.Usuario", "Usuario")
                        .WithMany("Veiculos")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("mf_apis_web_services_fuel_manager.Models.Veiculo", "Veiculo")
                        .WithMany("Usuarios")
                        .HasForeignKey("VeiculoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");

                    b.Navigation("Veiculo");
                });

            modelBuilder.Entity("mf_apis_web_services_fuel_manager.Models.Consumo", b =>
                {
                    b.Navigation("Links");

                    b.Navigation("Usuarios");
                });

            modelBuilder.Entity("mf_apis_web_services_fuel_manager.Models.Usuario", b =>
                {
                    b.Navigation("Veiculos");
                });

            modelBuilder.Entity("mf_apis_web_services_fuel_manager.Models.Veiculo", b =>
                {
                    b.Navigation("Consumos");

                    b.Navigation("Links");

                    b.Navigation("Usuarios");
                });
#pragma warning restore 612, 618
        }
    }
}
