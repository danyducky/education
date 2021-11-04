using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Auth.DataLayer.Migrations
{
    public partial class AddModuleTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "birthDate",
                table: "persons",
                newName: "birth_date");

            migrationBuilder.CreateTable(
                name: "modules",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    caption = table.Column<string>(type: "text", nullable: true),
                    short_caption = table.Column<string>(type: "text", nullable: true),
                    route = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_modules", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "modules");

            migrationBuilder.RenameColumn(
                name: "birth_date",
                table: "persons",
                newName: "birthDate");
        }
    }
}
