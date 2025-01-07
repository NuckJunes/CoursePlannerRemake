using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoursePlanner_Backend.Migrations
{
    /// <inheritdoc />
    public partial class Self_Reference : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CourseCourse",
                columns: table => new
                {
                    PrerequisitesId = table.Column<int>(type: "int", nullable: false),
                    RequirementsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseCourse", x => new { x.PrerequisitesId, x.RequirementsId });
                    table.ForeignKey(
                        name: "FK_CourseCourse_Courses_PrerequisitesId",
                        column: x => x.PrerequisitesId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseCourse_Courses_RequirementsId",
                        column: x => x.RequirementsId,
                        principalTable: "Courses",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CourseCourse_RequirementsId",
                table: "CourseCourse",
                column: "RequirementsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseCourse");
        }
    }
}
