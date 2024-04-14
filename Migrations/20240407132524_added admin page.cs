using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Labb1.Migrations
{
    /// <inheritdoc />
    public partial class addedadminpage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vacations_Employees_EmployeeId",
                table: "Vacations");

            migrationBuilder.DropIndex(
                name: "IX_Vacations_EmployeeId",
                table: "Vacations");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "Vacations");

            migrationBuilder.CreateIndex(
                name: "IX_Vacations_FK_EmployeeId",
                table: "Vacations",
                column: "FK_EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vacations_Employees_FK_EmployeeId",
                table: "Vacations",
                column: "FK_EmployeeId",
                principalTable: "Employees",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vacations_Employees_FK_EmployeeId",
                table: "Vacations");

            migrationBuilder.DropIndex(
                name: "IX_Vacations_FK_EmployeeId",
                table: "Vacations");

            migrationBuilder.AddColumn<int>(
                name: "EmployeeId",
                table: "Vacations",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vacations_EmployeeId",
                table: "Vacations",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vacations_Employees_EmployeeId",
                table: "Vacations",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "EmployeeId");
        }
    }
}
