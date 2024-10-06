using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SystemB.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitSystemBDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "SystemB");

            migrationBuilder.CreateTable(
                name: "UserEventHistoricalRecords",
                schema: "SystemB",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MessageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MessageBody = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ActionDateTimeInUtc = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserEventHistoricalRecords", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserEventHistoricalRecords",
                schema: "SystemB");
        }
    }
}
