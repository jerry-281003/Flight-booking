using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlightBooking5.Migrations
{
    public partial class inittialcreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Airline",
                table: "Flight",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Airline",
                table: "Flight");
        }
    }
}
