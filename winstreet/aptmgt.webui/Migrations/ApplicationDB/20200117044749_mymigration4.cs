using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace aptmgt.webui.Migrations.ApplicationDB
{
    public partial class mymigration4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "poll",
                schema: "AppData",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PollID = table.Column<int>(nullable: false),
                    Commid = table.Column<string>(nullable: true),
                    Currdate = table.Column<DateTime>(nullable: false),
                    PollName = table.Column<string>(nullable: true),
                    PollStart = table.Column<DateTime>(nullable: false),
                    PollEnd = table.Column<DateTime>(nullable: false),
                    IsOpen = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_poll", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "poll_question",
                schema: "AppData",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    QuestionID = table.Column<string>(nullable: true),
                    Commid = table.Column<string>(nullable: true),
                    Currdate = table.Column<DateTime>(nullable: false),
                    PollID = table.Column<int>(nullable: false),
                    PollName = table.Column<string>(nullable: true),
                    PollQuestion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_poll_question", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "response",
                schema: "AppData",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ResponseID = table.Column<int>(nullable: false),
                    QuestionID = table.Column<string>(nullable: true),
                    Commid = table.Column<string>(nullable: true),
                    Currdate = table.Column<DateTime>(nullable: false),
                    PollID = table.Column<int>(nullable: false),
                    PollName = table.Column<string>(nullable: true),
                    PollResponse = table.Column<string>(nullable: true),
                    User = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_response", x => x.ID);
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Account",
                schema: "AppData");

            migrationBuilder.DropTable(
                name: "Expense",
                schema: "AppData");

            migrationBuilder.DropTable(
                name: "maintMaster",
                schema: "AppData");

            migrationBuilder.DropTable(
                name: "MonthlyMaint",
                schema: "AppData");

            migrationBuilder.DropTable(
                name: "poll",
                schema: "AppData");

            migrationBuilder.DropTable(
                name: "poll_question",
                schema: "AppData");

            migrationBuilder.DropTable(
                name: "response",
                schema: "AppData");

            migrationBuilder.DropTable(
                name: "SourceOthers",
                schema: "AppData");

            migrationBuilder.DropTable(
                name: "TransactionMaster",
                schema: "AppData");
        }
    }
}
