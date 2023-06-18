using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlightBooking5.Migrations
{
    public partial class NewRegistrationColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
    name: "Role",
    table: "AspNetUsers",
    type: "nvarchar(max)",
    nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
               name: "Role",
               table: "AspNetUsers");
        }
    
    }
}
