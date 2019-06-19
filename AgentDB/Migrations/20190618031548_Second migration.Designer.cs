﻿// <auto-generated />
using System;
using AgentDB;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AgentDB.Migrations
{
    [DbContext(typeof(AgentContext))]
    [Migration("20190618031548_Second migration")]
    partial class Secondmigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AgentApp.Models.Accommodation", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("AccommodationTypeId");

                    b.Property<long>("AgentID");

                    b.Property<int>("CancellationDays");

                    b.Property<decimal>("CancellationPrice");

                    b.Property<int>("Category");

                    b.Property<decimal>("DefaultPrice");

                    b.Property<string>("Description");

                    b.Property<bool>("FreeCancellation");

                    b.Property<long?>("LocationId");

                    b.Property<int>("NumberOfPersons");

                    b.HasKey("Id");

                    b.HasIndex("AccommodationTypeId");

                    b.HasIndex("AgentID");

                    b.HasIndex("LocationId");

                    b.ToTable("Accommodations");
                });

            modelBuilder.Entity("AgentApp.Models.AccommodationType", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("TypeName");

                    b.HasKey("Id");

                    b.ToTable("AccommodationTypes");
                });

            modelBuilder.Entity("AgentApp.Models.AdditionalService", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("AccommodationId");

                    b.Property<string>("AdditionalServiceName");

                    b.HasKey("Id");

                    b.HasIndex("AccommodationId");

                    b.ToTable("AdditionalServices");
                });

            modelBuilder.Entity("AgentApp.Models.Agent", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Adress");

                    b.Property<int>("BussinesID");

                    b.Property<string>("Email");

                    b.Property<string>("Lastname");

                    b.Property<string>("Name");

                    b.Property<string>("Password");

                    b.Property<string>("Username");

                    b.HasKey("Id");

                    b.ToTable("Agents");
                });

            modelBuilder.Entity("AgentApp.Models.Location", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address");

                    b.Property<string>("City");

                    b.Property<string>("Country");

                    b.Property<decimal>("Latitude");

                    b.Property<decimal>("Longitude");

                    b.HasKey("Id");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("AgentApp.Models.Message", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Content");

                    b.Property<int>("Direction");

                    b.Property<long?>("ReservationId");

                    b.Property<DateTime>("Timestamp");

                    b.HasKey("Id");

                    b.HasIndex("ReservationId");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("AgentApp.Models.PeriodPrice", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("AccommodationId");

                    b.Property<DateTime>("EndDate");

                    b.Property<decimal>("Price");

                    b.Property<DateTime>("StartDate");

                    b.HasKey("Id");

                    b.HasIndex("AccommodationId");

                    b.ToTable("PeriodPrices");
                });

            modelBuilder.Entity("AgentApp.Models.Reservation", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("AccommodationId");

                    b.Property<DateTime>("EndDate");

                    b.Property<bool>("Realized");

                    b.Property<long?>("ReservationRatingId");

                    b.Property<DateTime>("StartDate");

                    b.Property<long?>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("AccommodationId");

                    b.HasIndex("ReservationRatingId");

                    b.HasIndex("UserId");

                    b.ToTable("Reservations");
                });

            modelBuilder.Entity("AgentApp.Models.ReservationRating", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Comment");

                    b.Property<bool>("Published");

                    b.Property<int>("Rating");

                    b.Property<DateTime>("Timestamp");

                    b.HasKey("Id");

                    b.ToTable("ReservationRatings");
                });

            modelBuilder.Entity("AgentApp.Models.Unavailability", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("AccommodationId");

                    b.Property<DateTime>("EndDate");

                    b.Property<DateTime>("StartDate");

                    b.HasKey("Id");

                    b.HasIndex("AccommodationId");

                    b.ToTable("Unavailabilities");
                });

            modelBuilder.Entity("AgentApp.Models.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Deleted");

                    b.Property<string>("Email");

                    b.Property<bool>("Enabled");

                    b.Property<string>("Lastname");

                    b.Property<string>("Name");

                    b.Property<string>("Password");

                    b.Property<string>("Username");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("AgentDB.Models.ReservationLong", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("AccommodationId");

                    b.Property<long>("Value");

                    b.HasKey("Id");

                    b.HasIndex("AccommodationId");

                    b.ToTable("ReservationLong");
                });

            modelBuilder.Entity("AgentApp.Models.Accommodation", b =>
                {
                    b.HasOne("AgentApp.Models.AccommodationType", "AccommodationType")
                        .WithMany()
                        .HasForeignKey("AccommodationTypeId");

                    b.HasOne("AgentApp.Models.Agent", "Agent")
                        .WithMany("Accommodation")
                        .HasForeignKey("AgentID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AgentApp.Models.Location", "Location")
                        .WithMany()
                        .HasForeignKey("LocationId");
                });

            modelBuilder.Entity("AgentApp.Models.AdditionalService", b =>
                {
                    b.HasOne("AgentApp.Models.Accommodation")
                        .WithMany("AdditionalService")
                        .HasForeignKey("AccommodationId");
                });

            modelBuilder.Entity("AgentApp.Models.Message", b =>
                {
                    b.HasOne("AgentApp.Models.Reservation")
                        .WithMany("Message")
                        .HasForeignKey("ReservationId");
                });

            modelBuilder.Entity("AgentApp.Models.PeriodPrice", b =>
                {
                    b.HasOne("AgentApp.Models.Accommodation")
                        .WithMany("PeriodPrice")
                        .HasForeignKey("AccommodationId");
                });

            modelBuilder.Entity("AgentApp.Models.Reservation", b =>
                {
                    b.HasOne("AgentApp.Models.Accommodation", "Accommodation")
                        .WithMany()
                        .HasForeignKey("AccommodationId");

                    b.HasOne("AgentApp.Models.ReservationRating", "ReservationRating")
                        .WithMany()
                        .HasForeignKey("ReservationRatingId");

                    b.HasOne("AgentApp.Models.User", "User")
                        .WithMany("Reservation")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("AgentApp.Models.Unavailability", b =>
                {
                    b.HasOne("AgentApp.Models.Accommodation")
                        .WithMany("Unavailability")
                        .HasForeignKey("AccommodationId");
                });

            modelBuilder.Entity("AgentDB.Models.ReservationLong", b =>
                {
                    b.HasOne("AgentApp.Models.Accommodation")
                        .WithMany("ReservationIds")
                        .HasForeignKey("AccommodationId");
                });
#pragma warning restore 612, 618
        }
    }
}
