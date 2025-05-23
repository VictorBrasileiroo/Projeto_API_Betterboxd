﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Betterboxd.Infra.Migrations
{
    /// <inheritdoc />
    public partial class updaterelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Avaliações_Filmes_FilmeModelId",
                table: "Avaliações");

            migrationBuilder.DropForeignKey(
                name: "FK_Avaliações_Filmes_IdFilme",
                table: "Avaliações");

            migrationBuilder.DropForeignKey(
                name: "FK_Avaliações_Usuários_IdUser",
                table: "Avaliações");

            migrationBuilder.DropForeignKey(
                name: "FK_Avaliações_Usuários_UserModelId",
                table: "Avaliações");

            migrationBuilder.DropIndex(
                name: "IX_Avaliações_FilmeModelId",
                table: "Avaliações");

            migrationBuilder.DropIndex(
                name: "IX_Avaliações_UserModelId",
                table: "Avaliações");

            migrationBuilder.DropColumn(
                name: "FilmeModelId",
                table: "Avaliações");

            migrationBuilder.DropColumn(
                name: "UserModelId",
                table: "Avaliações");

            migrationBuilder.AddForeignKey(
                name: "FK_Avaliações_Filmes_IdFilme",
                table: "Avaliações",
                column: "IdFilme",
                principalTable: "Filmes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Avaliações_Usuários_IdUser",
                table: "Avaliações",
                column: "IdUser",
                principalTable: "Usuários",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Avaliações_Filmes_IdFilme",
                table: "Avaliações");

            migrationBuilder.DropForeignKey(
                name: "FK_Avaliações_Usuários_IdUser",
                table: "Avaliações");

            migrationBuilder.AddColumn<int>(
                name: "FilmeModelId",
                table: "Avaliações",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserModelId",
                table: "Avaliações",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Avaliações_FilmeModelId",
                table: "Avaliações",
                column: "FilmeModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Avaliações_UserModelId",
                table: "Avaliações",
                column: "UserModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Avaliações_Filmes_FilmeModelId",
                table: "Avaliações",
                column: "FilmeModelId",
                principalTable: "Filmes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Avaliações_Filmes_IdFilme",
                table: "Avaliações",
                column: "IdFilme",
                principalTable: "Filmes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Avaliações_Usuários_IdUser",
                table: "Avaliações",
                column: "IdUser",
                principalTable: "Usuários",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Avaliações_Usuários_UserModelId",
                table: "Avaliações",
                column: "UserModelId",
                principalTable: "Usuários",
                principalColumn: "Id");
        }
    }
}
