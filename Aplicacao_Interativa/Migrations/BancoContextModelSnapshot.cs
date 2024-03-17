﻿// <auto-generated />
using System;
using Aplicacao_Interativa.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Aplicacao_Interativa.Migrations
{
    [DbContext(typeof(BancoContext))]
    partial class BancoContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.28")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Aplicacao_Interativa.Models.AgendamentoModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Barbeiro")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("DataAgendamento")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Horario")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("ServicoId")
                        .HasColumnType("int");

                    b.Property<int>("usuarioID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ServicoId");

                    b.HasIndex("usuarioID");

                    b.ToTable("Agendamentos");
                });

            modelBuilder.Entity("Aplicacao_Interativa.Models.ServicoModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<decimal>("Preco")
                        .HasColumnType("decimal(10,2)");

                    b.HasKey("Id");

                    b.ToTable("Servicos");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Nome = "Corte",
                            Preco = 25m
                        },
                        new
                        {
                            Id = 2,
                            Nome = "Barba",
                            Preco = 15m
                        },
                        new
                        {
                            Id = 3,
                            Nome = "Sobrancelha",
                            Preco = 5m
                        },
                        new
                        {
                            Id = 4,
                            Nome = "Corte + Sobrancelha",
                            Preco = 30m
                        });
                });

            modelBuilder.Entity("Aplicacao_Interativa.Models.UsuarioModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Celular")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Perfil")
                        .HasColumnType("int");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("Aplicacao_Interativa.Models.AgendamentoModel", b =>
                {
                    b.HasOne("Aplicacao_Interativa.Models.ServicoModel", "Servico")
                        .WithMany()
                        .HasForeignKey("ServicoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Aplicacao_Interativa.Models.UsuarioModel", "Usuario")
                        .WithMany("Agendamentos")
                        .HasForeignKey("usuarioID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Servico");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Aplicacao_Interativa.Models.UsuarioModel", b =>
                {
                    b.Navigation("Agendamentos");
                });
#pragma warning restore 612, 618
        }
    }
}
