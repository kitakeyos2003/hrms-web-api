using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    public partial class UU : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "position",
                newName: "PositionID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "department",
                newName: "DepartmentID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PositionID",
                table: "position",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "DepartmentID",
                table: "department",
                newName: "Id");
        }
    }
}
