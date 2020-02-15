﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using aptmgt.webui.Data;

namespace aptmgt.webui.Migrations.ApplicationDB
{
    [DbContext(typeof(ApplicationDBContext))]
    [Migration("20200115150344_MyFirstMigration3")]
    partial class MyFirstMigration3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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

                    b.ToTable("AssetDeails");
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
#pragma warning restore 612, 618
        }
    }
}
