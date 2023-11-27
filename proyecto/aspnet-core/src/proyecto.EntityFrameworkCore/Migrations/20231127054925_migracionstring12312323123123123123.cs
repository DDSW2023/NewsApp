using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace proyecto.Migrations
{
    /// <inheritdoc />
    public partial class migracionstring12312323123123123123 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ListaNoticiaId",
                table: "ListaNoticias",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "ListaNoticias",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_ListaNoticias_ListaNoticiaId",
                table: "ListaNoticias",
                column: "ListaNoticiaId");

            migrationBuilder.CreateIndex(
                name: "IX_ListaNoticias_UserId",
                table: "ListaNoticias",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ListaNoticias_AbpUsers_UserId",
                table: "ListaNoticias",
                column: "UserId",
                principalTable: "AbpUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ListaNoticias_ListaNoticias_ListaNoticiaId",
                table: "ListaNoticias",
                column: "ListaNoticiaId",
                principalTable: "ListaNoticias",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ListaNoticias_AbpUsers_UserId",
                table: "ListaNoticias");

            migrationBuilder.DropForeignKey(
                name: "FK_ListaNoticias_ListaNoticias_ListaNoticiaId",
                table: "ListaNoticias");

            migrationBuilder.DropIndex(
                name: "IX_ListaNoticias_ListaNoticiaId",
                table: "ListaNoticias");

            migrationBuilder.DropIndex(
                name: "IX_ListaNoticias_UserId",
                table: "ListaNoticias");

            migrationBuilder.DropColumn(
                name: "ListaNoticiaId",
                table: "ListaNoticias");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "ListaNoticias");
        }
    }
}
