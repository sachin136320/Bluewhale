using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace aptmgt.webui.Migrations.ApplicationDB
{
    public partial class deployment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                schema: "AppData",
                table: "AssetDeails");

            migrationBuilder.DropColumn(
                name: "Image",
                schema: "AppData",
                table: "AssetDeails");

            migrationBuilder.DropColumn(
                name: "LstService",
                schema: "AppData",
                table: "AssetDeails");

            migrationBuilder.DropColumn(
                name: "Name",
                schema: "AppData",
                table: "AssetDeails");

            migrationBuilder.DropColumn(
                name: "Nr",
                schema: "AppData",
                table: "AssetDeails");

            migrationBuilder.DropColumn(
                name: "ServiceFrequency",
                schema: "AppData",
                table: "AssetDeails");

            migrationBuilder.DropColumn(
                name: "Type",
                schema: "AppData",
                table: "AssetDeails");

            migrationBuilder.AddColumn<string>(
                name: "Asset_NR",
                schema: "AppData",
                table: "AssetDeails",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Asset_Type",
                schema: "AppData",
                table: "AssetDeails",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Asset_category",
                schema: "AppData",
                table: "AssetDeails",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Asset_last_servce",
                schema: "AppData",
                table: "AssetDeails",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Asset_name",
                schema: "AppData",
                table: "AssetDeails",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Asset_procure_Date",
                schema: "AppData",
                table: "AssetDeails",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<byte[]>(
                name: "Asset_qr_img",
                schema: "AppData",
                table: "AssetDeails",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Asset_service_Freq",
                schema: "AppData",
                table: "AssetDeails",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Asset_service_flag",
                schema: "AppData",
                table: "AssetDeails",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Commid",
                schema: "AppData",
                table: "AssetDeails",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Currdate",
                schema: "AppData",
                table: "AssetDeails",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Asset_NR",
                schema: "AppData",
                table: "AssetDeails");

            migrationBuilder.DropColumn(
                name: "Asset_Type",
                schema: "AppData",
                table: "AssetDeails");

            migrationBuilder.DropColumn(
                name: "Asset_category",
                schema: "AppData",
                table: "AssetDeails");

            migrationBuilder.DropColumn(
                name: "Asset_last_servce",
                schema: "AppData",
                table: "AssetDeails");

            migrationBuilder.DropColumn(
                name: "Asset_name",
                schema: "AppData",
                table: "AssetDeails");

            migrationBuilder.DropColumn(
                name: "Asset_procure_Date",
                schema: "AppData",
                table: "AssetDeails");

            migrationBuilder.DropColumn(
                name: "Asset_qr_img",
                schema: "AppData",
                table: "AssetDeails");

            migrationBuilder.DropColumn(
                name: "Asset_service_Freq",
                schema: "AppData",
                table: "AssetDeails");

            migrationBuilder.DropColumn(
                name: "Asset_service_flag",
                schema: "AppData",
                table: "AssetDeails");

            migrationBuilder.DropColumn(
                name: "Commid",
                schema: "AppData",
                table: "AssetDeails");

            migrationBuilder.DropColumn(
                name: "Currdate",
                schema: "AppData",
                table: "AssetDeails");

            migrationBuilder.AddColumn<string>(
                name: "Category",
                schema: "AppData",
                table: "AssetDeails",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Image",
                schema: "AppData",
                table: "AssetDeails",
                type: "bytea",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LstService",
                schema: "AppData",
                table: "AssetDeails",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Name",
                schema: "AppData",
                table: "AssetDeails",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nr",
                schema: "AppData",
                table: "AssetDeails",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ServiceFrequency",
                schema: "AppData",
                table: "AssetDeails",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Type",
                schema: "AppData",
                table: "AssetDeails",
                type: "text",
                nullable: true);
        }
    }
}
