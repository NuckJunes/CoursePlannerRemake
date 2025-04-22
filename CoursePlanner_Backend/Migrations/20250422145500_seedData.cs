using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CoursePlanner_Backend.Migrations
{
    /// <inheritdoc />
    public partial class seedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Campuses",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Hamilton" },
                    { 2, "Luxembourg" },
                    { 3, "Middletown" },
                    { 4, "Oxford" },
                    { 5, "West Chester" }
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "Course_Number", "Credit_Hours", "Description", "Name", "PreRequisites", "Subject" },
                values: new object[,]
                {
                    { 1, 135, 3.0, "Develops fundamentals of analyzing, organizing, adapting, and delivering ideas effectively in public contexts. Special emphasis placed upon informative and persuasive discourse.", "Principles of Public Speaking", "", "STC" },
                    { 2, 231, 3.0, "Theoretical issues that affect communication between members of work teams, discussion groups, and decision-making bodies. Students study these theories and related research studies and work as members of student teams to analyze critically both the theoretical and practical implications of the theories and research studies.", "Small Group Communication", "", "APC" },
                    { 3, 151, 4.0, "Topics include limits and continuity, derivatives and their applications, and early integration techniques of polynomial, rational, radical, trigonometric, inverse trigonometric, exponential, and logarithmic functions. It is expected that students have completed a trigonometry or pre-calculus course and possess the following pre-requisite knowledge: factoring polynomials, working with fractional exponents, finding the domain of functions, properties of common functions such as polynomial, absolute value, exponential, logarithmic, trigonometric, and rational functions, solving a variety of types of equations, inverse functions, graphing, and other related topics", "Calculus I", "", "MTH" },
                    { 4, 231, 3.0, "Service course. Topics, techniques and terminology in discrete mathematics: logic, sets, proof by mathematical induction, relations, counting. Credit does not count toward a major in the department of Mathematics or Statistics.", "Elements of Discrete Mathematics", "", "MTH" },
                    { 5, 331, 3.0, "Designed to ease the transition to 400-level courses in mathematics and statistics. The emphasis of the course is on writing and analyzing mathematical proofs. Topics covered will be foundational for higher level courses and will include propositional and predicate logic, methods of proof, induction, sets, relations, and functions.", "Proof: Introduction to Higher Mathematics", "", "MTH" }
                });

            migrationBuilder.InsertData(
                table: "Features",
                columns: new[] { "Id", "Name", "Short_Name" },
                values: new object[,]
                {
                    { 1, "Advanced Writing", "PA" },
                    { 2, "Creative Arts", "PA" }
                });

            migrationBuilder.InsertData(
                table: "Majors",
                columns: new[] { "Id", "College", "Credit_Max", "Credit_Min", "Graduate", "Name" },
                values: new object[] { 1, "College of Computer Science", 98.0, 92.0, false, "Software Engineering" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Admin", "Email", "Password", "Username" },
                values: new object[] { 1, false, "Email@Email.com", "Password", "Username" });

            migrationBuilder.InsertData(
                table: "CampusCourse",
                columns: new[] { "CampusesId", "CoursesId" },
                values: new object[,]
                {
                    { 1, 4 },
                    { 4, 1 },
                    { 4, 2 },
                    { 4, 3 },
                    { 4, 4 },
                    { 4, 5 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CampusCourse",
                keyColumns: new[] { "CampusesId", "CoursesId" },
                keyValues: new object[] { 1, 4 });

            migrationBuilder.DeleteData(
                table: "CampusCourse",
                keyColumns: new[] { "CampusesId", "CoursesId" },
                keyValues: new object[] { 4, 1 });

            migrationBuilder.DeleteData(
                table: "CampusCourse",
                keyColumns: new[] { "CampusesId", "CoursesId" },
                keyValues: new object[] { 4, 2 });

            migrationBuilder.DeleteData(
                table: "CampusCourse",
                keyColumns: new[] { "CampusesId", "CoursesId" },
                keyValues: new object[] { 4, 3 });

            migrationBuilder.DeleteData(
                table: "CampusCourse",
                keyColumns: new[] { "CampusesId", "CoursesId" },
                keyValues: new object[] { 4, 4 });

            migrationBuilder.DeleteData(
                table: "CampusCourse",
                keyColumns: new[] { "CampusesId", "CoursesId" },
                keyValues: new object[] { 4, 5 });

            migrationBuilder.DeleteData(
                table: "Campuses",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Campuses",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Campuses",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Features",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Features",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Majors",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Campuses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Campuses",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
