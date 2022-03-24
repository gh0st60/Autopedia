﻿// <auto-generated />
using Autopedia.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Autopedia.Migrations
{
    [DbContext(typeof(CarsDBContext))]
    partial class CarsDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("Autopedia.Models.Car", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(4000)
                        .HasColumnType("nvarchar(4000)");

                    b.Property<string>("PhotoUrl")
                        .HasMaxLength(4000)
                        .HasColumnType("nvarchar(4000)");

                    b.HasKey("Id");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("Autopedia.Models.FamousCar", b =>
                {
                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(4000)
                        .HasColumnType("nvarchar(4000)");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasMaxLength(4000)
                        .HasColumnType("nvarchar(4000)");

                    b.Property<string>("PhotoUrl")
                        .HasMaxLength(4000)
                        .HasColumnType("nvarchar(4000)");

                    b.ToTable("FamousCars");
                });

            modelBuilder.Entity("Autopedia.Models.FormulaTeam", b =>
                {
                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(4000)
                        .HasColumnType("nvarchar(4000)");

                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    b.Property<string>("PhotoUrl")
                        .HasMaxLength(4000)
                        .HasColumnType("nvarchar(4000)");

                    b.Property<string>("Team")
                        .IsRequired()
                        .HasColumnType("text");

                    b.ToTable("FormulaTeams");
                });
#pragma warning restore 612, 618
        }
    }
}