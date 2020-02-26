using Microsoft.EntityFrameworkCore.Migrations;

namespace aptmgt.webui.Migrations
{
    public partial class CheckOutDateVisitorDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CheckOutDate",
                schema: "AppData",
                table: "VisitorDetails",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CheckOutDate",
                schema: "AppData",
                table: "VisitorDetails");
        }
    }
}
