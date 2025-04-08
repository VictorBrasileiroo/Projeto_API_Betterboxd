﻿// <auto-generated />
using System;
using Betterboxd.Infra.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Betterboxd.Infra.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20250408232830_update_modelCreating_avaliacaModel")]
    partial class update_modelCreating_avaliacaModel
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Betterboxd.Core.Entities.AvaliacaoModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Comentario")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateOnly>("DataAvaliacao")
                        .HasColumnType("date");

                    b.Property<int?>("FilmeModelId")
                        .HasColumnType("int");

                    b.Property<int>("IdFilme")
                        .HasColumnType("int");

                    b.Property<int>("IdUser")
                        .HasColumnType("int");

                    b.Property<decimal>("Nota")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("UserModelId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FilmeModelId");

                    b.HasIndex("IdFilme");

                    b.HasIndex("IdUser");

                    b.HasIndex("UserModelId");

                    b.ToTable("Avaliações");
                });

            modelBuilder.Entity("Betterboxd.Core.Entities.FilmeModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateOnly>("DataLancamento")
                        .HasColumnType("date");

                    b.Property<string>("Diretor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Genero")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("NotaMedia")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Sinopse")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Titulo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Filmes");
                });

            modelBuilder.Entity("Betterboxd.Core.Entities.UserModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Usuários");
                });

            modelBuilder.Entity("Betterboxd.Core.Entities.AvaliacaoModel", b =>
                {
                    b.HasOne("Betterboxd.Core.Entities.FilmeModel", null)
                        .WithMany("Avaliacoes")
                        .HasForeignKey("FilmeModelId");

                    b.HasOne("Betterboxd.Core.Entities.FilmeModel", "Filme")
                        .WithMany()
                        .HasForeignKey("IdFilme")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Betterboxd.Core.Entities.UserModel", "Usuario")
                        .WithMany()
                        .HasForeignKey("IdUser")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Betterboxd.Core.Entities.UserModel", null)
                        .WithMany("Avaliacoes")
                        .HasForeignKey("UserModelId");

                    b.Navigation("Filme");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Betterboxd.Core.Entities.FilmeModel", b =>
                {
                    b.Navigation("Avaliacoes");
                });

            modelBuilder.Entity("Betterboxd.Core.Entities.UserModel", b =>
                {
                    b.Navigation("Avaliacoes");
                });
#pragma warning restore 612, 618
        }
    }
}
