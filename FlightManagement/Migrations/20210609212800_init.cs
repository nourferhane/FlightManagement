using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FlightManagement.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Airports",
                columns: table => new
                {
                    Code = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Latitude = table.Column<long>(type: "bigint", nullable: false),
                    Longitude = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Airports", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "Planes",
                columns: table => new
                {
                    Code = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaxFuel = table.Column<int>(type: "int", nullable: false),
                    TakeOffFuelConsumption = table.Column<long>(type: "bigint", nullable: false),
                    MaxSpeed = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Planes", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "Flights",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Reference = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AeroportDepartCode = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    AeroportDestinationCode = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DepartureTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ArrivalTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Distance = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flights", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Flights_Airports_AeroportDepartCode",
                        column: x => x.AeroportDepartCode,
                        principalTable: "Airports",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Flights_Airports_AeroportDestinationCode",
                        column: x => x.AeroportDestinationCode,
                        principalTable: "Airports",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Flights_AeroportDepartCode",
                table: "Flights",
                column: "AeroportDepartCode");

            migrationBuilder.CreateIndex(
                name: "IX_Flights_AeroportDestinationCode",
                table: "Flights",
                column: "AeroportDestinationCode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Flights");

            migrationBuilder.DropTable(
                name: "Planes");

            migrationBuilder.DropTable(
                name: "Airports");
        }
    }
}
