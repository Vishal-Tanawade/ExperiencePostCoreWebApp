using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCoreRepositoryPatternDemo.Migrations
{
    public partial class InitializeMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "coreEmployees",
                columns: table => new
                {
                    EmpID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CellNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_coreEmployees", x => x.EmpID);
                });

            migrationBuilder.CreateTable(
                name: "coreSkill",
                columns: table => new
                {
                    SkillId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpID = table.Column<int>(type: "int", nullable: false),
                    SkillName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExperienceInYears = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_coreSkill", x => x.SkillId);
                    table.ForeignKey(
                        name: "FK_coreSkill_coreEmployees_EmpID",
                        column: x => x.EmpID,
                        principalTable: "coreEmployees",
                        principalColumn: "EmpID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "coreEmployees",
                columns: new[] { "EmpID", "CellNumber", "Email", "FirstName", "LastName", "Password" },
                values: new object[] { 1, "(660) 663-4518", "aron.hawkins@aol.com", "Aaron", "Hawkins", "arron@123" });

            migrationBuilder.InsertData(
                table: "coreEmployees",
                columns: new[] { "EmpID", "CellNumber", "Email", "FirstName", "LastName", "Password" },
                values: new object[] { 2, "(608) 265-2215", "hedy.greene@aol.com", "Hedy", "Greene", "hedy@123" });

            migrationBuilder.InsertData(
                table: "coreEmployees",
                columns: new[] { "EmpID", "CellNumber", "Email", "FirstName", "LastName", "Password" },
                values: new object[] { 3, "(959) 119-8364", "melvin.porter@aol.com", "Melvin", "Porter", "melvin@123" });

            migrationBuilder.InsertData(
                table: "coreSkill",
                columns: new[] { "SkillId", "EmpID", "ExperienceInYears", "Role", "SkillName" },
                values: new object[] { 1, 1, 2, "Business Analyst", "Microsoft Office Suite" });

            migrationBuilder.InsertData(
                table: "coreSkill",
                columns: new[] { "SkillId", "EmpID", "ExperienceInYears", "Role", "SkillName" },
                values: new object[] { 2, 1, 3, "Developer", "Testing" });

            migrationBuilder.InsertData(
                table: "coreSkill",
                columns: new[] { "SkillId", "EmpID", "ExperienceInYears", "Role", "SkillName" },
                values: new object[] { 3, 1, 4, "Project Lead", "Stakeholder Management" });

            migrationBuilder.CreateIndex(
                name: "IX_coreSkill_EmpID",
                table: "coreSkill",
                column: "EmpID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "coreSkill");

            migrationBuilder.DropTable(
                name: "coreEmployees");
        }
    }
}
