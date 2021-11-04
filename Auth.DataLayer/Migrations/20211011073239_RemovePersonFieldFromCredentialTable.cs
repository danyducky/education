using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Auth.DataLayer.Migrations
{
    public partial class RemovePersonFieldFromCredentialTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_credentials_persons_personId",
                table: "credentials");

            migrationBuilder.DropPrimaryKey(
                name: "PK_credentials",
                table: "credentials");

            migrationBuilder.DropIndex(
                name: "IX_credentials_personId",
                table: "credentials");

            migrationBuilder.DropColumn(
                name: "personId",
                table: "credentials");

            migrationBuilder.AddPrimaryKey(
                name: "PK_credentials",
                table: "credentials",
                columns: new[] { "userId", "roleId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_credentials",
                table: "credentials");

            migrationBuilder.AddColumn<Guid>(
                name: "personId",
                table: "credentials",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_credentials",
                table: "credentials",
                columns: new[] { "userId", "personId", "roleId" });

            migrationBuilder.CreateIndex(
                name: "IX_credentials_personId",
                table: "credentials",
                column: "personId");

            migrationBuilder.AddForeignKey(
                name: "FK_credentials_persons_personId",
                table: "credentials",
                column: "personId",
                principalTable: "persons",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
