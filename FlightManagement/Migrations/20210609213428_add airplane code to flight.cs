using Microsoft.EntityFrameworkCore.Migrations;

namespace FlightManagement.Migrations
{
    public partial class addairplanecodetoflight : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AirplaneCode",
                table: "Flights",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Flights_AirplaneCode",
                table: "Flights",
                column: "AirplaneCode");

            migrationBuilder.AddForeignKey(
                name: "FK_Flights_Planes_AirplaneCode",
                table: "Flights",
                column: "AirplaneCode",
                principalTable: "Planes",
                principalColumn: "Code",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Flights_Planes_AirplaneCode",
                table: "Flights");

            migrationBuilder.DropIndex(
                name: "IX_Flights_AirplaneCode",
                table: "Flights");

            migrationBuilder.DropColumn(
                name: "AirplaneCode",
                table: "Flights");
        }
    }
}
