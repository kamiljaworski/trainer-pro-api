using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TrainerPro.DAL.Migrations
{
    public partial class TrainingPlanCorrect : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrainingPlan_AspNetUsers_UserId1",
                table: "TrainingPlan");

            migrationBuilder.DropIndex(
                name: "IX_TrainingPlan_UserId1",
                table: "TrainingPlan");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "TrainingPlan");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "TrainingPlan",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingPlan_UserId",
                table: "TrainingPlan",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_TrainingPlan_AspNetUsers_UserId",
                table: "TrainingPlan",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrainingPlan_AspNetUsers_UserId",
                table: "TrainingPlan");

            migrationBuilder.DropIndex(
                name: "IX_TrainingPlan_UserId",
                table: "TrainingPlan");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "TrainingPlan",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UserId1",
                table: "TrainingPlan",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TrainingPlan_UserId1",
                table: "TrainingPlan",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_TrainingPlan_AspNetUsers_UserId1",
                table: "TrainingPlan",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
