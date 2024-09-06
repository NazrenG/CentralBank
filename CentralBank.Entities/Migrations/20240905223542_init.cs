using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CentralBank.Entities.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ValCurs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ValCurs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roots",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ValCursId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roots", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Roots_ValCurs_ValCursId",
                        column: x => x.ValCursId,
                        principalTable: "ValCurs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ValTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ValCursId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ValTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ValTypes_ValCurs_ValCursId",
                        column: x => x.ValCursId,
                        principalTable: "ValCurs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Valutes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nominal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ValTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Valutes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Valutes_ValTypes_ValTypeId",
                        column: x => x.ValTypeId,
                        principalTable: "ValTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Roots_ValCursId",
                table: "Roots",
                column: "ValCursId");

            migrationBuilder.CreateIndex(
                name: "IX_ValTypes_ValCursId",
                table: "ValTypes",
                column: "ValCursId");

            migrationBuilder.CreateIndex(
                name: "IX_Valutes_ValTypeId",
                table: "Valutes",
                column: "ValTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Roots");

            migrationBuilder.DropTable(
                name: "Valutes");

            migrationBuilder.DropTable(
                name: "ValTypes");

            migrationBuilder.DropTable(
                name: "ValCurs");
        }
    }
}
