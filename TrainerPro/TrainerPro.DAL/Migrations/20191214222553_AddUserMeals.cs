using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TrainerPro.DAL.Migrations
{
    public partial class AddUserMeals : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserMeals",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    MealId = table.Column<int>(nullable: false),
                    Day = table.Column<string>(nullable: false),
                    MealOfDay = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserMeals", x => new { x.UserId, x.MealId, x.Day, x.MealOfDay });
                    table.ForeignKey(
                        name: "FK_UserMeals_Meals_MealId",
                        column: x => x.MealId,
                        principalTable: "Meals",
                        principalColumn: "MealId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserMeals_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserMeals_MealId",
                table: "UserMeals",
                column: "MealId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserMeals");
        }
    }
}
