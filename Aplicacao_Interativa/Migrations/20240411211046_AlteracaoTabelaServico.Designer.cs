﻿// <auto-generated />
using System;
using Aplicacao_Interativa.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Aplicacao_Interativa.Migrations
{
    [DbContext(typeof(BancoContext))]
    [Migration("20240411211046_AlteracaoTabelaServico")]
    partial class AlteracaoTabelaServico
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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

                    b.Property<int>("HorarioId")
                        .HasColumnType("int");

                    b.Property<int>("ServicoId")
                        .HasColumnType("int");

                    b.Property<int>("usuarioID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("HorarioId");

                    b.HasIndex("ServicoId");

                    b.HasIndex("usuarioID");

                    b.ToTable("Agendamentos");
                });

            modelBuilder.Entity("Aplicacao_Interativa.Models.AvaliacaoModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("AgendamentoId")
                        .HasColumnType("int");

                    b.Property<int>("Avaliacao")
                        .HasColumnType("int");

                    b.Property<string>("Comentario")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("AgendamentoId");

                    b.ToTable("Avalicoes");
                });

            modelBuilder.Entity("Aplicacao_Interativa.Models.HorarioModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Horario")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Horarios");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Horario = "09:00"
                        },
                        new
                        {
                            Id = 2,
                            Horario = "09:50"
                        },
                        new
                        {
                            Id = 3,
                            Horario = "10:40"
                        },
                        new
                        {
                            Id = 4,
                            Horario = "11:30"
                        },
                        new
                        {
                            Id = 5,
                            Horario = "13:00"
                        },
                        new
                        {
                            Id = 6,
                            Horario = "14:40"
                        },
                        new
                        {
                            Id = 7,
                            Horario = "15:30"
                        },
                        new
                        {
                            Id = 8,
                            Horario = "16:20"
                        },
                        new
                        {
                            Id = 9,
                            Horario = "17:10"
                        },
                        new
                        {
                            Id = 10,
                            Horario = "18:00"
                        },
                        new
                        {
                            Id = 11,
                            Horario = "18:50"
                        });
                });

            modelBuilder.Entity("Aplicacao_Interativa.Models.ServicoModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("CaminhoImagem")
                        .HasColumnType("longtext");

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
                    b.HasOne("Aplicacao_Interativa.Models.HorarioModel", "Horario")
                        .WithMany()
                        .HasForeignKey("HorarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

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

                    b.Navigation("Horario");

                    b.Navigation("Servico");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Aplicacao_Interativa.Models.AvaliacaoModel", b =>
                {
                    b.HasOne("Aplicacao_Interativa.Models.AgendamentoModel", "Agendamento")
                        .WithMany()
                        .HasForeignKey("AgendamentoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Agendamento");
                });

            modelBuilder.Entity("Aplicacao_Interativa.Models.UsuarioModel", b =>
                {
                    b.Navigation("Agendamentos");
                });
#pragma warning restore 612, 618
        }
    }
}
