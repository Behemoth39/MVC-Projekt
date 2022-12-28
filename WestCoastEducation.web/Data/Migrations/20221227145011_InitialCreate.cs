using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WestCoastEducation.web.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    CourseId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CourseName = table.Column<string>(type: "TEXT", nullable: false),
                    CourseNumer = table.Column<string>(type: "TEXT", nullable: false),
                    EnrollmentLimit = table.Column<string>(type: "TEXT", nullable: false),
                    ParticipantList = table.Column<string>(type: "TEXT", nullable: false),
                    CourseStart = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CourseEnd = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.CourseId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Courses");
        }
    }
}
