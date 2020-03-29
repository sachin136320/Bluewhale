using Microsoft.EntityFrameworkCore.Migrations;

namespace aptmgt.webui.Migrations
{
    public partial class assetrequestcostupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ActualCost",
                schema: "AppData",
                table: "AssetRequest",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ActualCost",
                schema: "AppData",
                table: "AssetRequest");
        }
    }
}
