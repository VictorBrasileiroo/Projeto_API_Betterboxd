using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Betterboxd.Infra.Migrations
{
    /// <inheritdoc />
    public partial class first_migration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Filmes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sinopse = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Diretor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Genero = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataLancamento = table.Column<DateOnly>(type: "date", nullable: false),
                    NotaMedia = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Filmes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AvaliacaoModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FilmeModelId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AvaliacaoModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AvaliacaoModel_Filmes_FilmeModelId",
                        column: x => x.FilmeModelId,
                        principalTable: "Filmes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AvaliacaoModel_FilmeModelId",
                table: "AvaliacaoModel",
                column: "FilmeModelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AvaliacaoModel");

            migrationBuilder.DropTable(
                name: "Filmes");
        }
    }
}
