using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TrainerPro.DAL.Migrations
{
    public partial class UserTrainingPlanMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Exercise",
                columns: table => new
                {
                    ExerciseId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exercise", x => x.ExerciseId);
                });

            migrationBuilder.CreateTable(
                name: "TrainingPlan",
                columns: table => new
                {
                    TrainingPlanId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: false),
                    UserId1 = table.Column<Guid>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingPlan", x => x.TrainingPlanId);
                    table.ForeignKey(
                        name: "FK_TrainingPlan_AspNetUsers_UserId1",
                        column: x => x.UserId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TrainingPlanExercise",
                columns: table => new
                {
                    TrainingPlanId = table.Column<int>(nullable: false),
                    ExerciseId = table.Column<int>(nullable: false),
                    TrainingPlanExerciseId = table.Column<int>(nullable: false),
                    RecommendedNumberOfSets = table.Column<int>(nullable: false),
                    RecommendedNumberOfReps = table.Column<int>(nullable: false),
                    RecommendedWeight = table.Column<int>(nullable: false),
                    RecommendedTime = table.Column<TimeSpan>(nullable: false),
                    NumberOfSets = table.Column<int>(nullable: false),
                    NumberOfReps = table.Column<int>(nullable: false),
                    Weight = table.Column<int>(nullable: false),
                    TimeSpent = table.Column<TimeSpan>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingPlanExercise", x => new { x.ExerciseId, x.TrainingPlanId });
                    table.ForeignKey(
                        name: "FK_TrainingPlanExercise_Exercise_ExerciseId",
                        column: x => x.ExerciseId,
                        principalTable: "Exercise",
                        principalColumn: "ExerciseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TrainingPlanExercise_TrainingPlan_TrainingPlanId",
                        column: x => x.TrainingPlanId,
                        principalTable: "TrainingPlan",
                        principalColumn: "TrainingPlanId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TrainingPlan_UserId1",
                table: "TrainingPlan",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingPlanExercise_TrainingPlanId",
                table: "TrainingPlanExercise",
                column: "TrainingPlanId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TrainingPlanExercise");

            migrationBuilder.DropTable(
                name: "Exercise");

            migrationBuilder.DropTable(
                name: "TrainingPlan");
        }
    }
}
