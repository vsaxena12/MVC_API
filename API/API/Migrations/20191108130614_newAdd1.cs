using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class newAdd1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_department",
                table: "department");

            migrationBuilder.DropColumn(
                name: "ID",
                table: "department");

            migrationBuilder.AddColumn<int>(
                name: "Department_ID",
                table: "department",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_department",
                table: "department",
                column: "Department_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_department",
                table: "department");

            migrationBuilder.DropColumn(
                name: "Department_ID",
                table: "department");

            migrationBuilder.AddColumn<int>(
                name: "ID",
                table: "department",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_department",
                table: "department",
                column: "ID");
        }
    }
}
