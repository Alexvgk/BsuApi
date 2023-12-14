using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BsuApi.Migrations
{
    /// <inheritdoc />
    public partial class News : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Schedule_CourseGroup_CGId",
                table: "Schedule");

            migrationBuilder.DropForeignKey(
                name: "FK_Schedule_DayTime_DayId",
                table: "Schedule");

            migrationBuilder.DropForeignKey(
                name: "FK_Schedule_LessonForm_IdForm",
                table: "Schedule");

            migrationBuilder.DropForeignKey(
                name: "FK_Uid_users_UserId",
                table: "Uid");

            migrationBuilder.DropForeignKey(
                name: "FK_users_CourseGroup_IdCourseGroup",
                table: "users");

            migrationBuilder.DropForeignKey(
                name: "FK_users_Role_IdRole",
                table: "users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_users",
                table: "users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Uid",
                table: "Uid");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Schedule",
                table: "Schedule");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Role",
                table: "Role");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LessonForm",
                table: "LessonForm");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DayTime",
                table: "DayTime");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CourseGroup",
                table: "CourseGroup");

            migrationBuilder.RenameTable(
                name: "users",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "Uid",
                newName: "Uids");

            migrationBuilder.RenameTable(
                name: "Schedule",
                newName: "Schedules");

            migrationBuilder.RenameTable(
                name: "Role",
                newName: "Roles");

            migrationBuilder.RenameTable(
                name: "LessonForm",
                newName: "lessonForms");

            migrationBuilder.RenameTable(
                name: "DayTime",
                newName: "DayTimes");

            migrationBuilder.RenameTable(
                name: "CourseGroup",
                newName: "CourseGroups");

            migrationBuilder.RenameIndex(
                name: "IX_users_IdRole",
                table: "Users",
                newName: "IX_Users_IdRole");

            migrationBuilder.RenameIndex(
                name: "IX_users_IdCourseGroup",
                table: "Users",
                newName: "IX_Users_IdCourseGroup");

            migrationBuilder.RenameIndex(
                name: "IX_Uid_UserId",
                table: "Uids",
                newName: "IX_Uids_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Schedule_IdForm",
                table: "Schedules",
                newName: "IX_Schedules_IdForm");

            migrationBuilder.RenameIndex(
                name: "IX_Schedule_DayId",
                table: "Schedules",
                newName: "IX_Schedules_DayId");

            migrationBuilder.RenameIndex(
                name: "IX_Schedule_CGId",
                table: "Schedules",
                newName: "IX_Schedules_CGId");

            migrationBuilder.AddColumn<string>(
                name: "Speciality",
                table: "CourseGroups",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Uids",
                table: "Uids",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Schedules",
                table: "Schedules",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Roles",
                table: "Roles",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_lessonForms",
                table: "lessonForms",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DayTimes",
                table: "DayTimes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CourseGroups",
                table: "CourseGroups",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "News",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Text = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ImageData = table.Column<byte[]>(type: "longblob", nullable: true),
                    CourseGroupId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_News", x => x.Id);
                    table.ForeignKey(
                        name: "FK_News_CourseGroups_CourseGroupId",
                        column: x => x.CourseGroupId,
                        principalTable: "CourseGroups",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_News_CourseGroupId",
                table: "News",
                column: "CourseGroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_Schedules_CourseGroups_CGId",
                table: "Schedules",
                column: "CGId",
                principalTable: "CourseGroups",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Schedules_DayTimes_DayId",
                table: "Schedules",
                column: "DayId",
                principalTable: "DayTimes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Schedules_lessonForms_IdForm",
                table: "Schedules",
                column: "IdForm",
                principalTable: "lessonForms",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Uids_Users_UserId",
                table: "Uids",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_CourseGroups_IdCourseGroup",
                table: "Users",
                column: "IdCourseGroup",
                principalTable: "CourseGroups",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Roles_IdRole",
                table: "Users",
                column: "IdRole",
                principalTable: "Roles",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Schedules_CourseGroups_CGId",
                table: "Schedules");

            migrationBuilder.DropForeignKey(
                name: "FK_Schedules_DayTimes_DayId",
                table: "Schedules");

            migrationBuilder.DropForeignKey(
                name: "FK_Schedules_lessonForms_IdForm",
                table: "Schedules");

            migrationBuilder.DropForeignKey(
                name: "FK_Uids_Users_UserId",
                table: "Uids");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_CourseGroups_IdCourseGroup",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Roles_IdRole",
                table: "Users");

            migrationBuilder.DropTable(
                name: "News");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Uids",
                table: "Uids");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Schedules",
                table: "Schedules");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Roles",
                table: "Roles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_lessonForms",
                table: "lessonForms");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DayTimes",
                table: "DayTimes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CourseGroups",
                table: "CourseGroups");

            migrationBuilder.DropColumn(
                name: "Speciality",
                table: "CourseGroups");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "users");

            migrationBuilder.RenameTable(
                name: "Uids",
                newName: "Uid");

            migrationBuilder.RenameTable(
                name: "Schedules",
                newName: "Schedule");

            migrationBuilder.RenameTable(
                name: "Roles",
                newName: "Role");

            migrationBuilder.RenameTable(
                name: "lessonForms",
                newName: "LessonForm");

            migrationBuilder.RenameTable(
                name: "DayTimes",
                newName: "DayTime");

            migrationBuilder.RenameTable(
                name: "CourseGroups",
                newName: "CourseGroup");

            migrationBuilder.RenameIndex(
                name: "IX_Users_IdRole",
                table: "users",
                newName: "IX_users_IdRole");

            migrationBuilder.RenameIndex(
                name: "IX_Users_IdCourseGroup",
                table: "users",
                newName: "IX_users_IdCourseGroup");

            migrationBuilder.RenameIndex(
                name: "IX_Uids_UserId",
                table: "Uid",
                newName: "IX_Uid_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Schedules_IdForm",
                table: "Schedule",
                newName: "IX_Schedule_IdForm");

            migrationBuilder.RenameIndex(
                name: "IX_Schedules_DayId",
                table: "Schedule",
                newName: "IX_Schedule_DayId");

            migrationBuilder.RenameIndex(
                name: "IX_Schedules_CGId",
                table: "Schedule",
                newName: "IX_Schedule_CGId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_users",
                table: "users",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Uid",
                table: "Uid",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Schedule",
                table: "Schedule",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Role",
                table: "Role",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LessonForm",
                table: "LessonForm",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DayTime",
                table: "DayTime",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CourseGroup",
                table: "CourseGroup",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Schedule_CourseGroup_CGId",
                table: "Schedule",
                column: "CGId",
                principalTable: "CourseGroup",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Schedule_DayTime_DayId",
                table: "Schedule",
                column: "DayId",
                principalTable: "DayTime",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Schedule_LessonForm_IdForm",
                table: "Schedule",
                column: "IdForm",
                principalTable: "LessonForm",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Uid_users_UserId",
                table: "Uid",
                column: "UserId",
                principalTable: "users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_users_CourseGroup_IdCourseGroup",
                table: "users",
                column: "IdCourseGroup",
                principalTable: "CourseGroup",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_users_Role_IdRole",
                table: "users",
                column: "IdRole",
                principalTable: "Role",
                principalColumn: "Id");
        }
    }
}
