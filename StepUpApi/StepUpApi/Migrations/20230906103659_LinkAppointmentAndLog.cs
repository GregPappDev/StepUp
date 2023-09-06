using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StepUpApi.Migrations
{
    /// <inheritdoc />
    public partial class LinkAppointmentAndLog : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "AppointmentId",
                table: "AppointmentLog",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_AppointmentLog_AppointmentId",
                table: "AppointmentLog",
                column: "AppointmentId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AppointmentLog_Appointments_AppointmentId",
                table: "AppointmentLog",
                column: "AppointmentId",
                principalTable: "Appointments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppointmentLog_Appointments_AppointmentId",
                table: "AppointmentLog");

            migrationBuilder.DropIndex(
                name: "IX_AppointmentLog_AppointmentId",
                table: "AppointmentLog");

            migrationBuilder.DropColumn(
                name: "AppointmentId",
                table: "AppointmentLog");
        }
    }
}
