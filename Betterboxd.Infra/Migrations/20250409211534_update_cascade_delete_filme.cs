using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Betterboxd.Infra.Migrations
{
    /// <inheritdoc />
    public partial class update_cascade_delete_filme : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Avaliações_Filmes_IdFilme",
                table: "Avaliações");

            migrationBuilder.AddForeignKey(
                name: "FK_Avaliações_Filmes_IdFilme",
                table: "Avaliações",
                column: "IdFilme",
                principalTable: "Filmes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Avaliações_Filmes_IdFilme",
                table: "Avaliações");

            migrationBuilder.AddForeignKey(
                name: "FK_Avaliações_Filmes_IdFilme",
                table: "Avaliações",
                column: "IdFilme",
                principalTable: "Filmes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
