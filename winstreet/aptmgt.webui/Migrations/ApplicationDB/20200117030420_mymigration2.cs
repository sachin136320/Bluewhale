using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace aptmgt.webui.Migrations.ApplicationDB
{
    public partial class mymigration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ciy",
                schema: "AppData",
                table: "Builder");

            migrationBuilder.AddColumn<string>(
                name: "City",
                schema: "AppData",
                table: "Builder",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AddOwner",
                schema: "AppData",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Fname = table.Column<string>(nullable: true),
                    Lname = table.Column<string>(nullable: true),
                    Blckname = table.Column<string>(nullable: true),
                    Fltno = table.Column<string>(nullable: true),
                    Mobno = table.Column<int>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    Ownrpic = table.Column<byte[]>(nullable: true),
                    Ownrqr = table.Column<byte[]>(nullable: true),
                    Ocutype = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddOwner", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ApplicationUser",
                schema: "AppData",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(nullable: true),
                    NormalizedUserName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    NormalizedEmail = table.Column<string>(nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUser", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AssetRequest",
                schema: "AppData",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Asset_Name = table.Column<string>(nullable: true),
                    Asset_Purpose = table.Column<string>(nullable: true),
                    Asset_cost = table.Column<string>(nullable: true),
                    RequestDate = table.Column<DateTime>(nullable: false),
                    RequestID = table.Column<string>(nullable: true),
                    Requeststatus = table.Column<string>(nullable: true),
                    Procurestatus = table.Column<string>(nullable: true),
                    Procure_approval = table.Column<string>(nullable: true),
                    Ast_added = table.Column<string>(nullable: true),
                    Commid = table.Column<string>(nullable: true),
                    Currdate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetRequest", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "FacilityBooking",
                schema: "AppData",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Commid = table.Column<string>(nullable: true),
                    Currdate = table.Column<DateTime>(nullable: false),
                    Booking_ID = table.Column<string>(nullable: true),
                    Booking_date = table.Column<DateTime>(nullable: false),
                    Booking_start_time = table.Column<DateTime>(nullable: false),
                    Booking_end_time = table.Column<DateTime>(nullable: false),
                    Owner_flatno = table.Column<string>(nullable: true),
                    Owner_name = table.Column<string>(nullable: true),
                    Booking_facility = table.Column<string>(nullable: true),
                    Booking_duration = table.Column<int>(nullable: false),
                    Booking_description = table.Column<string>(nullable: true),
                    Booking_status = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FacilityBooking", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "FacilityBookingHistory",
                schema: "AppData",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Commid = table.Column<string>(nullable: true),
                    Currdate = table.Column<DateTime>(nullable: false),
                    Booking_ID = table.Column<string>(nullable: true),
                    Booking_date = table.Column<DateTime>(nullable: false),
                    Booking_start_time = table.Column<DateTime>(nullable: false),
                    Booking_end_time = table.Column<DateTime>(nullable: false),
                    Owner_flatno = table.Column<string>(nullable: true),
                    Owner_name = table.Column<string>(nullable: true),
                    Booking_facility = table.Column<string>(nullable: true),
                    Booking_duration = table.Column<int>(nullable: false),
                    Booking_description = table.Column<string>(nullable: true),
                    Booking_status = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FacilityBookingHistory", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "FacilityMaster",
                schema: "AppData",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CommId = table.Column<string>(nullable: true),
                    Bkable = table.Column<string>(nullable: true),
                    Facility_name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FacilityMaster", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ParkingAssignment",
                schema: "AppData",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Commid = table.Column<string>(nullable: true),
                    Currdate = table.Column<DateTime>(nullable: false),
                    Parking_ID = table.Column<string>(nullable: true),
                    Owner_fname = table.Column<string>(nullable: true),
                    Owner_lname = table.Column<string>(nullable: true),
                    Owner_flatno = table.Column<string>(nullable: true),
                    Owner_phno = table.Column<int>(nullable: false),
                    Owner_email = table.Column<string>(nullable: true),
                    Owner_slotno = table.Column<string>(nullable: true),
                    Occupied = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParkingAssignment", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ParkingAssignmentHistory",
                schema: "AppData",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Commid = table.Column<string>(nullable: true),
                    Currdate = table.Column<DateTime>(nullable: false),
                    Parking_ID = table.Column<string>(nullable: true),
                    Owner_fname = table.Column<string>(nullable: true),
                    Owner_lname = table.Column<string>(nullable: true),
                    Owner_flatno = table.Column<string>(nullable: true),
                    Owner_phno = table.Column<int>(nullable: false),
                    Owner_email = table.Column<string>(nullable: true),
                    Owner_slotno = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParkingAssignmentHistory", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                schema: "AppData",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleID = table.Column<string>(nullable: true),
                    Rolename = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ServiceDetails",
                schema: "AppData",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Commid = table.Column<string>(nullable: true),
                    Currdate = table.Column<DateTime>(nullable: false),
                    AssetId = table.Column<int>(nullable: false),
                    Asset_NR = table.Column<string>(nullable: true),
                    Asset_Name = table.Column<string>(nullable: true),
                    Asset_service_Freq = table.Column<string>(nullable: true),
                    Asset_last_servce = table.Column<DateTime>(nullable: false),
                    Asset_service_flag = table.Column<string>(nullable: true),
                    Asset_next_service = table.Column<DateTime>(nullable: false),
                    Asset_service_date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceDetails", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ServiceHistory",
                schema: "AppData",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Commid = table.Column<string>(nullable: true),
                    Currdate = table.Column<DateTime>(nullable: false),
                    AssetId = table.Column<int>(nullable: false),
                    Asset_NR = table.Column<string>(nullable: true),
                    Asset_Name = table.Column<string>(nullable: true),
                    Asset_service_Freq = table.Column<string>(nullable: true),
                    Asset_last_servce = table.Column<DateTime>(nullable: false),
                    Asset_service_flag = table.Column<string>(nullable: true),
                    Asset_service_date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceHistory", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "VehicleDetails",
                schema: "AppData",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Commid = table.Column<string>(nullable: true),
                    Currdate = table.Column<DateTime>(nullable: false),
                    Vehicle_ID = table.Column<string>(nullable: true),
                    Owner_fname = table.Column<string>(nullable: true),
                    Owner_lname = table.Column<string>(nullable: true),
                    Owner_flatno = table.Column<string>(nullable: true),
                    Owner_phno = table.Column<int>(nullable: false),
                    Owner_email = table.Column<string>(nullable: true),
                    Owner_slotno = table.Column<string>(nullable: true),
                    Vehicle_no = table.Column<string>(nullable: true),
                    Parking_qr_img = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleDetails", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "VehicleDetailsHistory",
                schema: "AppData",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Commid = table.Column<string>(nullable: true),
                    Currdate = table.Column<DateTime>(nullable: false),
                    Vehicle_ID = table.Column<string>(nullable: true),
                    Owner_fname = table.Column<string>(nullable: true),
                    Owner_lname = table.Column<string>(nullable: true),
                    Owner_flatno = table.Column<string>(nullable: true),
                    Owner_phno = table.Column<int>(nullable: false),
                    Owner_email = table.Column<string>(nullable: true),
                    Owner_slotno = table.Column<string>(nullable: true),
                    Vehicle_no = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleDetailsHistory", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AddOwner",
                schema: "AppData");

            migrationBuilder.DropTable(
                name: "ApplicationUser",
                schema: "AppData");

            migrationBuilder.DropTable(
                name: "AssetRequest",
                schema: "AppData");

            migrationBuilder.DropTable(
                name: "FacilityBooking",
                schema: "AppData");

            migrationBuilder.DropTable(
                name: "FacilityBookingHistory",
                schema: "AppData");

            migrationBuilder.DropTable(
                name: "FacilityMaster",
                schema: "AppData");

            migrationBuilder.DropTable(
                name: "ParkingAssignment",
                schema: "AppData");

            migrationBuilder.DropTable(
                name: "ParkingAssignmentHistory",
                schema: "AppData");

            migrationBuilder.DropTable(
                name: "Role",
                schema: "AppData");

            migrationBuilder.DropTable(
                name: "ServiceDetails",
                schema: "AppData");

            migrationBuilder.DropTable(
                name: "ServiceHistory",
                schema: "AppData");

            migrationBuilder.DropTable(
                name: "VehicleDetails",
                schema: "AppData");

            migrationBuilder.DropTable(
                name: "VehicleDetailsHistory",
                schema: "AppData");

            migrationBuilder.DropColumn(
                name: "City",
                schema: "AppData",
                table: "Builder");

            migrationBuilder.AddColumn<string>(
                name: "Ciy",
                schema: "AppData",
                table: "Builder",
                type: "text",
                nullable: true);
        }
    }
}
