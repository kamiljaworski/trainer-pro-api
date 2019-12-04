using Microsoft.EntityFrameworkCore.Migrations;

namespace TrainerPro.DAL.Migrations
{
    public partial class ExerciseMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrainingPlan_AspNetUsers_UserId",
                table: "TrainingPlan");

            migrationBuilder.DropForeignKey(
                name: "FK_TrainingPlanExercise_Exercise_ExerciseId",
                table: "TrainingPlanExercise");

            migrationBuilder.DropForeignKey(
                name: "FK_TrainingPlanExercise_TrainingPlan_TrainingPlanId",
                table: "TrainingPlanExercise");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TrainingPlanExercise",
                table: "TrainingPlanExercise");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TrainingPlan",
                table: "TrainingPlan");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Exercise",
                table: "Exercise");

            migrationBuilder.RenameTable(
                name: "TrainingPlanExercise",
                newName: "TrainingPlanExercises");

            migrationBuilder.RenameTable(
                name: "TrainingPlan",
                newName: "TrainingPlans");

            migrationBuilder.RenameTable(
                name: "Exercise",
                newName: "Exercises");

            migrationBuilder.RenameIndex(
                name: "IX_TrainingPlanExercise_TrainingPlanId",
                table: "TrainingPlanExercises",
                newName: "IX_TrainingPlanExercises_TrainingPlanId");

            migrationBuilder.RenameIndex(
                name: "IX_TrainingPlan_UserId",
                table: "TrainingPlans",
                newName: "IX_TrainingPlans_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TrainingPlanExercises",
                table: "TrainingPlanExercises",
                columns: new[] { "ExerciseId", "TrainingPlanId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_TrainingPlans",
                table: "TrainingPlans",
                column: "TrainingPlanId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Exercises",
                table: "Exercises",
                column: "ExerciseId");

            migrationBuilder.AddForeignKey(
                name: "FK_TrainingPlanExercises_Exercises_ExerciseId",
                table: "TrainingPlanExercises",
                column: "ExerciseId",
                principalTable: "Exercises",
                principalColumn: "ExerciseId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TrainingPlanExercises_TrainingPlans_TrainingPlanId",
                table: "TrainingPlanExercises",
                column: "TrainingPlanId",
                principalTable: "TrainingPlans",
                principalColumn: "TrainingPlanId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TrainingPlans_AspNetUsers_UserId",
                table: "TrainingPlans",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrainingPlanExercises_Exercises_ExerciseId",
                table: "TrainingPlanExercises");

            migrationBuilder.DropForeignKey(
                name: "FK_TrainingPlanExercises_TrainingPlans_TrainingPlanId",
                table: "TrainingPlanExercises");

            migrationBuilder.DropForeignKey(
                name: "FK_TrainingPlans_AspNetUsers_UserId",
                table: "TrainingPlans");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TrainingPlans",
                table: "TrainingPlans");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TrainingPlanExercises",
                table: "TrainingPlanExercises");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Exercises",
                table: "Exercises");

            migrationBuilder.RenameTable(
                name: "TrainingPlans",
                newName: "TrainingPlan");

            migrationBuilder.RenameTable(
                name: "TrainingPlanExercises",
                newName: "TrainingPlanExercise");

            migrationBuilder.RenameTable(
                name: "Exercises",
                newName: "Exercise");

            migrationBuilder.RenameIndex(
                name: "IX_TrainingPlans_UserId",
                table: "TrainingPlan",
                newName: "IX_TrainingPlan_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_TrainingPlanExercises_TrainingPlanId",
                table: "TrainingPlanExercise",
                newName: "IX_TrainingPlanExercise_TrainingPlanId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TrainingPlan",
                table: "TrainingPlan",
                column: "TrainingPlanId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TrainingPlanExercise",
                table: "TrainingPlanExercise",
                columns: new[] { "ExerciseId", "TrainingPlanId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Exercise",
                table: "Exercise",
                column: "ExerciseId");

            migrationBuilder.AddForeignKey(
                name: "FK_TrainingPlan_AspNetUsers_UserId",
                table: "TrainingPlan",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TrainingPlanExercise_Exercise_ExerciseId",
                table: "TrainingPlanExercise",
                column: "ExerciseId",
                principalTable: "Exercise",
                principalColumn: "ExerciseId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TrainingPlanExercise_TrainingPlan_TrainingPlanId",
                table: "TrainingPlanExercise",
                column: "TrainingPlanId",
                principalTable: "TrainingPlan",
                principalColumn: "TrainingPlanId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
