﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PetShopAPI.Persistence;

#nullable disable

namespace PetShopAPI.Migrations
{
    [DbContext(typeof(PetShopContext))]
    [Migration("20220726134444_tabelaPlano")]
    partial class tabelaPlano
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("PetShopAPI.Models.Animal", b =>
                {
                    b.Property<int>("AnimalId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AnimalId"), 1L, 1);

                    b.Property<bool>("Castrado")
                        .HasColumnType("bit");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("datetime2");

                    b.Property<int>("Especie")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<decimal?>("Peso")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("PlanoId")
                        .HasColumnType("int");

                    b.HasKey("AnimalId");

                    b.HasIndex("PlanoId");

                    b.ToTable("Tbl_Animal");
                });

            modelBuilder.Entity("PetShopAPI.Models.ContratoTrabalho", b =>
                {
                    b.Property<int>("ContratoTrabalhoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ContratoTrabalhoId"), 1L, 1);

                    b.Property<DateTime>("DataContratacao")
                        .HasColumnType("date")
                        .HasColumnName("Dt_Contratacao");

                    b.Property<int>("TipoContrato")
                        .HasColumnType("int");

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ContratoTrabalhoId");

                    b.ToTable("Tbl_Contrato_Trabalho");
                });

            modelBuilder.Entity("PetShopAPI.Models.Plano", b =>
                {
                    b.Property<int>("PlanoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PlanoId"), 1L, 1);

                    b.Property<bool>("Disponivel")
                        .HasColumnType("bit");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("PlanoId");

                    b.ToTable("Tbl_Plano");
                });

            modelBuilder.Entity("PetShopAPI.Models.Veterinario", b =>
                {
                    b.Property<int>("VeterinarioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("VeterinarioId"), 1L, 1);

                    b.Property<int>("ContratoTrabalhoId")
                        .HasColumnType("int");

                    b.Property<string>("Especialidade")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.HasKey("VeterinarioId");

                    b.HasIndex("ContratoTrabalhoId");

                    b.ToTable("Tbl_Veterinario");
                });

            modelBuilder.Entity("PetShopAPI.Models.Animal", b =>
                {
                    b.HasOne("PetShopAPI.Models.Plano", "Plano")
                        .WithMany("Animais")
                        .HasForeignKey("PlanoId");

                    b.Navigation("Plano");
                });

            modelBuilder.Entity("PetShopAPI.Models.Veterinario", b =>
                {
                    b.HasOne("PetShopAPI.Models.ContratoTrabalho", "ContratoTrabalho")
                        .WithMany()
                        .HasForeignKey("ContratoTrabalhoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ContratoTrabalho");
                });

            modelBuilder.Entity("PetShopAPI.Models.Plano", b =>
                {
                    b.Navigation("Animais");
                });
#pragma warning restore 612, 618
        }
    }
}