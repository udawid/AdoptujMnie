using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Schronisko.Data.Migrations
{
    public partial class ResponseUserForm : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "ResponseUserForms");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "ResponseUserForms");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "ResponseUserForms");

            migrationBuilder.DropColumn(
                name: "UserFormTypeID",
                table: "ResponseUserForms");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "ResponseUserForms",
                type: "nvarchar(550)",
                maxLength: 550,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "ResponseUserForms",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "ResponseUserForms",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "UserFormTypeID",
                table: "ResponseUserForms",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
