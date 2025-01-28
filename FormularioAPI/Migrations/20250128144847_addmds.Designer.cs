﻿// <auto-generated />
using System;
using FormularioAPI.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FormularioAPI.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20250128144847_addmds")]
    partial class addmds
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("FormularioAPI.Models.Formulario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Formularios");
                });

            modelBuilder.Entity("FormularioAPI.Models.Pergunta", b =>
                {
                    b.Property<int>("PerguntaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("PerguntaId"));

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("varchar(300)");

                    b.Property<int?>("FormularioId")
                        .HasColumnType("int");

                    b.HasKey("PerguntaId");

                    b.HasIndex("FormularioId");

                    b.ToTable("Perguntas");
                });

            modelBuilder.Entity("FormularioAPI.Models.Resposta", b =>
                {
                    b.Property<int>("RespostaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("RespostaId"));

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("varchar(300)");

                    b.Property<int?>("PerguntaId")
                        .HasColumnType("int");

                    b.HasKey("RespostaId");

                    b.HasIndex("PerguntaId");

                    b.ToTable("Respostas");
                });

            modelBuilder.Entity("FormularioAPI.Models.Pergunta", b =>
                {
                    b.HasOne("FormularioAPI.Models.Formulario", null)
                        .WithMany("Perguntas")
                        .HasForeignKey("FormularioId");
                });

            modelBuilder.Entity("FormularioAPI.Models.Resposta", b =>
                {
                    b.HasOne("FormularioAPI.Models.Pergunta", null)
                        .WithMany("Respostas")
                        .HasForeignKey("PerguntaId");
                });

            modelBuilder.Entity("FormularioAPI.Models.Formulario", b =>
                {
                    b.Navigation("Perguntas");
                });

            modelBuilder.Entity("FormularioAPI.Models.Pergunta", b =>
                {
                    b.Navigation("Respostas");
                });
#pragma warning restore 612, 618
        }
    }
}
