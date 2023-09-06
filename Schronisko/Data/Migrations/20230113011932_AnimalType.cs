using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Schronisko.Data.Migrations
{
    public partial class AnimalType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "Animals");

            migrationBuilder.AddColumn<int>(
                name: "AnimalTypeID",
                table: "Animals",
                type: "int",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.CreateTable(
                name: "AnimalTypes",
                columns: table => new
                {
                    AnimalTypeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnimalTypes", x => x.AnimalTypeID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Animals_AnimalTypeID",
                table: "Animals",
                column: "AnimalTypeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Animals_AnimalTypes_AnimalTypeID",
                table: "Animals",
                column: "AnimalTypeID",
                principalTable: "AnimalTypes",
                principalColumn: "AnimalTypeID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Animals_AnimalTypes_AnimalTypeID",
                table: "Animals");

            migrationBuilder.DropTable(
                name: "AnimalTypes");

            migrationBuilder.DropIndex(
                name: "IX_Animals_AnimalTypeID",
                table: "Animals");

            migrationBuilder.DropColumn(
                name: "AnimalTypeID",
                table: "Animals");

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Animals",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
