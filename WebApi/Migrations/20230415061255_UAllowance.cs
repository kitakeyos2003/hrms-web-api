using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    public partial class UAllowance : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Allowances_department_DepartmentID",
                table: "Allowances");

            migrationBuilder.DropForeignKey(
                name: "FK_Allowances_position_PositionID",
                table: "Allowances");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Allowances",
                table: "Allowances");

            migrationBuilder.RenameTable(
                name: "Allowances",
                newName: "allowance");

            migrationBuilder.RenameIndex(
                name: "IX_Allowances_PositionID",
                table: "allowance",
                newName: "IX_allowance_PositionID");

            migrationBuilder.RenameIndex(
                name: "IX_Allowances_DepartmentID",
                table: "allowance",
                newName: "IX_allowance_DepartmentID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_allowance",
                table: "allowance",
                column: "AllowanceID");

            migrationBuilder.AddForeignKey(
                name: "FK_allowance_department_DepartmentID",
                table: "allowance",
                column: "DepartmentID",
                principalTable: "department",
                principalColumn: "DepartmentID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_allowance_position_PositionID",
                table: "allowance",
                column: "PositionID",
                principalTable: "position",
                principalColumn: "PositionID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_allowance_department_DepartmentID",
                table: "allowance");

            migrationBuilder.DropForeignKey(
                name: "FK_allowance_position_PositionID",
                table: "allowance");

            migrationBuilder.DropPrimaryKey(
                name: "PK_allowance",
                table: "allowance");

            migrationBuilder.RenameTable(
                name: "allowance",
                newName: "Allowances");

            migrationBuilder.RenameIndex(
                name: "IX_allowance_PositionID",
                table: "Allowances",
                newName: "IX_Allowances_PositionID");

            migrationBuilder.RenameIndex(
                name: "IX_allowance_DepartmentID",
                table: "Allowances",
                newName: "IX_Allowances_DepartmentID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Allowances",
                table: "Allowances",
                column: "AllowanceID");

            migrationBuilder.AddForeignKey(
                name: "FK_Allowances_department_DepartmentID",
                table: "Allowances",
                column: "DepartmentID",
                principalTable: "department",
                principalColumn: "DepartmentID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Allowances_position_PositionID",
                table: "Allowances",
                column: "PositionID",
                principalTable: "position",
                principalColumn: "PositionID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
