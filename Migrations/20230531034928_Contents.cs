using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MKBase.Migrations
{
    /// <inheritdoc />
    public partial class Contents : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SurveyId",
                table: "Question",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Answer",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Survey",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Intro = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Survey", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Survey_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Question_SurveyId",
                table: "Question",
                column: "SurveyId");

            migrationBuilder.CreateIndex(
                name: "IX_Survey_UserId",
                table: "Survey",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Question_Survey_SurveyId",
                table: "Question",
                column: "SurveyId",
                principalTable: "Survey",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Question_Survey_SurveyId",
                table: "Question");

            migrationBuilder.DropTable(
                name: "Survey");

            migrationBuilder.DropIndex(
                name: "IX_Question_SurveyId",
                table: "Question");

            migrationBuilder.DropColumn(
                name: "SurveyId",
                table: "Question");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Answer");
        }
    }
}
