﻿// <auto-generated />
using System;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(AplicationDbContext))]
    partial class AplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Domain.Entities.Car", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Airbag")
                        .HasColumnType("text");

                    b.Property<string>("Auction")
                        .HasColumnType("text");

                    b.Property<DateTimeOffset>("AuctionDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("BodyType")
                        .HasColumnType("text");

                    b.Property<string>("Equipment")
                        .HasColumnType("text");

                    b.Property<int>("Final_Bid")
                        .HasColumnType("integer");

                    b.Property<string>("Key")
                        .HasColumnType("text");

                    b.Property<string>("Loss")
                        .HasColumnType("text");

                    b.Property<int>("Lot")
                        .HasColumnType("integer");

                    b.Property<string>("Make")
                        .HasColumnType("text");

                    b.Property<string>("ManufacturedIn")
                        .HasColumnType("text");

                    b.Property<string>("Model")
                        .HasColumnType("text");

                    b.Property<int>("Odometer")
                        .HasColumnType("integer");

                    b.Property<string>("PrimaryDamage")
                        .HasColumnType("text");

                    b.Property<string>("SecondaryDamage")
                        .HasColumnType("text");

                    b.Property<string>("Seller")
                        .HasColumnType("text");

                    b.Property<string>("SellingBranch")
                        .HasColumnType("text");

                    b.Property<string>("StartCode")
                        .HasColumnType("text");

                    b.Property<string>("Transmission")
                        .HasColumnType("text");

                    b.Property<string>("VIN")
                        .HasColumnType("text");

                    b.Property<string>("VINStatus")
                        .HasColumnType("text");

                    b.Property<int>("Year")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("Domain.Entities.CarImage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CarId")
                        .HasColumnType("integer");

                    b.Property<string>("ImageName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CarId");

                    b.ToTable("CarImages");
                });

            modelBuilder.Entity("Domain.Entities.CarImage", b =>
                {
                    b.HasOne("Domain.Entities.Car", "Car")
                        .WithMany("CarImages")
                        .HasForeignKey("CarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Car");
                });

            modelBuilder.Entity("Domain.Entities.Car", b =>
                {
                    b.Navigation("CarImages");
                });
#pragma warning restore 612, 618
        }
    }
}
