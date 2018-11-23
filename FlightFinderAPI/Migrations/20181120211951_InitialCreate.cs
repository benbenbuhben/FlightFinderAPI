using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FlightFinderAPI.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Airport",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Code = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Airport", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Flight",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    From = table.Column<string>(nullable: true),
                    To = table.Column<string>(nullable: true),
                    FlightNumber = table.Column<int>(nullable: false),
                    Departs = table.Column<DateTime>(nullable: false),
                    Arrives = table.Column<DateTime>(nullable: false),
                    MainCabinPrice = table.Column<int>(nullable: false),
                    FirstClassPrice = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flight", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Airport");

            migrationBuilder.DropTable(
                name: "Flight");
        }
    }
}
