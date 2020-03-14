using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace aptmgt.webui.Migrations
{
    public partial class MajorUpdates1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "AppData");

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
                name: "Builder",
                schema: "AppData",
                columns: table => new
                {
                    BuilderId = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Pincode = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Builder", x => x.BuilderId);
                });

            migrationBuilder.CreateTable(
                name: "CommunityUser",
                schema: "AppData",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserID = table.Column<string>(nullable: true),
                    CommunityID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommunityUser", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                schema: "AppData",
                columns: table => new
                {
                    RoleID = table.Column<string>(nullable: false),
                    Rolename = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.RoleID);
                });

            migrationBuilder.CreateTable(
                name: "CommunityDetails",
                schema: "AppData",
                columns: table => new
                {
                    CommunityId = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    Pincode = table.Column<string>(nullable: true),
                    BuilderID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommunityDetails", x => x.CommunityId);
                    table.ForeignKey(
                        name: "FK_CommunityDetails_Builder_BuilderID",
                        column: x => x.BuilderID,
                        principalSchema: "AppData",
                        principalTable: "Builder",
                        principalColumn: "BuilderId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AssetDetails",
                schema: "AppData",
                columns: table => new
                {
                    AssetId = table.Column<string>(nullable: false),
                    AssetName = table.Column<string>(nullable: true),
                    Purpose = table.Column<string>(nullable: true),
                    Cost = table.Column<string>(nullable: true),
                    RequestDate = table.Column<string>(nullable: true),
                    RequestStatus = table.Column<string>(nullable: true),
                    AssestStatus = table.Column<string>(nullable: true),
                    AssetType = table.Column<string>(nullable: true),
                    AssetCategory = table.Column<string>(nullable: true),
                    AssetProcureDate = table.Column<DateTime>(nullable: false),
                    AssetApproveDate = table.Column<DateTime>(nullable: false),
                    Notes = table.Column<string>(nullable: true),
                    AssetRequireServiceFlag = table.Column<bool>(nullable: false),
                    InsertDateTime = table.Column<DateTime>(nullable: false),
                    CommunityId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetDetails", x => x.AssetId);
                    table.ForeignKey(
                        name: "FK_AssetDetails_CommunityDetails_CommunityId",
                        column: x => x.CommunityId,
                        principalSchema: "AppData",
                        principalTable: "CommunityDetails",
                        principalColumn: "CommunityId",
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
                        principalColumn: "CommunityId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FacilityBooking",
                schema: "AppData",
                columns: table => new
                {
                    FacilityBookingID = table.Column<string>(nullable: false),
                    CommunityId = table.Column<string>(nullable: true),
                    Currdate = table.Column<DateTime>(nullable: false),
                    Booking_ID = table.Column<string>(nullable: true),
                    Booking_date = table.Column<DateTime>(nullable: false),
                    Booking_start_time = table.Column<DateTime>(nullable: false),
                    Booking_end_time = table.Column<DateTime>(nullable: false),
                    Owner_flatno = table.Column<string>(nullable: true),
                    Owner_name = table.Column<string>(nullable: true),
                    Booking_facility = table.Column<string>(nullable: true),
                    Booking_duration = table.Column<string>(nullable: true),
                    Booking_description = table.Column<string>(nullable: true),
                    Booking_status = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FacilityBooking", x => x.FacilityBookingID);
                    table.ForeignKey(
                        name: "FK_FacilityBooking_CommunityDetails_CommunityId",
                        column: x => x.CommunityId,
                        principalSchema: "AppData",
                        principalTable: "CommunityDetails",
                        principalColumn: "CommunityId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FacilityBookingHistory",
                schema: "AppData",
                columns: table => new
                {
                    FacilityBookingHistoryID = table.Column<string>(nullable: false),
                    CommunityId = table.Column<string>(nullable: true),
                    Currdate = table.Column<DateTime>(nullable: false),
                    Booking_ID = table.Column<string>(nullable: true),
                    Booking_date = table.Column<DateTime>(nullable: false),
                    Booking_start_time = table.Column<DateTime>(nullable: false),
                    Booking_end_time = table.Column<DateTime>(nullable: false),
                    Owner_flatno = table.Column<string>(nullable: true),
                    Owner_name = table.Column<string>(nullable: true),
                    Booking_facility = table.Column<string>(nullable: true),
                    Booking_duration = table.Column<string>(nullable: true),
                    Booking_description = table.Column<string>(nullable: true),
                    Booking_status = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FacilityBookingHistory", x => x.FacilityBookingHistoryID);
                    table.ForeignKey(
                        name: "FK_FacilityBookingHistory_CommunityDetails_CommunityId",
                        column: x => x.CommunityId,
                        principalSchema: "AppData",
                        principalTable: "CommunityDetails",
                        principalColumn: "CommunityId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FacilityMaster",
                schema: "AppData",
                columns: table => new
                {
                    FacilityMasterID = table.Column<string>(nullable: false),
                    Bookable = table.Column<string>(nullable: true),
                    FacilityName = table.Column<string>(nullable: true),
                    CommunityID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FacilityMaster", x => x.FacilityMasterID);
                    table.ForeignKey(
                        name: "FK_FacilityMaster_CommunityDetails_CommunityID",
                        column: x => x.CommunityID,
                        principalSchema: "AppData",
                        principalTable: "CommunityDetails",
                        principalColumn: "CommunityId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "VisitorDetails",
                schema: "AppData",
                columns: table => new
                {
                    VisitID = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    NumberOfVisitor = table.Column<string>(nullable: true),
                    CheckInDate = table.Column<string>(nullable: true),
                    CheckOutDate = table.Column<string>(nullable: true),
                    CommunityID = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    MobileNumber = table.Column<string>(nullable: true),
                    VisitorType = table.Column<string>(nullable: true),
                    Picture = table.Column<byte[]>(nullable: true),
                    ResidentID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VisitorDetails", x => x.VisitID);
                    table.ForeignKey(
                        name: "FK_VisitorDetails_CommunityDetails_CommunityID",
                        column: x => x.CommunityID,
                        principalSchema: "AppData",
                        principalTable: "CommunityDetails",
                        principalColumn: "CommunityId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ServiceDetails",
                schema: "AppData",
                columns: table => new
                {
                    ServiceDetailID = table.Column<string>(nullable: false),
                    ServiceFrequencyinDays = table.Column<string>(nullable: true),
                    NextServiceDate = table.Column<DateTime>(nullable: false),
                    ServiceDoneDate = table.Column<DateTime>(nullable: false),
                    ServiceNotes = table.Column<string>(nullable: true),
                    InsertDateTime = table.Column<DateTime>(nullable: false),
                    CommunityId = table.Column<string>(nullable: true),
                    AssetId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceDetails", x => x.ServiceDetailID);
                    table.ForeignKey(
                        name: "FK_ServiceDetails_AssetDetails_AssetId",
                        column: x => x.AssetId,
                        principalSchema: "AppData",
                        principalTable: "AssetDetails",
                        principalColumn: "AssetId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ServiceDetails_CommunityDetails_CommunityId",
                        column: x => x.CommunityId,
                        principalSchema: "AppData",
                        principalTable: "CommunityDetails",
                        principalColumn: "CommunityId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CommunityFlats",
                schema: "AppData",
                columns: table => new
                {
                    FlatID = table.Column<string>(nullable: false),
                    FlatNumber = table.Column<string>(nullable: true),
                    FloorNumber = table.Column<string>(nullable: true),
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
                });

            migrationBuilder.CreateTable(
                name: "ServiceHistory",
                schema: "AppData",
                columns: table => new
                {
                    ServiceHistoryID = table.Column<string>(nullable: false),
                    ServiceDoneDate = table.Column<DateTime>(nullable: false),
                    ServiceNotes = table.Column<string>(nullable: true),
                    InsertDateTime = table.Column<DateTime>(nullable: false),
                    CommunityId = table.Column<string>(nullable: true),
                    AssetId = table.Column<string>(nullable: true),
                    ServiceDetailID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceHistory", x => x.ServiceHistoryID);
                    table.ForeignKey(
                        name: "FK_ServiceHistory_AssetDetails_AssetId",
                        column: x => x.AssetId,
                        principalSchema: "AppData",
                        principalTable: "AssetDetails",
                        principalColumn: "AssetId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ServiceHistory_CommunityDetails_CommunityId",
                        column: x => x.CommunityId,
                        principalSchema: "AppData",
                        principalTable: "CommunityDetails",
                        principalColumn: "CommunityId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ServiceHistory_ServiceDetails_ServiceDetailID",
                        column: x => x.ServiceDetailID,
                        principalSchema: "AppData",
                        principalTable: "ServiceDetails",
                        principalColumn: "ServiceDetailID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OwnerMaster",
                schema: "AppData",
                columns: table => new
                {
                    ResidentID = table.Column<string>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    FlatNumber = table.Column<string>(nullable: true),
                    Occupied = table.Column<bool>(nullable: false),
                    MobileNumber = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    QRText = table.Column<string>(nullable: true),
                    Active = table.Column<bool>(nullable: false),
                    Notes = table.Column<string>(nullable: true),
                    OwnerType = table.Column<string>(nullable: true),
                    AgreementCopySubmitted = table.Column<bool>(nullable: false),
                    InsertDateTime = table.Column<DateTime>(nullable: false),
                    FlatID = table.Column<string>(nullable: true),
                    CommunityID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OwnerMaster", x => x.ResidentID);
                    table.ForeignKey(
                        name: "FK_OwnerMaster_CommunityDetails_CommunityID",
                        column: x => x.CommunityID,
                        principalSchema: "AppData",
                        principalTable: "CommunityDetails",
                        principalColumn: "CommunityId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OwnerMaster_CommunityFlats_FlatID",
                        column: x => x.FlatID,
                        principalSchema: "AppData",
                        principalTable: "CommunityFlats",
                        principalColumn: "FlatID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AssetDetails_CommunityId",
                schema: "AppData",
                table: "AssetDetails",
                column: "CommunityId");

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
                name: "IX_FacilityBooking_CommunityId",
                schema: "AppData",
                table: "FacilityBooking",
                column: "CommunityId");

            migrationBuilder.CreateIndex(
                name: "IX_FacilityBookingHistory_CommunityId",
                schema: "AppData",
                table: "FacilityBookingHistory",
                column: "CommunityId");

            migrationBuilder.CreateIndex(
                name: "IX_FacilityMaster_CommunityID",
                schema: "AppData",
                table: "FacilityMaster",
                column: "CommunityID");

            migrationBuilder.CreateIndex(
                name: "IX_OwnerMaster_CommunityID",
                schema: "AppData",
                table: "OwnerMaster",
                column: "CommunityID");

            migrationBuilder.CreateIndex(
                name: "IX_OwnerMaster_FlatID",
                schema: "AppData",
                table: "OwnerMaster",
                column: "FlatID");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceDetails_AssetId",
                schema: "AppData",
                table: "ServiceDetails",
                column: "AssetId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceDetails_CommunityId",
                schema: "AppData",
                table: "ServiceDetails",
                column: "CommunityId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceHistory_AssetId",
                schema: "AppData",
                table: "ServiceHistory",
                column: "AssetId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceHistory_CommunityId",
                schema: "AppData",
                table: "ServiceHistory",
                column: "CommunityId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceHistory_ServiceDetailID",
                schema: "AppData",
                table: "ServiceHistory",
                column: "ServiceDetailID");

            migrationBuilder.CreateIndex(
                name: "IX_VisitorDetails_CommunityID",
                schema: "AppData",
                table: "VisitorDetails",
                column: "CommunityID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicationUser",
                schema: "AppData");

            migrationBuilder.DropTable(
                name: "CommunityUser",
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
                name: "OwnerMaster",
                schema: "AppData");

            migrationBuilder.DropTable(
                name: "Role",
                schema: "AppData");

            migrationBuilder.DropTable(
                name: "ServiceHistory",
                schema: "AppData");

            migrationBuilder.DropTable(
                name: "VisitorDetails",
                schema: "AppData");

            migrationBuilder.DropTable(
                name: "CommunityFlats",
                schema: "AppData");

            migrationBuilder.DropTable(
                name: "ServiceDetails",
                schema: "AppData");

            migrationBuilder.DropTable(
                name: "CommunityBlock",
                schema: "AppData");

            migrationBuilder.DropTable(
                name: "AssetDetails",
                schema: "AppData");

            migrationBuilder.DropTable(
                name: "CommunityDetails",
                schema: "AppData");

            migrationBuilder.DropTable(
                name: "Builder",
                schema: "AppData");
        }
    }
}
