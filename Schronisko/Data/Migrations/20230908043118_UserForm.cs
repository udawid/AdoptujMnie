using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Schronisko.Data.Migrations
{
    public partial class UserForm : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserFormQuestionTypes",
                columns: table => new
                {
                    UserFormQuestionTypeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserFormQuestionTypes", x => x.UserFormQuestionTypeID);
                });

            migrationBuilder.CreateTable(
                name: "UserFormTypes",
                columns: table => new
                {
                    FormTypeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserFormTypes", x => x.FormTypeID);
                });

            migrationBuilder.CreateTable(
                name: "UserForms",
                columns: table => new
                {
                    UserFormID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Title = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(550)", maxLength: 550, nullable: false),
                    UserFormTypeID = table.Column<int>(type: "int", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    AddedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserForms", x => x.UserFormID);
                    table.ForeignKey(
                        name: "FK_UserForms_AspNetUsers_Id",
                        column: x => x.Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserForms_UserFormTypes_UserFormTypeID",
                        column: x => x.UserFormTypeID,
                        principalTable: "UserFormTypes",
                        principalColumn: "FormTypeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ResponseUserForms",
                columns: table => new
                {
                    ResponseUserFormID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserFormID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Title = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(550)", maxLength: 550, nullable: false),
                    UserFormTypeID = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    AddedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResponseUserForms", x => x.ResponseUserFormID);
                    table.ForeignKey(
                        name: "FK_ResponseUserForms_AspNetUsers_Id",
                        column: x => x.Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ResponseUserForms_UserForms_UserFormID",
                        column: x => x.UserFormID,
                        principalTable: "UserForms",
                        principalColumn: "UserFormID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserFormQuestions",
                columns: table => new
                {
                    UserFormQuestionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserFormID = table.Column<int>(type: "int", nullable: false),
                    QuestionOrder = table.Column<int>(type: "int", nullable: true),
                    QuestionText = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(550)", maxLength: 550, nullable: true),
                    UserFormQuestionTypeID = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    AddedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserFormQuestions", x => x.UserFormQuestionID);
                    table.ForeignKey(
                        name: "FK_UserFormQuestions_AspNetUsers_Id",
                        column: x => x.Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserFormQuestions_UserFormQuestionTypes_UserFormQuestionTypeID",
                        column: x => x.UserFormQuestionTypeID,
                        principalTable: "UserFormQuestionTypes",
                        principalColumn: "UserFormQuestionTypeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserFormQuestions_UserForms_UserFormID",
                        column: x => x.UserFormID,
                        principalTable: "UserForms",
                        principalColumn: "UserFormID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ResponseUserFormQuestions",
                columns: table => new
                {
                    ResponseUserFormQuestionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ResponseUserFormID = table.Column<int>(type: "int", nullable: false),
                    UserFormQuestionID = table.Column<int>(type: "int", nullable: false),
                    QuestionOrder = table.Column<int>(type: "int", nullable: true),
                    QuestionText = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(550)", maxLength: 550, nullable: true),
                    UserFormQuestionTypeID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResponseUserFormQuestions", x => x.ResponseUserFormQuestionID);
                    table.ForeignKey(
                        name: "FK_ResponseUserFormQuestions_ResponseUserForms_ResponseUserFormID",
                        column: x => x.ResponseUserFormID,
                        principalTable: "ResponseUserForms",
                        principalColumn: "ResponseUserFormID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserFormQuestionOptions",
                columns: table => new
                {
                    UserFormQuestionOptionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserFormQuestionID = table.Column<int>(type: "int", nullable: false),
                    OptionOrder = table.Column<int>(type: "int", nullable: true),
                    OptionText = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    AddedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserFormQuestionOptions", x => x.UserFormQuestionOptionID);
                    table.ForeignKey(
                        name: "FK_UserFormQuestionOptions_AspNetUsers_Id",
                        column: x => x.Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserFormQuestionOptions_UserFormQuestions_UserFormQuestionID",
                        column: x => x.UserFormQuestionID,
                        principalTable: "UserFormQuestions",
                        principalColumn: "UserFormQuestionID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ResponseUserFormQuestionOptions",
                columns: table => new
                {
                    ResponseUserFormQuestionOptionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ResponseUserFormQuestionID = table.Column<int>(type: "int", nullable: false),
                    UserFormQuestionOptionID = table.Column<int>(type: "int", nullable: false),
                    OptionOrder = table.Column<int>(type: "int", nullable: true),
                    OptionText = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Checked = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResponseUserFormQuestionOptions", x => x.ResponseUserFormQuestionOptionID);
                    table.ForeignKey(
                        name: "FK_ResponseUserFormQuestionOptions_ResponseUserFormQuestions_ResponseUserFormQuestionID",
                        column: x => x.ResponseUserFormQuestionID,
                        principalTable: "ResponseUserFormQuestions",
                        principalColumn: "ResponseUserFormQuestionID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ResponseUserFormQuestionOptions_ResponseUserFormQuestionID",
                table: "ResponseUserFormQuestionOptions",
                column: "ResponseUserFormQuestionID");

            migrationBuilder.CreateIndex(
                name: "IX_ResponseUserFormQuestions_ResponseUserFormID",
                table: "ResponseUserFormQuestions",
                column: "ResponseUserFormID");

            migrationBuilder.CreateIndex(
                name: "IX_ResponseUserForms_Id",
                table: "ResponseUserForms",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ResponseUserForms_UserFormID",
                table: "ResponseUserForms",
                column: "UserFormID");

            migrationBuilder.CreateIndex(
                name: "IX_UserFormQuestionOptions_Id",
                table: "UserFormQuestionOptions",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_UserFormQuestionOptions_UserFormQuestionID",
                table: "UserFormQuestionOptions",
                column: "UserFormQuestionID");

            migrationBuilder.CreateIndex(
                name: "IX_UserFormQuestions_Id",
                table: "UserFormQuestions",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_UserFormQuestions_UserFormID",
                table: "UserFormQuestions",
                column: "UserFormID");

            migrationBuilder.CreateIndex(
                name: "IX_UserFormQuestions_UserFormQuestionTypeID",
                table: "UserFormQuestions",
                column: "UserFormQuestionTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_UserForms_Id",
                table: "UserForms",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_UserForms_UserFormTypeID",
                table: "UserForms",
                column: "UserFormTypeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ResponseUserFormQuestionOptions");

            migrationBuilder.DropTable(
                name: "UserFormQuestionOptions");

            migrationBuilder.DropTable(
                name: "ResponseUserFormQuestions");

            migrationBuilder.DropTable(
                name: "UserFormQuestions");

            migrationBuilder.DropTable(
                name: "ResponseUserForms");

            migrationBuilder.DropTable(
                name: "UserFormQuestionTypes");

            migrationBuilder.DropTable(
                name: "UserForms");

            migrationBuilder.DropTable(
                name: "UserFormTypes");
        }
    }
}
