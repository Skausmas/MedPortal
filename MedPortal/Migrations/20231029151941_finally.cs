using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedPortal.Migrations
{
    /// <inheritdoc />
    public partial class @finally : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Hospital",
                table: "Registration",
                newName: "HospitalId");

            migrationBuilder.AddColumn<List<string>>(
                name: "Specialist",
                table: "Hospitals",
                type: "text[]",
                nullable: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Specialist",
                table: "Hospitals");

            migrationBuilder.RenameColumn(
                name: "HospitalId",
                table: "Registration",
                newName: "Hospital");
        }
    }
}
