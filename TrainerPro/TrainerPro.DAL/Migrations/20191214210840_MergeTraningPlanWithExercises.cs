using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TrainerPro.DAL.Migrations
{
    public partial class MergeTraningPlanWithExercises : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TrainingPlanExercises");

            migrationBuilder.DropTable(
                name: "Exercises");

            migrationBuilder.DropTable(
                name: "TrainingPlans");

            migrationBuilder.CreateTable(
                name: "Trainings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Repeats = table.Column<int>(nullable: false),
                    Series = table.Column<int>(nullable: false),
                    Day = table.Column<string>(nullable: true),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trainings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Trainings_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Trainings_UserId",
                table: "Trainings",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Trainings");

            migrationBuilder.CreateTable(
                name: "Exercises",
                columns: table => new
                {
                    ExerciseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exercises", x => x.ExerciseId);
                });

            migrationBuilder.CreateTable(
                name: "TrainingPlans",
                columns: table => new
                {
                    TrainingPlanId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserIdId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingPlans", x => x.TrainingPlanId);
                    table.ForeignKey(
                        name: "FK_TrainingPlans_AspNetUsers_UserIdId",
                        column: x => x.UserIdId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TrainingPlanExercises",
                columns: table => new
                {
                    ExerciseId = table.Column<int>(type: "int", nullable: false),
                    TrainingPlanId = table.Column<int>(type: "int", nullable: false),
                    NumberOfReps = table.Column<int>(type: "int", nullable: false),
                    NumberOfSets = table.Column<int>(type: "int", nullable: false),
                    RecommendedNumberOfReps = table.Column<int>(type: "int", nullable: false),
                    RecommendedNumberOfSets = table.Column<int>(type: "int", nullable: false),
                    RecommendedTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    RecommendedWeight = table.Column<int>(type: "int", nullable: false),
                    TimeSpent = table.Column<TimeSpan>(type: "time", nullable: false),
                    TrainingPlanExerciseId = table.Column<int>(type: "int", nullable: false),
                    Weight = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingPlanExercises", x => new { x.ExerciseId, x.TrainingPlanId });
                    table.ForeignKey(
                        name: "FK_TrainingPlanExercises_Exercises_ExerciseId",
                        column: x => x.ExerciseId,
                        principalTable: "Exercises",
                        principalColumn: "ExerciseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TrainingPlanExercises_TrainingPlans_TrainingPlanId",
                        column: x => x.TrainingPlanId,
                        principalTable: "TrainingPlans",
                        principalColumn: "TrainingPlanId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TrainingPlanExercises_TrainingPlanId",
                table: "TrainingPlanExercises",
                column: "TrainingPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingPlans_UserIdId",
                table: "TrainingPlans",
                column: "UserIdId");
        }
    }
}
