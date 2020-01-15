using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace aptmgt.webui.Migrations.ApplicationDB
{
    public partial class CommunityDetails1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_AssetDeails",
                schema: "AppData",
                table: "AssetDeails");

            migrationBuilder.RenameTable(
                name: "AssetDeails",
                schema: "AppData",
                newName: "AssetDetails",
                newSchema: "AppData");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AssetDetails",
                schema: "AppData",
                table: "AssetDetails",
                column: "ID");

            migrationBuilder.CreateTable(
                name: "Builder",
                schema: "AppData",
                columns: table => new
                {
                    BuilderId = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Pincode = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    Ciy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Builder", x => x.BuilderId);
                });

            migrationBuilder.CreateTable(
                name: "OwnerMaster",
                schema: "AppData",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Fname = table.Column<string>(nullable: true),
                    Lname = table.Column<string>(nullable: true),
                    Blckname = table.Column<string>(nullable: true),
                    Fltno = table.Column<string>(nullable: true),
                    Occupied = table.Column<string>(nullable: true),
                    Mobno = table.Column<int>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    Ownrpic = table.Column<byte[]>(nullable: true),
                    Ownrqr = table.Column<byte[]>(nullable: true),
                    Ownradddate = table.Column<DateTime>(nullable: false),
                    Active = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OwnerMaster", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CommunityDetails",
                schema: "AppData",
                columns: table => new
                {
                    CommID = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    Pincode = table.Column<int>(nullable: false),
                    BuilderID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommunityDetails", x => x.CommID);
                    table.ForeignKey(
                        name: "FK_CommunityDetails_Builder_BuilderID",
                        column: x => x.BuilderID,
                        principalSchema: "AppData",
                        principalTable: "Builder",
                        principalColumn: "BuilderId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CommunityBlock",
                schema: "AppData",
                columns: table => new
                {
                    BlockID = table.Column<string>(nullable: false),
                    Blckname = table.Column<string>(nullable: true),
                    NumberofFloors = table.Column<int>(nullable: false),
                    NumberofFlats = table.Column<int>(nullable: false),
                    CommunityID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommunityBlock", x => x.BlockID);
                    table.ForeignKey(
                        name: "FK_CommunityBlock_CommunityDetails_CommunityID",
                        column: x => x.CommunityID,
                        principalSchema: "AppData",
                        principalTable: "CommunityDetails",
                        principalColumn: "CommID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CommunityFlats",
                schema: "AppData",
                columns: table => new
                {
                    FlatID = table.Column<string>(nullable: false),
                    FlatNumber = table.Column<string>(nullable: true),
                    FloorNumber = table.Column<int>(nullable: false),
                    OwnerID = table.Column<int>(nullable: false),
                    BlockID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommunityFlats", x => x.FlatID);
                    table.ForeignKey(
                        name: "FK_CommunityFlats_CommunityBlock_BlockID",
                        column: x => x.BlockID,
                        principalSchema: "AppData",
                        principalTable: "CommunityBlock",
                        principalColumn: "BlockID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CommunityFlats_OwnerMaster_OwnerID",
                        column: x => x.OwnerID,
                        principalSchema: "AppData",
                        principalTable: "OwnerMaster",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CommunityBlock_CommunityID",
                schema: "AppData",
                table: "CommunityBlock",
                column: "CommunityID");

            migrationBuilder.CreateIndex(
                name: "IX_CommunityDetails_BuilderID",
                schema: "AppData",
                table: "CommunityDetails",
                column: "BuilderID");

            migrationBuilder.CreateIndex(
                name: "IX_CommunityFlats_BlockID",
                schema: "AppData",
                table: "CommunityFlats",
                column: "BlockID");

            migrationBuilder.CreateIndex(
                name: "IX_CommunityFlats_OwnerID",
                schema: "AppData",
                table: "CommunityFlats",
                column: "OwnerID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CommunityFlats",
                schema: "AppData");

            migrationBuilder.DropTable(
                name: "CommunityBlock",
                schema: "AppData");

            migrationBuilder.DropTable(
                name: "OwnerMaster",
                schema: "AppData");

            migrationBuilder.DropTable(
                name: "CommunityDetails",
                schema: "AppData");

            migrationBuilder.DropTable(
                name: "Builder",
                schema: "AppData");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AssetDetails",
                schema: "AppData",
                table: "AssetDetails");

            migrationBuilder.RenameTable(
                name: "AssetDetails",
                schema: "AppData",
                newName: "AssetDeails",
                newSchema: "AppData");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AssetDeails",
                schema: "AppData",
                table: "AssetDeails",
                column: "ID");
        }
    }
}
