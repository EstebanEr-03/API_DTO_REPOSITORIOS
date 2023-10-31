﻿// <auto-generated />
using System;
using BochaAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BochaAPI.Migrations
{
    [DbContext(typeof(BochaDbContext))]
    partial class BochaDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BochaAPI.Domain.Caminata", b =>
                {
                    b.Property<Guid>("IdCaminata")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Distancia")
                        .HasColumnType("float");

                    b.Property<Guid>("IdDificultad")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdRegion")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ImagenCaminataURL")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdCaminata");

                    b.ToTable("Caminatas");
                });

            modelBuilder.Entity("BochaAPI.Domain.Dificultad", b =>
                {
                    b.Property<Guid>("IdDificultad")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdDificultad");

                    b.ToTable("Dificutades");

                    b.HasData(
                        new
                        {
                            IdDificultad = new Guid("7770a7c2-ef67-4852-8f96-49235cba1515"),
                            Nombre = "Easy"
                        },
                        new
                        {
                            IdDificultad = new Guid("3d8a684f-75f1-4dce-86d0-e4681e9c1859"),
                            Nombre = "Medium"
                        },
                        new
                        {
                            IdDificultad = new Guid("ce67dfa5-2908-406d-89e3-d8aaecb68cef"),
                            Nombre = "Hard"
                        });
                });

            modelBuilder.Entity("BochaAPI.Domain.Region", b =>
                {
                    b.Property<Guid>("IdRegion")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RegionImageURL")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdRegion");

                    b.ToTable("Regiones");

                    b.HasData(
                        new
                        {
                            IdRegion = new Guid("6ee6ae5c-e2a9-4c11-80b6-9977d3b2837e"),
                            Code = "OKA",
                            Nombre = "OKLAND",
                            RegionImageURL = "https://www.google.com/url?sa=i&url=https%3A%2F%2Fwww.goal.com%2Fen%2Flists%2Flionel-messi-want-make-olynpic-history-paris-2024-invitation-argentina-inter-miami-icon-games-france%2Fbltbc7be24aac1d9483&psig=AOvVaw2GA6GRIX7QwpOn0WxQfCqU&ust=1698706541950000&source=images&cd=vfe&opi=89978449&ved=0CBEQjRxqFwoTCLji-pGtnIIDFQAAAAAdAAAAABAE"
                        },
                        new
                        {
                            IdRegion = new Guid("7f994b7e-7eb2-45c4-8a13-80bdc9afd229"),
                            Code = "AMB",
                            Nombre = "Ambato",
                            RegionImageURL = "https://viapais.com.ar/resizer/fhAUasx4qvTMGOwvqChc_1H7Urk=/1080x1350/smart/cloudfront-us-east-1.images.arcpublishing.com/grupoclarin/6LU6B2QP4NDAHIJFTJGKS7NDKI.jpg"
                        },
                        new
                        {
                            IdRegion = new Guid("2ec86d04-967a-408c-83d0-d7d89c1386f6"),
                            Code = "CLI",
                            Nombre = "Cali",
                            RegionImageURL = "https://freshstreetculture.com/cdn/shop/files/hasbulla1_d677ff1d-cc0f-447d-aa5e-b8339cde6712.jpg?v=1685477923&width=1445"
                        });
                });

            modelBuilder.Entity("BochaAPI.Models.Domain.Imagen", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FileDescricion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FileExtension")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FilePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("FileSizeInBytes")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("Imagenes");
                });
#pragma warning restore 612, 618
        }
    }
}
