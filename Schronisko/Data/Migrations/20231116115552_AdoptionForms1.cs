using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Schronisko.Data.Migrations
{
    public partial class AdoptionForms1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CheckboxOption");

            migrationBuilder.AddColumn<int>(
                name: "AnimalId",
                table: "AdoptionForms",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Answer1",
                table: "AdoptionForms",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AnimalId",
                table: "AdoptionForms");

            migrationBuilder.DropColumn(
                name: "Answer1",
                table: "AdoptionForms");

            migrationBuilder.CreateTable(
                name: "CheckboxOption",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdoptionFormFormId = table.Column<int>(type: "int", nullable: true),
                    OptionValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CheckboxOption", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CheckboxOption_AdoptionForms_AdoptionFormFormId",
                        column: x => x.AdoptionFormFormId,
                        principalTable: "AdoptionForms",
                        principalColumn: "FormId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CheckboxOption_AdoptionFormFormId",
                table: "CheckboxOption",
                column: "AdoptionFormFormId");
        }
    }
}
