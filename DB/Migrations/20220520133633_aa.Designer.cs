﻿// <auto-generated />
using System;
using DatabaseClass;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DB.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20220520133633_aa")]
    partial class aa
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DB.Entities.Car", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("ActiveFlag")
                        .HasColumnType("bit");

                    b.Property<bool>("BoardComputer")
                        .HasColumnType("bit");

                    b.Property<string>("CarBrand")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("CarKm")
                        .HasColumnType("float");

                    b.Property<string>("CarOwnerId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("Climate")
                        .HasColumnType("bit");

                    b.Property<string>("ColorCar")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DoorNumbers")
                        .HasColumnType("int");

                    b.Property<string>("Engine")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EnginePower")
                        .HasColumnType("int");

                    b.Property<string>("Fuel")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("FuelConsumption")
                        .HasColumnType("float");

                    b.Property<string>("GearBox")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("Image")
                        .HasColumnType("varbinary(max)");

                    b.Property<DateTime>("LastServicesData")
                        .HasColumnType("datetime2");

                    b.Property<int>("LastServicesKm")
                        .HasColumnType("int");

                    b.Property<string>("ModelCar")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Navigation")
                        .HasColumnType("bit");

                    b.Property<int>("PricePerDay")
                        .HasColumnType("int");

                    b.Property<int>("SeatNumbers")
                        .HasColumnType("int");

                    b.Property<string>("Traction")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CarOwnerId");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("DB.Entities.CategoryCar", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CarId")
                        .HasColumnType("int");

                    b.Property<string>("NameCategoryCar")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CarId");

                    b.ToTable("CategoryCars");
                });

            modelBuilder.Entity("DB.Entities.HistoryClient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClientId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<double>("KmTraveled")
                        .HasColumnType("float");

                    b.Property<int>("MoneyPaid")
                        .HasColumnType("int");

                    b.Property<string>("Notest")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Raiting")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.ToTable("HistoryClient");
                });

            modelBuilder.Entity("DB.Entities.Preferences", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CarBrand")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CategoryCar")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClientId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("DoorNumbers")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.ToTable("Preferences");
                });

            modelBuilder.Entity("DB.Entities.RentSchedulingCar", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CarId")
                        .HasColumnType("int");

                    b.Property<bool>("ChildSeatOption")
                        .HasColumnType("bit");

                    b.Property<string>("ClientId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CompletName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FinishDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Gps")
                        .HasColumnType("bit");

                    b.Property<string>("Mention")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumberOfDay")
                        .HasColumnType("int");

                    b.Property<string>("PayMethod")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Response")
                        .HasColumnType("bit");

                    b.Property<bool>("ResponseValue")
                        .HasColumnType("bit");

                    b.Property<string>("ReturnLocation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ReturnTime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("SnowChains")
                        .HasColumnType("bit");

                    b.Property<DateTime>("StarDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("TakeLocation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TakeTime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("TotalPrice")
                        .HasColumnType("float");

                    b.Property<bool>("WindshieldFluid")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("CarId");

                    b.HasIndex("ClientId");

                    b.ToTable("RentSchedulingCars");
                });

            modelBuilder.Entity("DB.Entities.Request", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CarId")
                        .HasColumnType("int");

                    b.Property<string>("Message")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Response")
                        .HasColumnType("bit");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("CarId");

                    b.HasIndex("UserId");

                    b.ToTable("Requests");
                });

            modelBuilder.Entity("DB.Entities.SmartDevice", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("baselineEnergyConsumtion")
                        .HasColumnType("int");

                    b.Property<string>("clientId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("locatin")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("maxEnergyConsumtion")
                        .HasColumnType("int");

                    b.Property<int?>("smartSenzorId")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("clientId");

                    b.HasIndex("smartSenzorId");

                    b.ToTable("SmartDevices");
                });

            modelBuilder.Entity("DB.Entities.SmartSenzor", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("maximumValue")
                        .HasColumnType("int");

                    b.Property<string>("senzorDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("smartDeviceId")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("smartDeviceId");

                    b.ToTable("SmartSenzors");
                });

            modelBuilder.Entity("DB.Entities.SmartSenzorValue", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IdSenzor")
                        .HasColumnType("int");

                    b.Property<double>("MeasurementValue")
                        .HasColumnType("float");

                    b.Property<long>("TimeStamp")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("SmartSenzorValues");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityUser");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("DB.Entities.User", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityUser");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Test")
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("User");
                });

            modelBuilder.Entity("DB.Entities.Car", b =>
                {
                    b.HasOne("DB.Entities.User", "CarOwner")
                        .WithMany("OwnedCar")
                        .HasForeignKey("CarOwnerId");

                    b.Navigation("CarOwner");
                });

            modelBuilder.Entity("DB.Entities.CategoryCar", b =>
                {
                    b.HasOne("DB.Entities.Car", null)
                        .WithMany("CategoryCar")
                        .HasForeignKey("CarId");
                });

            modelBuilder.Entity("DB.Entities.HistoryClient", b =>
                {
                    b.HasOne("DB.Entities.User", "Client")
                        .WithMany("HistoryClients")
                        .HasForeignKey("ClientId");

                    b.Navigation("Client");
                });

            modelBuilder.Entity("DB.Entities.Preferences", b =>
                {
                    b.HasOne("DB.Entities.User", "Client")
                        .WithMany("PreferencesCarList")
                        .HasForeignKey("ClientId");

                    b.Navigation("Client");
                });

            modelBuilder.Entity("DB.Entities.RentSchedulingCar", b =>
                {
                    b.HasOne("DB.Entities.Car", "Car")
                        .WithMany("RentSchedulingCarList")
                        .HasForeignKey("CarId");

                    b.HasOne("DB.Entities.User", "Client")
                        .WithMany()
                        .HasForeignKey("ClientId");

                    b.Navigation("Car");

                    b.Navigation("Client");
                });

            modelBuilder.Entity("DB.Entities.Request", b =>
                {
                    b.HasOne("DB.Entities.Car", "Car")
                        .WithMany()
                        .HasForeignKey("CarId");

                    b.HasOne("DB.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("Car");

                    b.Navigation("User");
                });

            modelBuilder.Entity("DB.Entities.SmartDevice", b =>
                {
                    b.HasOne("DB.Entities.User", "client")
                        .WithMany("smartDeviceList")
                        .HasForeignKey("clientId");

                    b.HasOne("DB.Entities.SmartSenzor", "smartSenzor")
                        .WithMany()
                        .HasForeignKey("smartSenzorId");

                    b.Navigation("client");

                    b.Navigation("smartSenzor");
                });

            modelBuilder.Entity("DB.Entities.SmartSenzor", b =>
                {
                    b.HasOne("DB.Entities.SmartDevice", "smartDevice")
                        .WithMany()
                        .HasForeignKey("smartDeviceId");

                    b.Navigation("smartDevice");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DB.Entities.Car", b =>
                {
                    b.Navigation("CategoryCar");

                    b.Navigation("RentSchedulingCarList");
                });

            modelBuilder.Entity("DB.Entities.User", b =>
                {
                    b.Navigation("HistoryClients");

                    b.Navigation("OwnedCar");

                    b.Navigation("PreferencesCarList");

                    b.Navigation("smartDeviceList");
                });
#pragma warning restore 612, 618
        }
    }
}
