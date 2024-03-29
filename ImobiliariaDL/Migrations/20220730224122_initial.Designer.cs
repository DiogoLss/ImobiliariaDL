﻿// <auto-generated />
using System;
using ImobiliariaDL.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ImobiliariaDL.Migrations
{
    [DbContext(typeof(ImobiliariaDLDbContext))]
    [Migration("20220730224122_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ImobiliariaDL.Models.Endereco", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CEP")
                        .IsRequired()
                        .HasMaxLength(16)
                        .HasColumnType("nvarchar(16)");

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ImovelId")
                        .HasColumnType("int");

                    b.Property<int?>("Numero")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<string>("Rua")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ImovelId");

                    b.ToTable("Endereco");
                });

            modelBuilder.Entity("ImobiliariaDL.Models.Imagem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ImagemString")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ImovelId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ImovelId");

                    b.ToTable("Imagens");
                });

            modelBuilder.Entity("ImobiliariaDL.Models.Imovel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Banheiros")
                        .HasColumnType("int");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<bool>("ECondominioOuApartamento")
                        .HasColumnType("bit");

                    b.Property<int>("Garagens")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("NumeroDoApCd")
                        .HasColumnType("int");

                    b.Property<decimal>("Preco")
                        .HasColumnType("decimal(10,2)");

                    b.Property<int>("Quartos")
                        .HasColumnType("int");

                    b.Property<int>("Salas")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Imoveis");
                });

            modelBuilder.Entity("ImobiliariaDL.Models.Endereco", b =>
                {
                    b.HasOne("ImobiliariaDL.Models.Imovel", "Imovel")
                        .WithMany()
                        .HasForeignKey("ImovelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Imovel");
                });

            modelBuilder.Entity("ImobiliariaDL.Models.Imagem", b =>
                {
                    b.HasOne("ImobiliariaDL.Models.Imovel", "Imovel")
                        .WithMany()
                        .HasForeignKey("ImovelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Imovel");
                });
#pragma warning restore 612, 618
        }
    }
}
