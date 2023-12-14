using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BsuApi.Migrations
{
    /// <inheritdoc />
    public partial class filnalMig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_News_CourseGroups_CourseGroupId",
                table: "News");

            migrationBuilder.DropColumn(
                name: "IdCourseGroup",
                table: "News");

            migrationBuilder.AddColumn<byte[]>(
                name: "Photo",
                table: "Users",
                type: "longblob",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "CourseGroupId",
                table: "News",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)",
                oldNullable: true)
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AddForeignKey(
                name: "FK_News_CourseGroups_CourseGroupId",
                table: "News",
                column: "CourseGroupId",
                principalTable: "CourseGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_News_CourseGroups_CourseGroupId",
                table: "News");

            migrationBuilder.DropColumn(
                name: "Photo",
                table: "Users");

            migrationBuilder.AlterColumn<Guid>(
                name: "CourseGroupId",
                table: "News",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)")
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AddColumn<Guid>(
                name: "IdCourseGroup",
                table: "News",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci");

            migrationBuilder.AddForeignKey(
                name: "FK_News_CourseGroups_CourseGroupId",
                table: "News",
                column: "CourseGroupId",
                principalTable: "CourseGroups",
                principalColumn: "Id");
        }
    }
}
