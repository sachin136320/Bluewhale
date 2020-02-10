﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using aptmgt.webui.Data;

namespace aptmgt.webui.Migrations
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

            modelBuilder.Entity("aptmgt.entity.builder.Builder", b =>
                {
                    b.Property<string>("BuilderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text");

                    b.Property<string>("Address")
                        .HasColumnType("text");

                    b.Property<string>("Ciy")
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

                    b.HasKey("FlatID");

                    b.HasIndex("BlockID");

                    b.ToTable("CommunityFlats");
                });

            modelBuilder.Entity("aptmgt.entity.facility.FacilityMaster", b =>
                {
                    b.Property<string>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text");

                    b.Property<string>("Bookable")
                        .HasColumnType("text");

                    b.Property<string>("CommunityID")
                        .HasColumnType("text");

                    b.Property<string>("FacilityName")
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.HasIndex("CommunityID");

                    b.ToTable("FacilityMaster");
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
                    b.Property<int>("ResidentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<bool>("Active")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("AddDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("BlockID")
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .HasColumnType("text");

                    b.Property<string>("FlatNumber")
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .HasColumnType("text");

                    b.Property<string>("MobileNumber")
                        .HasColumnType("text");

                    b.Property<bool>("Occupied")
                        .HasColumnType("boolean");

                    b.Property<byte[]>("Picture")
                        .HasColumnType("bytea");

                    b.Property<string>("QRText")
                        .HasColumnType("text");

                    b.Property<string>("notes")
                        .HasColumnType("text");

                    b.HasKey("ResidentID");

                    b.ToTable("OwnerMaster");
                });

            modelBuilder.Entity("aptmgt.entity.user.Role", b =>
                {
                    b.Property<string>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text");

                    b.Property<string>("Rolename")
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.ToTable("Role");
                });

            modelBuilder.Entity("aptmgt.entity.user.Tenants", b =>
                {
                    b.Property<int>("ResidentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<bool>("Active")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("AddDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<bool>("AgreementCopySubmitted")
                        .HasColumnType("boolean");

                    b.Property<string>("BlockID")
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .HasColumnType("text");

                    b.Property<string>("FlatNumber")
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .HasColumnType("text");

                    b.Property<string>("MobileNumber")
                        .HasColumnType("text");

                    b.Property<bool>("Occupied")
                        .HasColumnType("boolean");

                    b.Property<byte[]>("Picture")
                        .HasColumnType("bytea");

                    b.Property<string>("QRText")
                        .HasColumnType("text");

                    b.Property<string>("notes")
                        .HasColumnType("text");

                    b.HasKey("ResidentID");

                    b.ToTable("Tenants");
                });

            modelBuilder.Entity("aptmgt.entity.user.Vendor", b =>
                {
                    b.Property<string>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text");

                    b.Property<string>("Active")
                        .HasColumnType("text");

                    b.Property<DateTime>("AddDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .HasColumnType("text");

                    b.Property<string>("JobProfile")
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .HasColumnType("text");

                    b.Property<string>("MobileNumber")
                        .HasColumnType("text");

                    b.Property<byte[]>("Picture")
                        .HasColumnType("bytea");

                    b.Property<string>("QRText")
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.ToTable("Vendor");
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
                });

            modelBuilder.Entity("aptmgt.entity.facility.FacilityMaster", b =>
                {
                    b.HasOne("aptmgt.entity.community.CommunityDetails", "ParentCommunity")
                        .WithMany("facility")
                        .HasForeignKey("CommunityID");
                });
#pragma warning restore 612, 618
        }
    }
}
