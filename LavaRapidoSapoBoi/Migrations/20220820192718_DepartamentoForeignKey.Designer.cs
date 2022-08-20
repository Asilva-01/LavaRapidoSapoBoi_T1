﻿// <auto-generated />
using System;
using LavaRapidoSapoBoi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LavaRapidoSapoBoi.Migrations
{
    [DbContext(typeof(LavaRapidoSapoBoiContext))]
    [Migration("20220820192718_DepartamentoForeignKey")]
    partial class DepartamentoForeignKey
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("LavaRapidoSapoBoi.Models.Departamento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Departamento");
                });

            modelBuilder.Entity("LavaRapidoSapoBoi.Models.RegistroVendas", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Data");

                    b.Property<double>("Quantidade");

                    b.Property<int>("Status");

                    b.Property<int?>("VendasId");

                    b.HasKey("Id");

                    b.HasIndex("VendasId");

                    b.ToTable("RegistroVendas");
                });

            modelBuilder.Entity("LavaRapidoSapoBoi.Models.Vendas", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DataNascimento");

                    b.Property<int>("DepartamentoId");

                    b.Property<string>("Email");

                    b.Property<string>("Nome");

                    b.Property<double>("SalarioBase");

                    b.HasKey("Id");

                    b.HasIndex("DepartamentoId");

                    b.ToTable("Vendas");
                });

            modelBuilder.Entity("LavaRapidoSapoBoi.Models.RegistroVendas", b =>
                {
                    b.HasOne("LavaRapidoSapoBoi.Models.Vendas", "Vendas")
                        .WithMany("Venda")
                        .HasForeignKey("VendasId");
                });

            modelBuilder.Entity("LavaRapidoSapoBoi.Models.Vendas", b =>
                {
                    b.HasOne("LavaRapidoSapoBoi.Models.Departamento", "Departamento")
                        .WithMany("Vendas")
                        .HasForeignKey("DepartamentoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
