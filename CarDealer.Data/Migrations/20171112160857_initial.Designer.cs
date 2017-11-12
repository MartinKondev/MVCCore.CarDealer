﻿// <auto-generated />
using CarDealer.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace CarDealer.Data.Migrations
{
    [DbContext(typeof(CarDealerDbContext))]
    [Migration("20171112160857_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CarDealer.Domain.Car", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Make")
                        .IsRequired();

                    b.Property<string>("Model")
                        .IsRequired();

                    b.Property<long>("TravelledDistance");

                    b.HasKey("Id");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("CarDealer.Domain.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("BirthDate");

                    b.Property<bool>("IsYoungDriver");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("CarDealer.Domain.Part", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<double?>("Price");

                    b.Property<int>("Quantity");

                    b.Property<int>("SupplierId");

                    b.Property<int?>("SupplierId1");

                    b.HasKey("Id");

                    b.HasIndex("SupplierId");

                    b.HasIndex("SupplierId1");

                    b.ToTable("Parts");
                });

            modelBuilder.Entity("CarDealer.Domain.PartCar", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CarId");

                    b.Property<int?>("CarId1");

                    b.Property<int>("PartId");

                    b.Property<int?>("PartId1");

                    b.HasKey("Id");

                    b.HasIndex("CarId");

                    b.HasIndex("CarId1");

                    b.HasIndex("PartId");

                    b.HasIndex("PartId1");

                    b.ToTable("PartCars");
                });

            modelBuilder.Entity("CarDealer.Domain.Sale", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CarId");

                    b.Property<int>("CarId1");

                    b.Property<int>("CarId2");

                    b.Property<int>("CustomerId");

                    b.Property<int>("CustomerId1");

                    b.Property<double>("Discount");

                    b.HasKey("Id");

                    b.HasIndex("CarId");

                    b.HasIndex("CarId1");

                    b.HasIndex("CarId2");

                    b.HasIndex("CustomerId1");

                    b.ToTable("Sales");
                });

            modelBuilder.Entity("CarDealer.Domain.Supplier", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("IsImporter");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Suppliers");
                });

            modelBuilder.Entity("CarDealer.Domain.Part", b =>
                {
                    b.HasOne("CarDealer.Domain.Supplier", "Supplier")
                        .WithMany()
                        .HasForeignKey("SupplierId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CarDealer.Domain.Supplier")
                        .WithMany("Parts")
                        .HasForeignKey("SupplierId1");
                });

            modelBuilder.Entity("CarDealer.Domain.PartCar", b =>
                {
                    b.HasOne("CarDealer.Domain.Car", "Car")
                        .WithMany()
                        .HasForeignKey("CarId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CarDealer.Domain.Car")
                        .WithMany("PartCars")
                        .HasForeignKey("CarId1");

                    b.HasOne("CarDealer.Domain.Part", "Part")
                        .WithMany()
                        .HasForeignKey("PartId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CarDealer.Domain.Part")
                        .WithMany("PartCars")
                        .HasForeignKey("PartId1");
                });

            modelBuilder.Entity("CarDealer.Domain.Sale", b =>
                {
                    b.HasOne("CarDealer.Domain.Customer")
                        .WithMany("Sales")
                        .HasForeignKey("CarId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CarDealer.Domain.Car")
                        .WithMany("Sales")
                        .HasForeignKey("CarId1")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CarDealer.Domain.Car", "Car")
                        .WithMany()
                        .HasForeignKey("CarId2")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CarDealer.Domain.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId1")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
