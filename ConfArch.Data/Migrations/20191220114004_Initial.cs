using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ConfArch.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Conferences",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 250, nullable: true),
                    Start = table.Column<DateTime>(nullable: false),
                    Location = table.Column<string>(maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conferences", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Attendees",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConferenceId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attendees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Attendees_Conferences_ConferenceId",
                        column: x => x.ConferenceId,
                        principalTable: "Conferences",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Proposals",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConferenceId = table.Column<int>(nullable: false),
                    Speaker = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    Approved = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proposals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Proposals_Conferences_ConferenceId",
                        column: x => x.ConferenceId,
                        principalTable: "Conferences",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Conferences",
                columns: new[] { "Id", "Location", "Name", "Start" },
                values: new object[] { 1, "Salt Lake City", "Pluralsight Live", new DateTime(2019, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Conferences",
                columns: new[] { "Id", "Location", "Name", "Start" },
                values: new object[] { 2, "London", "Pluralsight Live", new DateTime(2019, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Attendees",
                columns: new[] { "Id", "ConferenceId", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Lisa Overthere" },
                    { 2, 1, "Robin Eisenberg" },
                    { 3, 2, "Sue Mashmellow" }
                });

            migrationBuilder.InsertData(
                table: "Proposals",
                columns: new[] { "Id", "Approved", "ConferenceId", "Speaker", "Title" },
                values: new object[,]
                {
                    { 1, false, 1, "Roland Guijt", "Authentication and Authorization in ASP.NET Core" },
                    { 2, false, 2, "Cindy Reynolds", "Starting Your Developer Career" },
                    { 3, false, 2, "Heather Lipens", "ASP.NET Core TagHelpers" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Attendees_ConferenceId",
                table: "Attendees",
                column: "ConferenceId");

            migrationBuilder.CreateIndex(
                name: "IX_Proposals_ConferenceId",
                table: "Proposals",
                column: "ConferenceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Attendees");

            migrationBuilder.DropTable(
                name: "Proposals");

            migrationBuilder.DropTable(
                name: "Conferences");
        }
    }
}
