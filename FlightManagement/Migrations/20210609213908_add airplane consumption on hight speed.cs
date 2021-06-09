using Microsoft.EntityFrameworkCore.Migrations;

namespace FlightManagement.Migrations
{
    public partial class addairplaneconsumptiononhightspeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "ConsumptionOnhightSpeed",
                table: "Planes",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ConsumptionOnhightSpeed",
                table: "Planes");
        }
    }
}
