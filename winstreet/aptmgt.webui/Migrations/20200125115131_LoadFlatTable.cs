using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace aptmgt.webui.Migrations
{
    public partial class LoadFlatTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CommunityFlats_OwnerMaster_OwnerID",
                schema: "AppData",
                table: "CommunityFlats");

            migrationBuilder.DropTable(
                name: "OwnerMaster",
                schema: "AppData");

            migrationBuilder.DropIndex(
                name: "IX_CommunityFlats_OwnerID",
                schema: "AppData",
                table: "CommunityFlats");

            migrationBuilder.DropColumn(
                name: "OwnerID",
                schema: "AppData",
                table: "CommunityFlats");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OwnerID",
                schema: "AppData",
                table: "CommunityFlats",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "OwnerMaster",
                schema: "AppData",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Active = table.Column<string>(type: "text", nullable: true),
                    Blckname = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    Fltno = table.Column<string>(type: "text", nullable: true),
                    Fname = table.Column<string>(type: "text", nullable: true),
                    Lname = table.Column<string>(type: "text", nullable: true),
                    Mobno = table.Column<int>(type: "integer", nullable: false),
                    Occupied = table.Column<string>(type: "text", nullable: true),
                    Ownradddate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Ownrpic = table.Column<byte[]>(type: "bytea", nullable: true),
                    Ownrqr = table.Column<byte[]>(type: "bytea", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OwnerMaster", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CommunityFlats_OwnerID",
                schema: "AppData",
                table: "CommunityFlats",
                column: "OwnerID");

            migrationBuilder.AddForeignKey(
                name: "FK_CommunityFlats_OwnerMaster_OwnerID",
                schema: "AppData",
                table: "CommunityFlats",
                column: "OwnerID",
                principalSchema: "AppData",
                principalTable: "OwnerMaster",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
