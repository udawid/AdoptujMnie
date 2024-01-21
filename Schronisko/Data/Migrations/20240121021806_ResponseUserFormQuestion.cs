using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Schronisko.Data.Migrations
{
    public partial class ResponseUserFormQuestion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "ResponseUserFormQuestions");

            migrationBuilder.DropColumn(
                name: "QuestionOrder",
                table: "ResponseUserFormQuestions");

            migrationBuilder.DropColumn(
                name: "QuestionText",
                table: "ResponseUserFormQuestions");

            migrationBuilder.DropColumn(
                name: "UserFormQuestionTypeID",
                table: "ResponseUserFormQuestions");

            migrationBuilder.DropColumn(
                name: "OptionOrder",
                table: "ResponseUserFormQuestionOptions");

            migrationBuilder.DropColumn(
                name: "OptionText",
                table: "ResponseUserFormQuestionOptions");

            migrationBuilder.AddColumn<int>(
                name: "Points",
                table: "ResponseUserForms",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TotalPoints",
                table: "ResponseUserForms",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Points",
                table: "ResponseUserForms");

            migrationBuilder.DropColumn(
                name: "TotalPoints",
                table: "ResponseUserForms");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "ResponseUserFormQuestions",
                type: "nvarchar(550)",
                maxLength: 550,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "QuestionOrder",
                table: "ResponseUserFormQuestions",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "QuestionText",
                table: "ResponseUserFormQuestions",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "UserFormQuestionTypeID",
                table: "ResponseUserFormQuestions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OptionOrder",
                table: "ResponseUserFormQuestionOptions",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OptionText",
                table: "ResponseUserFormQuestionOptions",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "");
        }
    }
}
