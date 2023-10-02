﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RentCarApi.Persistence.Context;

#nullable disable

namespace RentCarApi.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230927113314_VehiclesMigration")]
    partial class VehiclesMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("RentCarApi.Entities.Vehicles.BaseEntities.Vehicle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("AirCondition")
                        .HasColumnType("bit");

                    b.Property<short>("DoorsCount")
                        .HasColumnType("smallint");

                    b.Property<double>("EngineVolume")
                        .HasColumnType("float");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("LuggagesCount")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MarkId")
                        .HasColumnType("int");

                    b.Property<int>("ModelId")
                        .HasColumnType("int");

                    b.Property<string>("ReleaseYear")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("RentalPrice")
                        .HasColumnType("float");

                    b.Property<short>("SeatCount")
                        .HasColumnType("smallint");

                    b.Property<int>("Transmission")
                        .HasColumnType("int");

                    b.Property<int>("VehicleLocationId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MarkId");

                    b.HasIndex("ModelId");

                    b.HasIndex("VehicleLocationId");

                    b.ToTable("Vehicle");
                });

            modelBuilder.Entity("RentCarApi.Entities.Vehicles.TechnicalInformation.Mark", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("MarkName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Mark");
                });

            modelBuilder.Entity("RentCarApi.Entities.Vehicles.TechnicalInformation.Model", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("ModelName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Model");
                });

            modelBuilder.Entity("RentCarApi.Entities.Vehicles.TechnicalInformation.VehicleLocation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("VehicleLocation");
                });

            modelBuilder.Entity("RentCarApi.Entities.Vehicles.BaseEntities.Vehicle", b =>
                {
                    b.HasOne("RentCarApi.Entities.Vehicles.TechnicalInformation.Mark", "Mark")
                        .WithMany("Vehicles")
                        .HasForeignKey("MarkId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("RentCarApi.Entities.Vehicles.TechnicalInformation.Model", "Model")
                        .WithMany("Vehicles")
                        .HasForeignKey("ModelId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("RentCarApi.Entities.Vehicles.TechnicalInformation.VehicleLocation", "VehicleLocation")
                        .WithMany("Vehicles")
                        .HasForeignKey("VehicleLocationId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Mark");

                    b.Navigation("Model");

                    b.Navigation("VehicleLocation");
                });

            modelBuilder.Entity("RentCarApi.Entities.Vehicles.TechnicalInformation.Mark", b =>
                {
                    b.Navigation("Vehicles");
                });

            modelBuilder.Entity("RentCarApi.Entities.Vehicles.TechnicalInformation.Model", b =>
                {
                    b.Navigation("Vehicles");
                });

            modelBuilder.Entity("RentCarApi.Entities.Vehicles.TechnicalInformation.VehicleLocation", b =>
                {
                    b.Navigation("Vehicles");
                });
#pragma warning restore 612, 618
        }
    }
}
