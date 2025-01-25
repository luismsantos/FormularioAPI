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
    [Migration("20250122165736_FormularioTabela")]
    partial class FormularioTabela
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

                    b.HasKey("PerguntaId");

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

            modelBuilder.Entity("FormularioPergunta", b =>
                {
                    b.Property<int>("FormulariosId")
                        .HasColumnType("int");

                    b.Property<int>("PerguntasPerguntaId")
                        .HasColumnType("int");

                    b.HasKey("FormulariosId", "PerguntasPerguntaId");

                    b.HasIndex("PerguntasPerguntaId");

                    b.ToTable("FormularioPergunta");
                });

            modelBuilder.Entity("FormularioAPI.Models.Resposta", b =>
                {
                    b.HasOne("FormularioAPI.Models.Pergunta", null)
                        .WithMany("Respostas")
                        .HasForeignKey("PerguntaId");
                });

            modelBuilder.Entity("FormularioPergunta", b =>
                {
                    b.HasOne("FormularioAPI.Models.Formulario", null)
                        .WithMany()
                        .HasForeignKey("FormulariosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FormularioAPI.Models.Pergunta", null)
                        .WithMany()
                        .HasForeignKey("PerguntasPerguntaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FormularioAPI.Models.Pergunta", b =>
                {
                    b.Navigation("Respostas");
                });
#pragma warning restore 612, 618
        }
    }
}
