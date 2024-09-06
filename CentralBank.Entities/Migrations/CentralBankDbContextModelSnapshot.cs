﻿// <auto-generated />
using System;
using CentralBank.Entities.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CentralBank.Entities.Migrations
{
    [DbContext(typeof(CentralBankDbContext))]
    partial class CentralBankDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CentralBank.Entities.Models.History", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Histories");
                });

            modelBuilder.Entity("CentralBank.Entities.Models.Root", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ValCursId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ValCursId");

                    b.ToTable("Roots");
                });

            modelBuilder.Entity("CentralBank.Entities.Models.ValCurs", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ValCurs");
                });

            modelBuilder.Entity("CentralBank.Entities.Models.ValType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ValCursId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ValCursId");

                    b.ToTable("ValTypes");
                });

            modelBuilder.Entity("CentralBank.Entities.Models.Valute", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nominal")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ValTypeId")
                        .HasColumnType("int");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ValTypeId");

                    b.ToTable("Valutes");
                });

            modelBuilder.Entity("CentralBank.Entities.Models.Root", b =>
                {
                    b.HasOne("CentralBank.Entities.Models.ValCurs", "ValCurs")
                        .WithMany()
                        .HasForeignKey("ValCursId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ValCurs");
                });

            modelBuilder.Entity("CentralBank.Entities.Models.ValType", b =>
                {
                    b.HasOne("CentralBank.Entities.Models.ValCurs", "Curs")
                        .WithMany("ValType")
                        .HasForeignKey("ValCursId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Curs");
                });

            modelBuilder.Entity("CentralBank.Entities.Models.Valute", b =>
                {
                    b.HasOne("CentralBank.Entities.Models.ValType", "ValType")
                        .WithMany("Valute")
                        .HasForeignKey("ValTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ValType");
                });

            modelBuilder.Entity("CentralBank.Entities.Models.ValCurs", b =>
                {
                    b.Navigation("ValType");
                });

            modelBuilder.Entity("CentralBank.Entities.Models.ValType", b =>
                {
                    b.Navigation("Valute");
                });
#pragma warning restore 612, 618
        }
    }
}
