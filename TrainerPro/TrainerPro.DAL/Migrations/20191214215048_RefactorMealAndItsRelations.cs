using Microsoft.EntityFrameworkCore.Migrations;

namespace TrainerPro.DAL.Migrations
{
    public partial class RefactorMealAndItsRelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalMealKcal",
                table: "Meals");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "MealProducts");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "TotalMealKcal",
                table: "Meals",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "MealProducts",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
