using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SystemB.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddEventTypeColumnToUserEventHistoricalRecord : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EventType",
                schema: "SystemB",
                table: "UserEventHistoricalRecords",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EventType",
                schema: "SystemB",
                table: "UserEventHistoricalRecords");
        }
    }
}
