using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Auth.DataLayer.Migrations
{
    public partial class AlterCredentialTableAddPersonIdField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_persons",
                table: "persons");

            migrationBuilder.DropPrimaryKey(
                name: "PK_credentials",
                table: "credentials");

            migrationBuilder.AddColumn<Guid>(
                name: "id",
                table: "persons",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "personId",
                table: "credentials",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_persons",
                table: "persons",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_credentials",
                table: "credentials",
                columns: new[] { "userId", "personId", "roleId" });

            migrationBuilder.CreateIndex(
                name: "IX_persons_userId",
                table: "persons",
                column: "userId");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_credentials_persons_personId",
                table: "credentials");

            migrationBuilder.DropPrimaryKey(
                name: "PK_persons",
                table: "persons");

            migrationBuilder.DropIndex(
                name: "IX_persons_userId",
                table: "persons");

            migrationBuilder.DropPrimaryKey(
                name: "PK_credentials",
                table: "credentials");

            migrationBuilder.DropIndex(
                name: "IX_credentials_personId",
                table: "credentials");

            migrationBuilder.DropColumn(
                name: "id",
                table: "persons");

            migrationBuilder.DropColumn(
                name: "personId",
                table: "credentials");

            migrationBuilder.AddPrimaryKey(
                name: "PK_persons",
                table: "persons",
                column: "userId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_credentials",
                table: "credentials",
                columns: new[] { "userId", "roleId" });
        }
    }
}
