using Microsoft.EntityFrameworkCore.Migrations;

namespace AppointmentMvc.Migrations
{
    public partial class MessageToDescription : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Message",
                table: "Appointment",
                newName: "Description");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Appointment",
                newName: "Message");
        }
    }
}
