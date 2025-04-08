using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Betterboxd.Infra.Migrations
{
    /// <inheritdoc />
    public partial class new_entities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AvaliacaoModel_Filmes_FilmeModelId",
                table: "AvaliacaoModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AvaliacaoModel",
                table: "AvaliacaoModel");

            migrationBuilder.DropIndex(
                name: "IX_AvaliacaoModel_FilmeModelId",
                table: "AvaliacaoModel");

            migrationBuilder.DropColumn(
                name: "FilmeModelId",
                table: "AvaliacaoModel");

            migrationBuilder.RenameTable(
                name: "AvaliacaoModel",
                newName: "Avaliações");

            migrationBuilder.AddColumn<string>(
                name: "Comentario",
                table: "Avaliações",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateOnly>(
                name: "DataAvaliacao",
                table: "Avaliações",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<int>(
                name: "FilmeId",
                table: "Avaliações",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdFilme",
                table: "Avaliações",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdUser",
                table: "Avaliações",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "Nota",
                table: "Avaliações",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "Avaliações",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Avaliações",
                table: "Avaliações",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Usuários",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuários", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Avaliações_FilmeId",
                table: "Avaliações",
                column: "FilmeId");

            migrationBuilder.CreateIndex(
                name: "IX_Avaliações_UsuarioId",
                table: "Avaliações",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Avaliações_Filmes_FilmeId",
                table: "Avaliações",
                column: "FilmeId",
                principalTable: "Filmes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Avaliações_Usuários_UsuarioId",
                table: "Avaliações",
                column: "UsuarioId",
                principalTable: "Usuários",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Avaliações_Filmes_FilmeId",
                table: "Avaliações");

            migrationBuilder.DropForeignKey(
                name: "FK_Avaliações_Usuários_UsuarioId",
                table: "Avaliações");

            migrationBuilder.DropTable(
                name: "Usuários");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Avaliações",
                table: "Avaliações");

            migrationBuilder.DropIndex(
                name: "IX_Avaliações_FilmeId",
                table: "Avaliações");

            migrationBuilder.DropIndex(
                name: "IX_Avaliações_UsuarioId",
                table: "Avaliações");

            migrationBuilder.DropColumn(
                name: "Comentario",
                table: "Avaliações");

            migrationBuilder.DropColumn(
                name: "DataAvaliacao",
                table: "Avaliações");

            migrationBuilder.DropColumn(
                name: "FilmeId",
                table: "Avaliações");

            migrationBuilder.DropColumn(
                name: "IdFilme",
                table: "Avaliações");

            migrationBuilder.DropColumn(
                name: "IdUser",
                table: "Avaliações");

            migrationBuilder.DropColumn(
                name: "Nota",
                table: "Avaliações");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Avaliações");

            migrationBuilder.RenameTable(
                name: "Avaliações",
                newName: "AvaliacaoModel");

            migrationBuilder.AddColumn<int>(
                name: "FilmeModelId",
                table: "AvaliacaoModel",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_AvaliacaoModel",
                table: "AvaliacaoModel",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_AvaliacaoModel_FilmeModelId",
                table: "AvaliacaoModel",
                column: "FilmeModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_AvaliacaoModel_Filmes_FilmeModelId",
                table: "AvaliacaoModel",
                column: "FilmeModelId",
                principalTable: "Filmes",
                principalColumn: "Id");
        }
    }
}
