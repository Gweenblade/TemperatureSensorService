using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TemperatureSensor.Infrastructure.DatabaseUtility.Migrations
{
    public partial class SensorIdLength : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "SensorId",
                table: "TemperatureSensors",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "SensorId",
                table: "TemperatureSensors",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);
        }
    }
}
