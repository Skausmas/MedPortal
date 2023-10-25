using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedPortal.Migrations
{
    /// <inheritdoc />
    public partial class second2m : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "HospitalId",
                table: "Doctors",
                newName: "HospitalsId");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_HospitalsId",
                table: "Doctors",
                column: "HospitalsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_Hospitals_HospitalsId",
                table: "Doctors",
                column: "HospitalsId",
                principalTable: "Hospitals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_Hospitals_HospitalsId",
                table: "Doctors");

            migrationBuilder.DropIndex(
                name: "IX_Doctors_HospitalsId",
                table: "Doctors");

            migrationBuilder.RenameColumn(
                name: "HospitalsId",
                table: "Doctors",
                newName: "HospitalId");
        }
    }
}
