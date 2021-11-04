using Microsoft.EntityFrameworkCore.Migrations;

namespace Education.DataLayer.Migrations
{
    public partial class RenameStudentTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_groups_group_id",
                table: "Students");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Students",
                table: "Students");

            migrationBuilder.RenameTable(
                name: "Students",
                newName: "students");

            migrationBuilder.RenameIndex(
                name: "IX_Students_group_id",
                table: "students",
                newName: "IX_students_group_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_students",
                table: "students",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_students_groups_group_id",
                table: "students",
                column: "group_id",
                principalTable: "groups",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_students_groups_group_id",
                table: "students");

            migrationBuilder.DropPrimaryKey(
                name: "PK_students",
                table: "students");

            migrationBuilder.RenameTable(
                name: "students",
                newName: "Students");

            migrationBuilder.RenameIndex(
                name: "IX_students_group_id",
                table: "Students",
                newName: "IX_Students_group_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Students",
                table: "Students",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_groups_group_id",
                table: "Students",
                column: "group_id",
                principalTable: "groups",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
