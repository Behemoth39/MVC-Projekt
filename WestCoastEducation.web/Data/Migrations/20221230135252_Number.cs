using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WestCoastEducation.web.Data.Migrations
{
    /// <inheritdoc />
    public partial class Number : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CourseNumer",
                table: "Courses",
                newName: "CourseNumber");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CourseNumber",
                table: "Courses",
                newName: "CourseNumer");
        }
    }
}
