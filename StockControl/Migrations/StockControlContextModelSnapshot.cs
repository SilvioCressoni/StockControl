﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace StockControl.Migrations
{
    [DbContext(typeof(StockControlContext))]
    partial class StockControlContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Corretora")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<DateTime>("DateTrade")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("StatusOperation")
                        .HasColumnType("int");

                    b.Property<string>("Stock")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("TypeOperation")
                        .HasColumnType("int");

                    b.Property<double>("ValorTotalTraded")
                        .HasColumnType("double");

                    b.Property<double>("ValorUnit")
                        .HasColumnType("double");

                    b.HasKey("Id");

                    b.ToTable("Operation");
                });
#pragma warning restore 612, 618
        }
    }
}
