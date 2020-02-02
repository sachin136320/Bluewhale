using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace aptmgt.webui.Migrations
{
    public partial class CommunityUsers1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OwnerMaster",
                schema: "AppData",
                columns: table => new
                {
                    ResidentID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    BlockID = table.Column<string>(nullable: true),
                    FlatNumber = table.Column<string>(nullable: true),
                    Occupied = table.Column<bool>(nullable: false),
                    MobileNumber = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Picture = table.Column<byte[]>(nullable: true),
                    QRText = table.Column<string>(nullable: true),
                    AddDate = table.Column<DateTime>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    notes = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OwnerMaster", x => x.ResidentID);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                schema: "AppData",
                columns: table => new
                {
                    ID = table.Column<string>(nullable: false),
                    Rolename = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Tenants",
                schema: "AppData",
                columns: table => new
                {
                    ResidentID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    BlockID = table.Column<string>(nullable: true),
                    FlatNumber = table.Column<string>(nullable: true),
                    Occupied = table.Column<bool>(nullable: false),
                    MobileNumber = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Picture = table.Column<byte[]>(nullable: true),
                    QRText = table.Column<string>(nullable: true),
                    AddDate = table.Column<DateTime>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    notes = table.Column<string>(nullable: true),
                    AgreementCopySubmitted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tenants", x => x.ResidentID);
                });

            migrationBuilder.CreateTable(
                name: "Vendor",
                schema: "AppData",
                columns: table => new
                {
                    ID = table.Column<string>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    MobileNumber = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Picture = table.Column<byte[]>(nullable: true),
                    QRText = table.Column<string>(nullable: true),
                    AddDate = table.Column<DateTime>(nullable: false),
                    Active = table.Column<string>(nullable: true),
                    JobProfile = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendor", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OwnerMaster",
                schema: "AppData");

            migrationBuilder.DropTable(
                name: "Role",
                schema: "AppData");

            migrationBuilder.DropTable(
                name: "Tenants",
                schema: "AppData");

            migrationBuilder.DropTable(
                name: "Vendor",
                schema: "AppData");
        }
    }
}
