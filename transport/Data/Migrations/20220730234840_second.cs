using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace transport.Data.Migrations
{
    public partial class second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "desires",
                columns: table => new
                {
                    desireid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    desirename = table.Column<string>(type: "varchar(200)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_desires", x => x.desireid);
                });

            migrationBuilder.CreateTable(
                name: "teachers",
                columns: table => new
                {
                    teacherid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    teacherName = table.Column<string>(type: "varchar(250)", nullable: false),
                    city = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    birth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    last = table.Column<DateTime>(type: "datetime2", nullable: false),
                    hire = table.Column<DateTime>(type: "datetime2", nullable: false),
                    desireid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_teachers", x => x.teacherid);
                    table.ForeignKey(
                        name: "FK_teachers_desires_desireid",
                        column: x => x.desireid,
                        principalTable: "desires",
                        principalColumn: "desireid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_teachers_desireid",
                table: "teachers",
                column: "desireid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "teachers");

            migrationBuilder.DropTable(
                name: "desires");
        }
    }
}
