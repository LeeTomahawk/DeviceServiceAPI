using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Domain.Migrations
{
    public partial class taskdetailssss : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_TaskDetails_EmployeeId",
                table: "Tasks");

            migrationBuilder.RenameColumn(
                name: "EmployeeId",
                table: "Tasks",
                newName: "TaskDetailsId");

            migrationBuilder.RenameIndex(
                name: "IX_Tasks_EmployeeId",
                table: "Tasks",
                newName: "IX_Tasks_TaskDetailsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_TaskDetails_TaskDetailsId",
                table: "Tasks",
                column: "TaskDetailsId",
                principalTable: "TaskDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_TaskDetails_TaskDetailsId",
                table: "Tasks");

            migrationBuilder.RenameColumn(
                name: "TaskDetailsId",
                table: "Tasks",
                newName: "EmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_Tasks_TaskDetailsId",
                table: "Tasks",
                newName: "IX_Tasks_EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_TaskDetails_EmployeeId",
                table: "Tasks",
                column: "EmployeeId",
                principalTable: "TaskDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
