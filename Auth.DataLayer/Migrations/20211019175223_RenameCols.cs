using Microsoft.EntityFrameworkCore.Migrations;

namespace Auth.DataLayer.Migrations
{
    public partial class RenameCols : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_credentials_roles_roleId",
                table: "credentials");

            migrationBuilder.DropForeignKey(
                name: "FK_credentials_users_userId",
                table: "credentials");

            migrationBuilder.DropForeignKey(
                name: "FK_persons_users_userId",
                table: "persons");

            migrationBuilder.RenameColumn(
                name: "userId",
                table: "persons",
                newName: "user_id");

            migrationBuilder.RenameIndex(
                name: "IX_persons_userId",
                table: "persons",
                newName: "IX_persons_user_id");

            migrationBuilder.RenameColumn(
                name: "roleId",
                table: "credentials",
                newName: "role_id");

            migrationBuilder.RenameColumn(
                name: "userId",
                table: "credentials",
                newName: "user_id");

            migrationBuilder.RenameIndex(
                name: "IX_credentials_roleId",
                table: "credentials",
                newName: "IX_credentials_role_id");

            migrationBuilder.AddForeignKey(
                name: "FK_credentials_roles_role_id",
                table: "credentials",
                column: "role_id",
                principalTable: "roles",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_credentials_users_user_id",
                table: "credentials",
                column: "user_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_persons_users_user_id",
                table: "persons",
                column: "user_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_credentials_roles_role_id",
                table: "credentials");

            migrationBuilder.DropForeignKey(
                name: "FK_credentials_users_user_id",
                table: "credentials");

            migrationBuilder.DropForeignKey(
                name: "FK_persons_users_user_id",
                table: "persons");

            migrationBuilder.RenameColumn(
                name: "user_id",
                table: "persons",
                newName: "userId");

            migrationBuilder.RenameIndex(
                name: "IX_persons_user_id",
                table: "persons",
                newName: "IX_persons_userId");

            migrationBuilder.RenameColumn(
                name: "role_id",
                table: "credentials",
                newName: "roleId");

            migrationBuilder.RenameColumn(
                name: "user_id",
                table: "credentials",
                newName: "userId");

            migrationBuilder.RenameIndex(
                name: "IX_credentials_role_id",
                table: "credentials",
                newName: "IX_credentials_roleId");

            migrationBuilder.AddForeignKey(
                name: "FK_credentials_roles_roleId",
                table: "credentials",
                column: "roleId",
                principalTable: "roles",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_credentials_users_userId",
                table: "credentials",
                column: "userId",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_persons_users_userId",
                table: "persons",
                column: "userId",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
