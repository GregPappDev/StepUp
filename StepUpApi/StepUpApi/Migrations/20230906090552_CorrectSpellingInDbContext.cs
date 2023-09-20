using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StepUpApi.Migrations
{
    /// <inheritdoc />
    public partial class CorrectSpellingInDbContext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppointmentLogUser_AppointmentLos_AppointmentLogsId",
                table: "AppointmentLogUser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppointmentLos",
                table: "AppointmentLos");

            migrationBuilder.RenameTable(
                name: "AppointmentLos",
                newName: "AppointmentLog");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppointmentLog",
                table: "AppointmentLog",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AppointmentLogUser_AppointmentLog_AppointmentLogsId",
                table: "AppointmentLogUser",
                column: "AppointmentLogsId",
                principalTable: "AppointmentLog",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppointmentLogUser_AppointmentLog_AppointmentLogsId",
                table: "AppointmentLogUser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppointmentLog",
                table: "AppointmentLog");

            migrationBuilder.RenameTable(
                name: "AppointmentLog",
                newName: "AppointmentLos");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppointmentLos",
                table: "AppointmentLos",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AppointmentLogUser_AppointmentLos_AppointmentLogsId",
                table: "AppointmentLogUser",
                column: "AppointmentLogsId",
                principalTable: "AppointmentLos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
