using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedPortal.Migrations
{
    /// <inheritdoc />
    public partial class qwret : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DoctorsId",
                table: "History");

            migrationBuilder.DropColumn(
                name: "HospitalId",
                table: "History");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "History");

            migrationBuilder.AddColumn<int>(
                name: "RegistrationId",
                table: "History",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_History_RegistrationId",
                table: "History",
                column: "RegistrationId");

            migrationBuilder.AddForeignKey(
                name: "FK_History_Registration_RegistrationId",
                table: "History",
                column: "RegistrationId",
                principalTable: "Registration",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_History_Registration_RegistrationId",
                table: "History");

            migrationBuilder.DropIndex(
                name: "IX_History_RegistrationId",
                table: "History");

            migrationBuilder.DropColumn(
                name: "RegistrationId",
                table: "History");

            migrationBuilder.AddColumn<string>(
                name: "DoctorsId",
                table: "History",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "HospitalId",
                table: "History",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "History",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
