﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace StockControl.Migrations
{
    [DbContext(typeof(StockControlContext))]
    [Migration("20210202222412_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("StockControl.Models.Operation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<string>("Corretora")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<DateTime>("DateTrade")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("StatusOperation")
                        .HasColumnType("int");

                    b.Property<int?>("TaxOperationId")
                        .HasColumnType("int");

                    b.Property<int>("TypeOperation")
                        .HasColumnType("int");

                    b.Property<double>("ValorTotalTraded")
                        .HasColumnType("double");

                    b.Property<double>("ValorUnit")
                        .HasColumnType("double");

                    b.HasKey("Id");

                    b.HasIndex("TaxOperationId");

                    b.ToTable("Operation");
                });

            modelBuilder.Entity("StockControl.Models.Stock", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("NameCompany")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int?>("OperationId")
                        .HasColumnType("int");

                    b.Property<int>("Sector")
                        .HasColumnType("int");

                    b.Property<string>("StockName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.HasIndex("OperationId");

                    b.ToTable("Stock");
                });

            modelBuilder.Entity("StockControl.Models.TaxOperation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<double>("ValorCblc")
                        .HasColumnType("double");

                    b.Property<double>("ValorCorretagem")
                        .HasColumnType("double");

                    b.Property<double>("ValorEmolumentos")
                        .HasColumnType("double");

                    b.Property<double>("ValorIrrf")
                        .HasColumnType("double");

                    b.Property<double>("ValorIss")
                        .HasColumnType("double");

                    b.Property<double>("ValorTotalTax")
                        .HasColumnType("double");

                    b.HasKey("Id");

                    b.ToTable("TaxOperation");
                });

            modelBuilder.Entity("StockControl.Models.Operation", b =>
                {
                    b.HasOne("StockControl.Models.TaxOperation", "TaxOperation")
                        .WithMany()
                        .HasForeignKey("TaxOperationId");
                });

            modelBuilder.Entity("StockControl.Models.Stock", b =>
                {
                    b.HasOne("StockControl.Models.Operation", "Operation")
                        .WithMany("StockList")
                        .HasForeignKey("OperationId");
                });
#pragma warning restore 612, 618
        }
    }
}
