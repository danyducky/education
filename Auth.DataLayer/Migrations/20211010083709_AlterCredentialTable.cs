using Microsoft.EntityFrameworkCore.Migrations;

namespace Auth.DataLayer.Migrations
{
    public partial class AlterCredentialTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_credentials_personId",
                table: "credentials",
                column: "personId");

            migrationBuilder.CreateIndex(
                name: "IX_credentials_roleId",
                table: "credentials",
                column: "roleId");

            migrationBuilder.AddForeignKey(
                name: "FK_credentials_persons_personId",
                table: "credentials",
                column: "personId",
                principalTable: "persons",
                principalColumn: "userId",
                onDelete: ReferentialAction.Cascade);

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_credentials_persons_personId",
                table: "credentials");

            migrationBuilder.DropForeignKey(
                name: "FK_credentials_roles_roleId",
                table: "credentials");

            migrationBuilder.DropForeignKey(
                name: "FK_credentials_users_userId",
                table: "credentials");

            migrationBuilder.DropIndex(
                name: "IX_credentials_personId",
                table: "credentials");

            migrationBuilder.DropIndex(
                name: "IX_credentials_roleId",
                table: "credentials");
        }
    }
}
