using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace aptmgt.webui.Migrations
{
    public partial class MajorUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "AppData");

            migrationBuilder.CreateTable(
                name: "Account",
                schema: "AppData",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AccountId = table.Column<int>(nullable: false),
                    Commid = table.Column<string>(nullable: true),
                    Currdate = table.Column<DateTime>(nullable: false),
                    AccountType = table.Column<string>(nullable: true),
                    Accountno = table.Column<int>(nullable: false),
                    Bankname = table.Column<string>(nullable: true),
                    CurrntBalance = table.Column<int>(nullable: false),
                    Dateadded = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account", x => x.ID);
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
                name: "Expense",
                schema: "AppData",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Commid = table.Column<string>(nullable: true),
                    Currdate = table.Column<DateTime>(nullable: false),
                    TranID = table.Column<int>(nullable: false),
                    Amount = table.Column<int>(nullable: false),
                    ExpenseType = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expense", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "maintMaster",
                schema: "AppData",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Commid = table.Column<string>(nullable: true),
                    Fltno = table.Column<string>(nullable: true),
                    MaintAmount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_maintMaster", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "MonthlyMaint",
                schema: "AppData",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Commid = table.Column<string>(nullable: true),
                    Currdate = table.Column<DateTime>(nullable: false),
                    TranID = table.Column<int>(nullable: false),
                    Fltno = table.Column<string>(nullable: true),
                    OwnerName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Mobno = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MonthlyMaint", x => x.ID);
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
                name: "SourceOthers",
                schema: "AppData",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Commid = table.Column<string>(nullable: true),
                    Currdate = table.Column<DateTime>(nullable: false),
                    TranID = table.Column<int>(nullable: false),
                    SourceName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SourceOthers", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TransactionMaster",
                schema: "AppData",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TranID = table.Column<int>(nullable: false),
                    Commid = table.Column<string>(nullable: true),
                    Currdate = table.Column<DateTime>(nullable: false),
                    AccountId = table.Column<int>(nullable: false),
                    Amount = table.Column<int>(nullable: false),
                    TranType = table.Column<string>(nullable: true),
                    Timestamp = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionMaster", x => x.ID);
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
                    CommunityId = table.Column<string>(nullable: true),
                    Currdate = table.Column<DateTime>(nullable: false),
                    Asset_NR = table.Column<string>(nullable: true),
                    Asset_name = table.Column<string>(nullable: true),
                    Asset_Type = table.Column<string>(nullable: true),
                    Asset_category = table.Column<string>(nullable: true),
                    Asset_service_Freq = table.Column<string>(nullable: true),
                    Asset_last_servce = table.Column<DateTime>(nullable: false),
                    Asset_service_flag = table.Column<string>(nullable: true),
                    Asset_procure_Date = table.Column<DateTime>(nullable: false)
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
                name: "AssetRequest",
                schema: "AppData",
                columns: table => new
                {
                    AssetRequestID = table.Column<string>(nullable: false),
                    Asset_Name = table.Column<string>(nullable: true),
                    Asset_Purpose = table.Column<string>(nullable: true),
                    Asset_cost = table.Column<string>(nullable: true),
                    RequestDate = table.Column<DateTime>(nullable: false),
                    Requeststatus = table.Column<string>(nullable: true),
                    Procurestatus = table.Column<string>(nullable: true),
                    Procure_approval = table.Column<string>(nullable: true),
                    Ast_added = table.Column<string>(nullable: true),
                    CommunityId = table.Column<string>(nullable: true),
                    InsertDateTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetRequest", x => x.AssetRequestID);
                    table.ForeignKey(
                        name: "FK_AssetRequest_CommunityDetails_CommunityId",
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
                name: "ParkingAssignment",
                schema: "AppData",
                columns: table => new
                {
                    ParkingAssignmentID = table.Column<string>(nullable: false),
                    CommunityID = table.Column<string>(nullable: true),
                    Currdate = table.Column<DateTime>(nullable: false),
                    Parking_ID = table.Column<string>(nullable: true),
                    Owner_fname = table.Column<string>(nullable: true),
                    Owner_lname = table.Column<string>(nullable: true),
                    Owner_flatno = table.Column<string>(nullable: true),
                    Owner_phno = table.Column<string>(nullable: true),
                    Owner_email = table.Column<string>(nullable: true),
                    Owner_slotno = table.Column<string>(nullable: true),
                    Occupied = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParkingAssignment", x => x.ParkingAssignmentID);
                    table.ForeignKey(
                        name: "FK_ParkingAssignment_CommunityDetails_CommunityID",
                        column: x => x.CommunityID,
                        principalSchema: "AppData",
                        principalTable: "CommunityDetails",
                        principalColumn: "CommunityId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ParkingAssignmentHistory",
                schema: "AppData",
                columns: table => new
                {
                    ParkingAssignmentHistoryID = table.Column<string>(nullable: false),
                    CommunityID = table.Column<string>(nullable: true),
                    Currdate = table.Column<DateTime>(nullable: false),
                    Parking_ID = table.Column<string>(nullable: true),
                    Owner_fname = table.Column<string>(nullable: true),
                    Owner_lname = table.Column<string>(nullable: true),
                    Owner_flatno = table.Column<string>(nullable: true),
                    Owner_phno = table.Column<string>(nullable: true),
                    Owner_email = table.Column<string>(nullable: true),
                    Owner_slotno = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParkingAssignmentHistory", x => x.ParkingAssignmentHistoryID);
                    table.ForeignKey(
                        name: "FK_ParkingAssignmentHistory_CommunityDetails_CommunityID",
                        column: x => x.CommunityID,
                        principalSchema: "AppData",
                        principalTable: "CommunityDetails",
                        principalColumn: "CommunityId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Poll",
                schema: "AppData",
                columns: table => new
                {
                    PollID = table.Column<string>(nullable: false),
                    CommunityID = table.Column<string>(nullable: true),
                    Currdate = table.Column<DateTime>(nullable: false),
                    PollName = table.Column<string>(nullable: true),
                    PollStart = table.Column<DateTime>(nullable: false),
                    PollEnd = table.Column<DateTime>(nullable: false),
                    IsOpen = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Poll", x => x.PollID);
                    table.ForeignKey(
                        name: "FK_Poll_CommunityDetails_CommunityID",
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
                    CommunityId = table.Column<string>(nullable: true),
                    InsertDateTime = table.Column<DateTime>(nullable: false),
                    AssetId = table.Column<string>(nullable: true),
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
                    table.PrimaryKey("PK_ServiceDetails", x => x.ServiceDetailID);
                    table.ForeignKey(
                        name: "FK_ServiceDetails_CommunityDetails_CommunityId",
                        column: x => x.CommunityId,
                        principalSchema: "AppData",
                        principalTable: "CommunityDetails",
                        principalColumn: "CommunityId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ServiceHistory",
                schema: "AppData",
                columns: table => new
                {
                    ServiceHistoryID = table.Column<string>(nullable: false),
                    CommunityId = table.Column<string>(nullable: true),
                    InsertDateTime = table.Column<DateTime>(nullable: false),
                    AssetId = table.Column<string>(nullable: true),
                    Asset_NR = table.Column<string>(nullable: true),
                    Asset_Name = table.Column<string>(nullable: true),
                    Asset_service_Freq = table.Column<string>(nullable: true),
                    Asset_last_servce = table.Column<DateTime>(nullable: false),
                    Asset_service_flag = table.Column<string>(nullable: true),
                    Asset_service_date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceHistory", x => x.ServiceHistoryID);
                    table.ForeignKey(
                        name: "FK_ServiceHistory_CommunityDetails_CommunityId",
                        column: x => x.CommunityId,
                        principalSchema: "AppData",
                        principalTable: "CommunityDetails",
                        principalColumn: "CommunityId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "VehicleDetails",
                schema: "AppData",
                columns: table => new
                {
                    VehicleDetailsID = table.Column<string>(nullable: false),
                    CommunityID = table.Column<string>(nullable: true),
                    InsertDateTime = table.Column<DateTime>(nullable: false),
                    Owner_fname = table.Column<string>(nullable: true),
                    Owner_lname = table.Column<string>(nullable: true),
                    Owner_flatno = table.Column<string>(nullable: true),
                    Owner_phno = table.Column<string>(nullable: true),
                    Owner_email = table.Column<string>(nullable: true),
                    Owner_slotno = table.Column<string>(nullable: true),
                    Vehicle_no = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleDetails", x => x.VehicleDetailsID);
                    table.ForeignKey(
                        name: "FK_VehicleDetails_CommunityDetails_CommunityID",
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
                name: "PollQuestion",
                schema: "AppData",
                columns: table => new
                {
                    PollQuestionID = table.Column<string>(nullable: false),
                    InsertDateTime = table.Column<DateTime>(nullable: false),
                    PollName = table.Column<string>(nullable: true),
                    Question = table.Column<string>(nullable: true),
                    CommunityID = table.Column<string>(nullable: true),
                    PollID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PollQuestion", x => x.PollQuestionID);
                    table.ForeignKey(
                        name: "FK_PollQuestion_CommunityDetails_CommunityID",
                        column: x => x.CommunityID,
                        principalSchema: "AppData",
                        principalTable: "CommunityDetails",
                        principalColumn: "CommunityId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PollQuestion_Poll_PollID",
                        column: x => x.PollID,
                        principalSchema: "AppData",
                        principalTable: "Poll",
                        principalColumn: "PollID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "VehicleDetailsHistory",
                schema: "AppData",
                columns: table => new
                {
                    VehicleDetailsHistoryID = table.Column<string>(nullable: false),
                    CommunityID = table.Column<string>(nullable: true),
                    InsertDateTime = table.Column<DateTime>(nullable: false),
                    VehicleDetailsID = table.Column<string>(nullable: true),
                    Owner_fname = table.Column<string>(nullable: true),
                    Owner_lname = table.Column<string>(nullable: true),
                    Owner_flatno = table.Column<string>(nullable: true),
                    Owner_phno = table.Column<string>(nullable: true),
                    Owner_email = table.Column<string>(nullable: true),
                    Owner_slotno = table.Column<string>(nullable: true),
                    Vehicle_no = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleDetailsHistory", x => x.VehicleDetailsHistoryID);
                    table.ForeignKey(
                        name: "FK_VehicleDetailsHistory_CommunityDetails_CommunityID",
                        column: x => x.CommunityID,
                        principalSchema: "AppData",
                        principalTable: "CommunityDetails",
                        principalColumn: "CommunityId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_VehicleDetailsHistory_VehicleDetails_VehicleDetailsID",
                        column: x => x.VehicleDetailsID,
                        principalSchema: "AppData",
                        principalTable: "VehicleDetails",
                        principalColumn: "VehicleDetailsID",
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

            migrationBuilder.CreateTable(
                name: "PollResponse",
                schema: "AppData",
                columns: table => new
                {
                    PollResponseID = table.Column<string>(nullable: false),
                    PollName = table.Column<string>(nullable: true),
                    Response = table.Column<string>(nullable: true),
                    InsertDateTime = table.Column<DateTime>(nullable: false),
                    User = table.Column<string>(nullable: true),
                    PollQuestionID = table.Column<string>(nullable: true),
                    CommunityID = table.Column<string>(nullable: true),
                    PollID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PollResponse", x => x.PollResponseID);
                    table.ForeignKey(
                        name: "FK_PollResponse_CommunityDetails_CommunityID",
                        column: x => x.CommunityID,
                        principalSchema: "AppData",
                        principalTable: "CommunityDetails",
                        principalColumn: "CommunityId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PollResponse_Poll_PollID",
                        column: x => x.PollID,
                        principalSchema: "AppData",
                        principalTable: "Poll",
                        principalColumn: "PollID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PollResponse_PollQuestion_PollQuestionID",
                        column: x => x.PollQuestionID,
                        principalSchema: "AppData",
                        principalTable: "PollQuestion",
                        principalColumn: "PollQuestionID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AssetDetails_CommunityId",
                schema: "AppData",
                table: "AssetDetails",
                column: "CommunityId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetRequest_CommunityId",
                schema: "AppData",
                table: "AssetRequest",
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
                name: "IX_ParkingAssignment_CommunityID",
                schema: "AppData",
                table: "ParkingAssignment",
                column: "CommunityID");

            migrationBuilder.CreateIndex(
                name: "IX_ParkingAssignmentHistory_CommunityID",
                schema: "AppData",
                table: "ParkingAssignmentHistory",
                column: "CommunityID");

            migrationBuilder.CreateIndex(
                name: "IX_Poll_CommunityID",
                schema: "AppData",
                table: "Poll",
                column: "CommunityID");

            migrationBuilder.CreateIndex(
                name: "IX_PollQuestion_CommunityID",
                schema: "AppData",
                table: "PollQuestion",
                column: "CommunityID");

            migrationBuilder.CreateIndex(
                name: "IX_PollQuestion_PollID",
                schema: "AppData",
                table: "PollQuestion",
                column: "PollID");

            migrationBuilder.CreateIndex(
                name: "IX_PollResponse_CommunityID",
                schema: "AppData",
                table: "PollResponse",
                column: "CommunityID");

            migrationBuilder.CreateIndex(
                name: "IX_PollResponse_PollID",
                schema: "AppData",
                table: "PollResponse",
                column: "PollID");

            migrationBuilder.CreateIndex(
                name: "IX_PollResponse_PollQuestionID",
                schema: "AppData",
                table: "PollResponse",
                column: "PollQuestionID");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceDetails_CommunityId",
                schema: "AppData",
                table: "ServiceDetails",
                column: "CommunityId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceHistory_CommunityId",
                schema: "AppData",
                table: "ServiceHistory",
                column: "CommunityId");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleDetails_CommunityID",
                schema: "AppData",
                table: "VehicleDetails",
                column: "CommunityID");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleDetailsHistory_CommunityID",
                schema: "AppData",
                table: "VehicleDetailsHistory",
                column: "CommunityID");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleDetailsHistory_VehicleDetailsID",
                schema: "AppData",
                table: "VehicleDetailsHistory",
                column: "VehicleDetailsID");

            migrationBuilder.CreateIndex(
                name: "IX_VisitorDetails_CommunityID",
                schema: "AppData",
                table: "VisitorDetails",
                column: "CommunityID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Account",
                schema: "AppData");

            migrationBuilder.DropTable(
                name: "ApplicationUser",
                schema: "AppData");

            migrationBuilder.DropTable(
                name: "AssetDetails",
                schema: "AppData");

            migrationBuilder.DropTable(
                name: "AssetRequest",
                schema: "AppData");

            migrationBuilder.DropTable(
                name: "CommunityUser",
                schema: "AppData");

            migrationBuilder.DropTable(
                name: "Expense",
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
                name: "maintMaster",
                schema: "AppData");

            migrationBuilder.DropTable(
                name: "MonthlyMaint",
                schema: "AppData");

            migrationBuilder.DropTable(
                name: "OwnerMaster",
                schema: "AppData");

            migrationBuilder.DropTable(
                name: "ParkingAssignment",
                schema: "AppData");

            migrationBuilder.DropTable(
                name: "ParkingAssignmentHistory",
                schema: "AppData");

            migrationBuilder.DropTable(
                name: "PollResponse",
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
                name: "SourceOthers",
                schema: "AppData");

            migrationBuilder.DropTable(
                name: "TransactionMaster",
                schema: "AppData");

            migrationBuilder.DropTable(
                name: "VehicleDetailsHistory",
                schema: "AppData");

            migrationBuilder.DropTable(
                name: "VisitorDetails",
                schema: "AppData");

            migrationBuilder.DropTable(
                name: "CommunityFlats",
                schema: "AppData");

            migrationBuilder.DropTable(
                name: "PollQuestion",
                schema: "AppData");

            migrationBuilder.DropTable(
                name: "VehicleDetails",
                schema: "AppData");

            migrationBuilder.DropTable(
                name: "CommunityBlock",
                schema: "AppData");

            migrationBuilder.DropTable(
                name: "Poll",
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
