using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Domain.Migrations
{
    public partial class taskdetailsssss : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_TaskDetails_TaskDetailsId",
                table: "Tasks");

            migrationBuilder.AlterColumn<Guid>(
                name: "TaskDetailsId",
                table: "Tasks",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_TaskDetails_TaskDetailsId",
                table: "Tasks",
                column: "TaskDetailsId",
                principalTable: "TaskDetails",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_TaskDetails_TaskDetailsId",
                table: "Tasks");

            migrationBuilder.AlterColumn<Guid>(
                name: "TaskDetailsId",
                table: "Tasks",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_TaskDetails_TaskDetailsId",
                table: "Tasks",
                column: "TaskDetailsId",
                principalTable: "TaskDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
