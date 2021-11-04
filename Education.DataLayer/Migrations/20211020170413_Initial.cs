using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Education.DataLayer.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "specialities",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    caption = table.Column<string>(type: "text", nullable: true),
                    short_caption = table.Column<string>(type: "text", nullable: true),
                    years_to_study = table.Column<short>(type: "smallint", nullable: false),
                    months_to_study = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_specialities", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "groups",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    caption = table.Column<string>(type: "text", nullable: true),
                    speciality_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_groups", x => x.id);
                    table.ForeignKey(
                        name: "FK_groups_specialities_speciality_id",
                        column: x => x.speciality_id,
                        principalTable: "specialities",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "group_requests",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    group_id = table.Column<Guid>(type: "uuid", nullable: false),
                    comment = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_group_requests", x => x.id);
                    table.ForeignKey(
                        name: "FK_group_requests_groups_group_id",
                        column: x => x.group_id,
                        principalTable: "groups",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    person_id = table.Column<Guid>(type: "uuid", nullable: false),
                    firstname = table.Column<string>(type: "text", nullable: true),
                    surname = table.Column<string>(type: "text", nullable: true),
                    patronymic = table.Column<string>(type: "text", nullable: true),
                    group_id = table.Column<Guid>(type: "uuid", nullable: false),
                    is_group_leader = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.id);
                    table.ForeignKey(
                        name: "FK_Students_groups_group_id",
                        column: x => x.group_id,
                        principalTable: "groups",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_group_requests_group_id",
                table: "group_requests",
                column: "group_id");

            migrationBuilder.CreateIndex(
                name: "IX_groups_speciality_id",
                table: "groups",
                column: "speciality_id");

            migrationBuilder.CreateIndex(
                name: "IX_Students_group_id",
                table: "Students",
                column: "group_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "group_requests");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "groups");

            migrationBuilder.DropTable(
                name: "specialities");
        }
    }
}
