using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StepUpApi.Migrations
{
    /// <inheritdoc />
    public partial class correctusermodel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoleUser_Roles_CollectionId",
                table: "RoleUser");

            migrationBuilder.RenameColumn(
                name: "CollectionId",
                table: "RoleUser",
                newName: "RolesId");

            migrationBuilder.AddForeignKey(
                name: "FK_RoleUser_Roles_RolesId",
                table: "RoleUser",
                column: "RolesId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoleUser_Roles_RolesId",
                table: "RoleUser");

            migrationBuilder.RenameColumn(
                name: "RolesId",
                table: "RoleUser",
                newName: "CollectionId");

            migrationBuilder.AddForeignKey(
                name: "FK_RoleUser_Roles_CollectionId",
                table: "RoleUser",
                column: "CollectionId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
