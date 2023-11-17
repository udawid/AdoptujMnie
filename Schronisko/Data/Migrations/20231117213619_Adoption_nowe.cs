using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Schronisko.Data.Migrations
{
    public partial class Adoption_nowe : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AdoptionForms",
                columns: table => new
                {
                    FormId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AnimalId = table.Column<int>(type: "int", nullable: false),
                    CurrentUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Answer1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Answer2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Answer3 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Answer4 = table.Column<bool>(type: "bit", nullable: false),
                    Answer5 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Answer6 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Answer7 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Answer8 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Answer9 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Answer10 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Answer11 = table.Column<bool>(type: "bit", nullable: false),
                    Answer12 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Answer13 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Answer14 = table.Column<bool>(type: "bit", nullable: false),
                    Answer15 = table.Column<bool>(type: "bit", nullable: false),
                    Answer16 = table.Column<bool>(type: "bit", nullable: false),
                    Answer17 = table.Column<bool>(type: "bit", nullable: false),
                    Answer18 = table.Column<bool>(type: "bit", nullable: false),
                    Answer19 = table.Column<bool>(type: "bit", nullable: false),
                    Answer20 = table.Column<bool>(type: "bit", nullable: false),
                    Answer21 = table.Column<bool>(type: "bit", nullable: false),
                    Answer22 = table.Column<bool>(type: "bit", nullable: false),
                    Answer23 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Answer24 = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdoptionForms", x => x.FormId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdoptionForms");
        }
    }
}
