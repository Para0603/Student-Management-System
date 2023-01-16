using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GradeCalculatorProject.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StudentModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Student_Regno = table.Column<int>(type: "int", nullable: false),
                    Student_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Student_Dept = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Subject1_Mark = table.Column<int>(type: "int", nullable: false),
                    Subject2_Mark = table.Column<int>(type: "int", nullable: false),
                    Subject3_Mark = table.Column<int>(type: "int", nullable: false),
                    Total_Mark = table.Column<int>(type: "int", nullable: false),
                    Average_Mark = table.Column<int>(type: "int", nullable: false),
                    Grade = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    Image_Path = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentModel", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentModel");
        }
    }
}
