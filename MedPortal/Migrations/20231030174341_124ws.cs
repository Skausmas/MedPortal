using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedPortal.Migrations
{
    /// <inheritdoc />
    public partial class _124ws : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Specialist",
                table: "Hospitals");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Registration",
                newName: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Registration",
                newName: "Name");

            migrationBuilder.AddColumn<List<string>>(
                name: "Specialist",
                table: "Hospitals",
                type: "text[]",
                nullable: false);
        }
    }
}
