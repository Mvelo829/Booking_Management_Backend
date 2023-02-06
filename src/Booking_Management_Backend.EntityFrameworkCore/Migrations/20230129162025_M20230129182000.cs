using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Booking_Management_Backend.Migrations
{
    public partial class M20230129182000 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProgressStatus",
                table: "Bookings",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProgressStatus",
                table: "Bookings");
        }
    }
}
