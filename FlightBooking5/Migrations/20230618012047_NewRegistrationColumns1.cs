using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlightBooking5.Migrations
{
    public partial class NewRegistrationColumns1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
        name: "Role",
        table: "AspNetUsers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
