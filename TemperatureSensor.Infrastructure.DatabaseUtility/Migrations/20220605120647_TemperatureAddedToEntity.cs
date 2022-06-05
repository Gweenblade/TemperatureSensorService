using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TemperatureSensor.Infrastructure.DatabaseUtility.Migrations
{
    public partial class TemperatureAddedToEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Temperature",
                table: "TemperatureSensors",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Temperature",
                table: "TemperatureSensors");
        }
    }
}
