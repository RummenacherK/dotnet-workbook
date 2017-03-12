﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using SaveThem.Data;

namespace SaveThem.Migrations
{
    [DbContext(typeof(EsDbContext))]
    partial class EsDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SaveThem.Models.Cart", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("Amount");

                    b.Property<int>("SpeciesId");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Cart");
                });

            modelBuilder.Entity("SaveThem.Models.CountryCode", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Label")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("CountryCode");
                });

            modelBuilder.Entity("SaveThem.Models.Donation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("Amount");

                    b.Property<int>("SpeciesId");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Donation");
                });

            modelBuilder.Entity("SaveThem.Models.Species", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ComName");

                    b.Property<int>("CountryCodeId");

                    b.Property<int>("EntityId");

                    b.Property<DateTime>("ListingDate");

                    b.Property<string>("PopAbbrev");

                    b.Property<string>("PopDesc");

                    b.Property<string>("SciName");

                    b.Property<string>("SpCode");

                    b.Property<int>("StatusCodeId");

                    b.Property<int>("TSN");

                    b.Property<string>("VipCode");

                    b.HasKey("Id");

                    b.HasIndex("CountryCodeId");

                    b.HasIndex("StatusCodeId");

                    b.ToTable("Species");
                });

            modelBuilder.Entity("SaveThem.Models.StatusCode", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Label")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("StatusCode");
                });

            modelBuilder.Entity("SaveThem.Models.Species", b =>
                {
                    b.HasOne("SaveThem.Models.CountryCode", "CountryCode")
                        .WithMany("Species")
                        .HasForeignKey("CountryCodeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SaveThem.Models.StatusCode", "StatusCode")
                        .WithMany("Species")
                        .HasForeignKey("StatusCodeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}