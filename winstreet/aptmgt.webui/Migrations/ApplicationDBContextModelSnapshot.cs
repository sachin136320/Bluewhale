﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using aptmgt.webui.Data;

namespace aptmgt.webui.Migrations.ApplicationDB
{
    [DbContext(typeof(ApplicationDBContext))]
    partial class ApplicationDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("AppData")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("aptmgt.entity.Accounts.Account", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("AccountId")
                        .HasColumnType("integer");

                    b.Property<string>("AccountType")
                        .HasColumnType("text");

                    b.Property<int>("Accountno")
                        .HasColumnType("integer");

                    b.Property<string>("Bankname")
                        .HasColumnType("text");

                    b.Property<string>("Commid")
                        .HasColumnType("text");

                    b.Property<DateTime>("Currdate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("CurrntBalance")
                        .HasColumnType("integer");

                    b.Property<DateTime>("Dateadded")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("ID");

                    b.ToTable("Account");
                });

            modelBuilder.Entity("aptmgt.entity.Accounts.Expense", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("Amount")
                        .HasColumnType("integer");

                    b.Property<string>("Commid")
                        .HasColumnType("text");

                    b.Property<DateTime>("Currdate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("ExpenseType")
                        .HasColumnType("text");

                    b.Property<int>("TranID")
                        .HasColumnType("integer");

                    b.HasKey("ID");

                    b.ToTable("Expense");
                });

            modelBuilder.Entity("aptmgt.entity.Accounts.MonthlyMaint", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Commid")
                        .HasColumnType("text");

                    b.Property<DateTime>("Currdate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("Fltno")
                        .HasColumnType("text");

                    b.Property<int>("Mobno")
                        .HasColumnType("integer");

                    b.Property<string>("OwnerName")
                        .HasColumnType("text");

                    b.Property<int>("TranID")
                        .HasColumnType("integer");

                    b.HasKey("ID");

                    b.ToTable("MonthlyMaint");
                });

            modelBuilder.Entity("aptmgt.entity.Accounts.SourceOthers", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Commid")
                        .HasColumnType("text");

                    b.Property<DateTime>("Currdate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("SourceName")
                        .HasColumnType("text");

                    b.Property<int>("TranID")
                        .HasColumnType("integer");

                    b.HasKey("ID");

                    b.ToTable("SourceOthers");
                });

            modelBuilder.Entity("aptmgt.entity.Accounts.TransactionMaster", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("AccountId")
                        .HasColumnType("integer");

                    b.Property<int>("Amount")
                        .HasColumnType("integer");

                    b.Property<string>("Commid")
                        .HasColumnType("text");

                    b.Property<DateTime>("Currdate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("TranID")
                        .HasColumnType("integer");

                    b.Property<string>("TranType")
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.ToTable("TransactionMaster");
                });

