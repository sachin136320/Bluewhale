using Microsoft.EntityFrameworkCore.Migrations;

namespace aptmgt.webui.Migrations
{
    public partial class updateresidenttable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CommID",
                schema: "AppData",
                table: "Tenants",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CommID",
                schema: "AppData",
                table: "OwnerMaster",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CommID",
                schema: "AppData",
                table: "Tenants");

            migrationBuilder.DropColumn(
                name: "CommID",
                schema: "AppData",
                table: "OwnerMaster");
        }
    }
}
