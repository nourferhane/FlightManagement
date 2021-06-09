using Microsoft.EntityFrameworkCore.Migrations;

namespace FlightManagement.Migrations
{
    public partial class addairplaneconsumptionperhour : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ConsumptionOnhightSpeed",
                table: "Planes");

            migrationBuilder.AddColumn<int>(
                name: "ConsumptionPerHour",
                table: "Planes",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ConsumptionPerHour",
                table: "Planes");

            migrationBuilder.AddColumn<long>(
                name: "ConsumptionOnhightSpeed",
                table: "Planes",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }
    }
}
