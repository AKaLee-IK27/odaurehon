using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Server.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BookingDate",
                table: "Bookings",
                newName: "CreatedDate");

            migrationBuilder.AddColumn<string>(
                name: "CitizenIdentification",
                table: "Customers",
                type: "varchar(128)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CitizenIdentification",
                table: "Customers");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "Bookings",
                newName: "BookingDate");
        }
    }
}
