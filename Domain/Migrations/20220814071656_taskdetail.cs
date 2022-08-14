using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Domain.Migrations
{
    public partial class taskdetail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_TaskDetails_TaskDetailsId",
                table: "Tasks");

            migrationBuilder.DropTable(
                name: "TaskDetails");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_TaskDetailsId",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "TaskDetailsId",
                table: "Tasks");

            migrationBuilder.AddColumn<DateTime>(
                name: "DoneTaskDate",
                table: "TaskEmployees",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "TakeTaskDate",
                table: "TaskEmployees",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TaskDetailStatus",
                table: "TaskEmployees",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DoneTaskDate",
                table: "TaskEmployees");

            migrationBuilder.DropColumn(
                name: "TakeTaskDate",
                table: "TaskEmployees");

            migrationBuilder.DropColumn(
                name: "TaskDetailStatus",
                table: "TaskEmployees");

            migrationBuilder.AddColumn<Guid>(
                name: "TaskDetailsId",
                table: "Tasks",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TaskDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TaskDetailStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaskDetails_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_TaskDetailsId",
                table: "Tasks",
                column: "TaskDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskDetails_EmployeeId",
                table: "TaskDetails",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_TaskDetails_TaskDetailsId",
                table: "Tasks",
                column: "TaskDetailsId",
                principalTable: "TaskDetails",
                principalColumn: "Id");
        }
    }
}
