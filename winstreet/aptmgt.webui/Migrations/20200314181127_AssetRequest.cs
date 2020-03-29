using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace aptmgt.webui.Migrations
{
    public partial class AssetRequest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ServiceDoneDate",
                schema: "AppData",
                table: "ServiceHistory");

            migrationBuilder.DropColumn(
                name: "ServiceDoneDate",
                schema: "AppData",
                table: "ServiceDetails");

            migrationBuilder.DropColumn(
                name: "ServiceNotes",
                schema: "AppData",
                table: "ServiceDetails");

            migrationBuilder.DropColumn(
                name: "AssestStatus",
                schema: "AppData",
                table: "AssetDetails");

            migrationBuilder.DropColumn(
                name: "AssetApproveDate",
                schema: "AppData",
                table: "AssetDetails");

            migrationBuilder.DropColumn(
                name: "AssetCategory",
                schema: "AppData",
                table: "AssetDetails");

            migrationBuilder.DropColumn(
                name: "AssetName",
                schema: "AppData",
                table: "AssetDetails");

            migrationBuilder.DropColumn(
                name: "AssetProcureDate",
                schema: "AppData",
                table: "AssetDetails");

            migrationBuilder.DropColumn(
                name: "AssetRequireServiceFlag",
                schema: "AppData",
                table: "AssetDetails");

            migrationBuilder.DropColumn(
                name: "AssetType",
                schema: "AppData",
                table: "AssetDetails");

            migrationBuilder.DropColumn(
                name: "Cost",
                schema: "AppData",
                table: "AssetDetails");

            migrationBuilder.DropColumn(
                name: "Purpose",
                schema: "AppData",
                table: "AssetDetails");

            migrationBuilder.DropColumn(
                name: "RequestDate",
                schema: "AppData",
                table: "AssetDetails");

            migrationBuilder.DropColumn(
                name: "RequestStatus",
                schema: "AppData",
                table: "AssetDetails");

            migrationBuilder.AddColumn<DateTime>(
                name: "ServiceDate",
                schema: "AppData",
                table: "ServiceHistory",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "LastServiceDoneDate",
                schema: "AppData",
                table: "ServiceDetails",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "LastServiceNotes",
                schema: "AppData",
                table: "ServiceDetails",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "RequireServiceFlag",
                schema: "AppData",
                table: "ServiceDetails",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDateTime",
                schema: "AppData",
                table: "ServiceDetails",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ActualCost",
                schema: "AppData",
                table: "AssetDetails",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AssetRequestId",
                schema: "AppData",
                table: "AssetDetails",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Category",
                schema: "AppData",
                table: "AssetDetails",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                schema: "AppData",
                table: "AssetDetails",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                schema: "AppData",
                table: "AssetDetails",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Type",
                schema: "AppData",
                table: "AssetDetails",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AssetRequest",
                schema: "AppData",
                columns: table => new
                {
                    AssetRequestId = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Purpose = table.Column<string>(nullable: true),
                    EstimatedCost = table.Column<string>(nullable: true),
                    RequestDate = table.Column<string>(nullable: true),
                    RequestStatus = table.Column<string>(nullable: true),
                    ApprovalStatus = table.Column<string>(nullable: true),
                    ApproveDate = table.Column<DateTime>(nullable: false),
                    ProcurementStatus = table.Column<string>(nullable: true),
                    ProcureDate = table.Column<DateTime>(nullable: false),
                    Notes = table.Column<string>(nullable: true),
                    InsertDateTime = table.Column<DateTime>(nullable: false),
                    CommunityId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetRequest", x => x.AssetRequestId);
                    table.ForeignKey(
                        name: "FK_AssetRequest_CommunityDetails_CommunityId",
                        column: x => x.CommunityId,
                        principalSchema: "AppData",
                        principalTable: "CommunityDetails",
                        principalColumn: "CommunityId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AssetDetails_AssetRequestId",
                schema: "AppData",
                table: "AssetDetails",
                column: "AssetRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetRequest_CommunityId",
                schema: "AppData",
                table: "AssetRequest",
                column: "CommunityId");

            migrationBuilder.AddForeignKey(
                name: "FK_AssetDetails_AssetRequest_AssetRequestId",
                schema: "AppData",
                table: "AssetDetails",
                column: "AssetRequestId",
                principalSchema: "AppData",
                principalTable: "AssetRequest",
                principalColumn: "AssetRequestId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AssetDetails_AssetRequest_AssetRequestId",
                schema: "AppData",
                table: "AssetDetails");

            migrationBuilder.DropTable(
                name: "AssetRequest",
                schema: "AppData");

            migrationBuilder.DropIndex(
                name: "IX_AssetDetails_AssetRequestId",
                schema: "AppData",
                table: "AssetDetails");

            migrationBuilder.DropColumn(
                name: "ServiceDate",
                schema: "AppData",
                table: "ServiceHistory");

            migrationBuilder.DropColumn(
                name: "LastServiceDoneDate",
                schema: "AppData",
                table: "ServiceDetails");

            migrationBuilder.DropColumn(
                name: "LastServiceNotes",
                schema: "AppData",
                table: "ServiceDetails");

            migrationBuilder.DropColumn(
                name: "RequireServiceFlag",
                schema: "AppData",
                table: "ServiceDetails");

            migrationBuilder.DropColumn(
                name: "UpdateDateTime",
                schema: "AppData",
                table: "ServiceDetails");

            migrationBuilder.DropColumn(
                name: "ActualCost",
                schema: "AppData",
                table: "AssetDetails");

            migrationBuilder.DropColumn(
                name: "AssetRequestId",
                schema: "AppData",
                table: "AssetDetails");

            migrationBuilder.DropColumn(
                name: "Category",
                schema: "AppData",
                table: "AssetDetails");

            migrationBuilder.DropColumn(
                name: "Description",
                schema: "AppData",
                table: "AssetDetails");

            migrationBuilder.DropColumn(
                name: "Name",
                schema: "AppData",
                table: "AssetDetails");

            migrationBuilder.DropColumn(
                name: "Type",
                schema: "AppData",
                table: "AssetDetails");

            migrationBuilder.AddColumn<DateTime>(
                name: "ServiceDoneDate",
                schema: "AppData",
                table: "ServiceHistory",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ServiceDoneDate",
                schema: "AppData",
                table: "ServiceDetails",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ServiceNotes",
                schema: "AppData",
                table: "ServiceDetails",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AssestStatus",
                schema: "AppData",
                table: "AssetDetails",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "AssetApproveDate",
                schema: "AppData",
                table: "AssetDetails",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "AssetCategory",
                schema: "AppData",
                table: "AssetDetails",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AssetName",
                schema: "AppData",
                table: "AssetDetails",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "AssetProcureDate",
                schema: "AppData",
                table: "AssetDetails",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "AssetRequireServiceFlag",
                schema: "AppData",
                table: "AssetDetails",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "AssetType",
                schema: "AppData",
                table: "AssetDetails",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Cost",
                schema: "AppData",
                table: "AssetDetails",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Purpose",
                schema: "AppData",
                table: "AssetDetails",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RequestDate",
                schema: "AppData",
                table: "AssetDetails",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RequestStatus",
                schema: "AppData",
                table: "AssetDetails",
                type: "text",
                nullable: true);
        }
    }
}
