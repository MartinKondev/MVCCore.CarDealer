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
    [Migration("20171112184854_Reni2")]
    partial class Reni2
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

                    b.Property<int>("Supplier_Id");

                    b.HasKey("Id");

                    b.HasIndex("Supplier_Id");

                    b.ToTable("Parts");
                });

            modelBuilder.Entity("CarDealer.Domain.PartCar", b =>
                {
                    b.Property<int>("Car_Id");

                    b.Property<int>("Part_Id");

                    b.Property<int?>("CarId");

                    b.Property<int?>("PartId");

                    b.HasKey("Car_Id", "Part_Id");

                    b.HasIndex("CarId");

                    b.HasIndex("PartId");

                    b.ToTable("PartCars");
                });

            modelBuilder.Entity("CarDealer.Domain.Sale", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Car_Id");

                    b.Property<int>("Customer_Id");

                    b.Property<double>("Discount");

                    b.HasKey("Id");

                    b.HasIndex("Car_Id");

                    b.HasIndex("Customer_Id");

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
                        .WithMany("Parts")
                        .HasForeignKey("Supplier_Id")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CarDealer.Domain.PartCar", b =>
                {
                    b.HasOne("CarDealer.Domain.Car", "Car")
                        .WithMany("Parts")
                        .HasForeignKey("CarId");

                    b.HasOne("CarDealer.Domain.Part", "Part")
                        .WithMany("Cars")
                        .HasForeignKey("PartId");
                });

            modelBuilder.Entity("CarDealer.Domain.Sale", b =>
                {
                    b.HasOne("CarDealer.Domain.Car", "Car")
                        .WithMany("Sales")
                        .HasForeignKey("Car_Id")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CarDealer.Domain.Customer", "Customer")
                        .WithMany("Sales")
                        .HasForeignKey("Customer_Id")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
