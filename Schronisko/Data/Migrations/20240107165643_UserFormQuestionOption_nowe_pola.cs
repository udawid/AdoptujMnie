using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Schronisko.Data.Migrations
{
    public partial class UserFormQuestionOption_nowe_pola : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Disqualifying",
                table: "UserFormQuestionOptions",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Points",
                table: "UserFormQuestionOptions",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Disqualifying",
                table: "UserFormQuestionOptions");

            migrationBuilder.DropColumn(
                name: "Points",
                table: "UserFormQuestionOptions");
        }
    }
}