            modelBuilder.Entity("aptmgt.entity.Accounts.maintMaster", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Commid")
                        .HasColumnType("text");

                    b.Property<string>("Fltno")
                        .HasColumnType("text");

                    b.Property<int>("MaintAmount")
                        .HasColumnType("integer");

                    b.HasKey("ID");

                    b.ToTable("maintMaster");
                });

            modelBuilder.Entity("aptmgt.entity.assets.AssetDetails", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("AssetId")
                        .HasColumnType("integer");

                    b.Property<string>("Asset_NR")
                        .HasColumnType("text");

                    b.Property<string>("Asset_Type")
                        .HasColumnType("text");

                    b.Property<string>("Asset_category")
                        .HasColumnType("text");

                    b.Property<DateTime>("Asset_last_servce")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Asset_name")
                        .HasColumnType("text");

                    b.Property<DateTime>("Asset_procure_Date")
                        .HasColumnType("timestamp without time zone");

                    b.Property<byte[]>("Asset_qr_img")
                        .HasColumnType("bytea");

                    b.Property<string>("Asset_service_Freq")
                        .HasColumnType("text");

                    b.Property<string>("Asset_service_flag")
                        .HasColumnType("text");

                    b.Property<string>("Commid")
                        .HasColumnType("text");

                    b.Property<DateTime>("Currdate")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("ID");

                    b.ToTable("AssetDetails");
                });

            modelBuilder.Entity("aptmgt.entity.assets.AssetRequest", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Asset_Name")
                        .HasColumnType("text");

                    b.Property<string>("Asset_Purpose")
                        .HasColumnType("text");

                    b.Property<string>("Asset_cost")
                        .HasColumnType("text");

                    b.Property<string>("Ast_added")
                        .HasColumnType("text");

                    b.Property<string>("Commid")
                        .HasColumnType("text");

                    b.Property<DateTime>("Currdate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Procure_approval")
                        .HasColumnType("text");

                    b.Property<string>("Procurestatus")
                        .HasColumnType("text");

                    b.Property<DateTime>("RequestDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("RequestID")
                        .HasColumnType("text");

                    b.Property<string>("Requeststatus")
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.ToTable("AssetRequest");
                });

            modelBuilder.Entity("aptmgt.entity.assets.ServiceDetails", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("AssetId")
                        .HasColumnType("integer");

                    b.Property<string>("Asset_NR")
                        .HasColumnType("text");

                    b.Property<string>("Asset_Name")
                        .HasColumnType("text");

                    b.Property<DateTime>("Asset_last_servce")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("Asset_next_service")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Asset_service_Freq")
                        .HasColumnType("text");

                    b.Property<DateTime>("Asset_service_date")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Asset_service_flag")
                        .HasColumnType("text");

                    b.Property<string>("Commid")
                        .HasColumnType("text");

                    b.Property<DateTime>("Currdate")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("ID");

                    b.ToTable("ServiceDetails");
                });

            modelBuilder.Entity("aptmgt.entity.assets.ServiceHistory", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("AssetId")
                        .HasColumnType("integer");

                    b.Property<string>("Asset_NR")
                        .HasColumnType("text");

                    b.Property<string>("Asset_Name")
                        .HasColumnType("text");

                    b.Property<DateTime>("Asset_last_servce")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Asset_service_Freq")
                        .HasColumnType("text");

                    b.Property<DateTime>("Asset_service_date")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Asset_service_flag")
                        .HasColumnType("text");

                    b.Property<string>("Commid")
                        .HasColumnType("text");

                    b.Property<DateTime>("Currdate")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("ID");

                    b.ToTable("ServiceHistory");
                });

            modelBuilder.Entity("aptmgt.entity.builder.Builder", b =>
                {
                    b.Property<string>("BuilderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text");

                    b.Property<string>("Address")
                        .HasColumnType("text");

                    b.Property<string>("City")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Pincode")
                        .HasColumnType("text");

                    b.Property<string>("State")
                        .HasColumnType("text");

                    b.HasKey("BuilderId");

                    b.ToTable("Builder");
                });

            modelBuilder.Entity("aptmgt.entity.community.CommunityBlock", b =>
                {
                    b.Property<string>("BlockID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text");

                    b.Property<string>("Blckname")
                        .HasColumnType("text");

                    b.Property<string>("CommunityID")
                        .HasColumnType("text");

                    b.Property<int>("NumberofFlats")
                        .HasColumnType("integer");

                    b.Property<int>("NumberofFloors")
                        .HasColumnType("integer");

                    b.HasKey("BlockID");

                    b.HasIndex("CommunityID");

                    b.ToTable("CommunityBlock");
                });

            modelBuilder.Entity("aptmgt.entity.community.CommunityDetails", b =>
                {
                    b.Property<string>("CommID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text");

                    b.Property<string>("Address")
                        .HasColumnType("text");

                    b.Property<string>("BuilderID")
                        .HasColumnType("text");

                    b.Property<string>("City")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int>("Pincode")
                        .HasColumnType("integer");

                    b.Property<string>("State")
                        .HasColumnType("text");

                    b.HasKey("CommID");

                    b.HasIndex("BuilderID");

                    b.ToTable("CommunityDetails");
                });

            modelBuilder.Entity("aptmgt.entity.community.CommunityFlats", b =>
                {
                    b.Property<string>("FlatID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text");

                    b.Property<string>("BlockID")
                        .HasColumnType("text");

                    b.Property<string>("FlatNumber")
                        .HasColumnType("text");

                    b.Property<int>("FloorNumber")
                        .HasColumnType("integer");

                    b.Property<int>("OwnerID")
                        .HasColumnType("integer");

                    b.HasKey("FlatID");

                    b.HasIndex("BlockID");

                    b.HasIndex("OwnerID");

                    b.ToTable("CommunityFlats");
                });

            modelBuilder.Entity("aptmgt.entity.facility.FacilityBooking", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Booking_ID")
                        .HasColumnType("text");

                    b.Property<DateTime>("Booking_date")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Booking_description")
                        .HasColumnType("text");

                    b.Property<int>("Booking_duration")
                        .HasColumnType("integer");

                    b.Property<DateTime>("Booking_end_time")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Booking_facility")
                        .HasColumnType("text");

                    b.Property<DateTime>("Booking_start_time")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Booking_status")
                        .HasColumnType("text");

                    b.Property<string>("Commid")
                        .HasColumnType("text");

                    b.Property<DateTime>("Currdate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Owner_flatno")
                        .HasColumnType("text");

                    b.Property<string>("Owner_name")
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.ToTable("FacilityBooking");
                });

            modelBuilder.Entity("aptmgt.entity.facility.FacilityBookingHistory", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Booking_ID")
                        .HasColumnType("text");

                    b.Property<DateTime>("Booking_date")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Booking_description")
                        .HasColumnType("text");

                    b.Property<int>("Booking_duration")
                        .HasColumnType("integer");

                    b.Property<DateTime>("Booking_end_time")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Booking_facility")
                        .HasColumnType("text");

                    b.Property<DateTime>("Booking_start_time")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Booking_status")
                        .HasColumnType("text");

                    b.Property<string>("Commid")
                        .HasColumnType("text");

                    b.Property<DateTime>("Currdate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Owner_flatno")
                        .HasColumnType("text");

                    b.Property<string>("Owner_name")
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.ToTable("FacilityBookingHistory");
                });

            modelBuilder.Entity("aptmgt.entity.facility.FacilityMaster", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Bkable")
                        .HasColumnType("text");

                    b.Property<string>("CommId")
                        .HasColumnType("text");

                    b.Property<string>("Facility_name")
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.ToTable("FacilityMaster");
                });

            modelBuilder.Entity("aptmgt.entity.parking.ParkingAssignment", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Commid")
                        .HasColumnType("text");

                    b.Property<DateTime>("Currdate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Occupied")
                        .HasColumnType("text");

                    b.Property<string>("Owner_email")
                        .HasColumnType("text");

                    b.Property<string>("Owner_flatno")
                        .HasColumnType("text");

                    b.Property<string>("Owner_fname")
                        .HasColumnType("text");

                    b.Property<string>("Owner_lname")
                        .HasColumnType("text");

                    b.Property<int>("Owner_phno")
                        .HasColumnType("integer");

                    b.Property<string>("Owner_slotno")
                        .HasColumnType("text");

                    b.Property<string>("Parking_ID")
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.ToTable("ParkingAssignment");
                });

            modelBuilder.Entity("aptmgt.entity.parking.ParkingAssignmentHistory", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Commid")
                        .HasColumnType("text");

                    b.Property<DateTime>("Currdate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Owner_email")
                        .HasColumnType("text");

                    b.Property<string>("Owner_flatno")
                        .HasColumnType("text");

                    b.Property<string>("Owner_fname")
                        .HasColumnType("text");

                    b.Property<string>("Owner_lname")
                        .HasColumnType("text");

                    b.Property<int>("Owner_phno")
                        .HasColumnType("integer");

                    b.Property<string>("Owner_slotno")
                        .HasColumnType("text");

                    b.Property<string>("Parking_ID")
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.ToTable("ParkingAssignmentHistory");
                });

            modelBuilder.Entity("aptmgt.entity.poll.poll", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Commid")
                        .HasColumnType("text");

                    b.Property<DateTime>("Currdate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("IsOpen")
                        .HasColumnType("text");

                    b.Property<DateTime>("PollEnd")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("PollID")
                        .HasColumnType("integer");

                    b.Property<string>("PollName")
                        .HasColumnType("text");

                    b.Property<DateTime>("PollStart")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("ID");

                    b.ToTable("poll");
                });

            modelBuilder.Entity("aptmgt.entity.poll.poll_question", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Commid")
                        .HasColumnType("text");

                    b.Property<DateTime>("Currdate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("PollID")
                        .HasColumnType("integer");

                    b.Property<string>("PollName")
                        .HasColumnType("text");

                    b.Property<string>("PollQuestion")
                        .HasColumnType("text");

                    b.Property<string>("QuestionID")
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.ToTable("poll_question");
                });

            modelBuilder.Entity("aptmgt.entity.poll.response", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Commid")
                        .HasColumnType("text");

                    b.Property<DateTime>("Currdate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("PollID")
                        .HasColumnType("integer");

                    b.Property<string>("PollName")
                        .HasColumnType("text");

                    b.Property<string>("PollResponse")
                        .HasColumnType("text");

                    b.Property<string>("QuestionID")
                        .HasColumnType("text");

                    b.Property<int>("ResponseID")
                        .HasColumnType("integer");

                    b.Property<string>("User")
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.ToTable("response");
                });

            modelBuilder.Entity("aptmgt.entity.user.AddOwner", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Blckname")
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("Fltno")
                        .HasColumnType("text");

                    b.Property<string>("Fname")
                        .HasColumnType("text");

                    b.Property<string>("Lname")
                        .HasColumnType("text");

                    b.Property<int>("Mobno")
                        .HasColumnType("integer");

                    b.Property<string>("Ocutype")
                        .HasColumnType("text");

                    b.Property<byte[]>("Ownrpic")
                        .HasColumnType("bytea");

                    b.Property<byte[]>("Ownrqr")
                        .HasColumnType("bytea");

                    b.HasKey("ID");

                    b.ToTable("AddOwner");
                });

            modelBuilder.Entity("aptmgt.entity.user.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("text");

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("text");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("boolean");

                    b.Property<string>("UserName")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("ApplicationUser");
                });

            modelBuilder.Entity("aptmgt.entity.user.CommunityUser", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("CommunityID")
                        .HasColumnType("text");

                    b.Property<string>("UserID")
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.ToTable("CommunityUser");
                });

            modelBuilder.Entity("aptmgt.entity.user.OwnerMaster", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Active")
                        .HasColumnType("text");

                    b.Property<string>("Blckname")
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("Fltno")
                        .HasColumnType("text");

                    b.Property<string>("Fname")
                        .HasColumnType("text");

                    b.Property<string>("Lname")
                        .HasColumnType("text");

                    b.Property<int>("Mobno")
                        .HasColumnType("integer");

                    b.Property<string>("Occupied")
                        .HasColumnType("text");

                    b.Property<DateTime>("Ownradddate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<byte[]>("Ownrpic")
                        .HasColumnType("bytea");

                    b.Property<byte[]>("Ownrqr")
                        .HasColumnType("bytea");

                    b.HasKey("ID");

                    b.ToTable("OwnerMaster");
                });

            modelBuilder.Entity("aptmgt.entity.user.Role", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("RoleID")
                        .HasColumnType("text");

                    b.Property<string>("Rolename")
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.ToTable("Role");
                });

            modelBuilder.Entity("aptmgt.entity.vehicles.VehicleDetails", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Commid")
                        .HasColumnType("text");

                    b.Property<DateTime>("Currdate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Owner_email")
                        .HasColumnType("text");

                    b.Property<string>("Owner_flatno")
                        .HasColumnType("text");

                    b.Property<string>("Owner_fname")
                        .HasColumnType("text");

                    b.Property<string>("Owner_lname")
                        .HasColumnType("text");

                    b.Property<int>("Owner_phno")
                        .HasColumnType("integer");

                    b.Property<string>("Owner_slotno")
                        .HasColumnType("text");

                    b.Property<byte[]>("Parking_qr_img")
                        .HasColumnType("bytea");

                    b.Property<string>("Vehicle_ID")
                        .HasColumnType("text");

                    b.Property<string>("Vehicle_no")
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.ToTable("VehicleDetails");
                });

            modelBuilder.Entity("aptmgt.entity.vehicles.VehicleDetailsHistory", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Commid")
                        .HasColumnType("text");

                    b.Property<DateTime>("Currdate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Owner_email")
                        .HasColumnType("text");

                    b.Property<string>("Owner_flatno")
                        .HasColumnType("text");

                    b.Property<string>("Owner_fname")
                        .HasColumnType("text");

                    b.Property<string>("Owner_lname")
                        .HasColumnType("text");

                    b.Property<int>("Owner_phno")
                        .HasColumnType("integer");

                    b.Property<string>("Owner_slotno")
                        .HasColumnType("text");

                    b.Property<string>("Vehicle_ID")
                        .HasColumnType("text");

                    b.Property<string>("Vehicle_no")
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.ToTable("VehicleDetailsHistory");
                });

            modelBuilder.Entity("aptmgt.entity.community.CommunityBlock", b =>
                {
                    b.HasOne("aptmgt.entity.community.CommunityDetails", "ParentCommunity")
                        .WithMany("Blocks")
                        .HasForeignKey("CommunityID");
                });

            modelBuilder.Entity("aptmgt.entity.community.CommunityDetails", b =>
                {
                    b.HasOne("aptmgt.entity.builder.Builder", "Builder")
                        .WithMany("Communities")
                        .HasForeignKey("BuilderID");
                });

            modelBuilder.Entity("aptmgt.entity.community.CommunityFlats", b =>
                {
                    b.HasOne("aptmgt.entity.community.CommunityBlock", "Block")
                        .WithMany("Flats")
                        .HasForeignKey("BlockID");

                    b.HasOne("aptmgt.entity.user.OwnerMaster", "owner")
                        .WithMany()
                        .HasForeignKey("OwnerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
