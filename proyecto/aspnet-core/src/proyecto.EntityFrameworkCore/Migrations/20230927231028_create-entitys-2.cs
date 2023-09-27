using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace proyecto.Migrations
{
    /// <inheritdoc />
    public partial class createentitys2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ListaNoticiaId",
                table: "Noticias",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Alertas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    descripcion = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alertas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ListaNoticias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombreLista = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListaNoticias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Notificaciones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    descripcion = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    link = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notificaciones", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ListaNoticiaItems",
                columns: table => new
                {
                    ListaNoticiaId = table.Column<int>(type: "int", nullable: false),
                    NoticiaId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListaNoticiaItems", x => new { x.ListaNoticiaId, x.NoticiaId });
                    table.ForeignKey(
                        name: "FK_ListaNoticiaItems_ListaNoticias_ListaNoticiaId",
                        column: x => x.ListaNoticiaId,
                        principalTable: "ListaNoticias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ListaNoticiaItems_Noticias_NoticiaId",
                        column: x => x.NoticiaId,
                        principalTable: "Noticias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Noticias_ListaNoticiaId",
                table: "Noticias",
                column: "ListaNoticiaId");

            migrationBuilder.CreateIndex(
                name: "IX_ListaNoticiaItems_NoticiaId",
                table: "ListaNoticiaItems",
                column: "NoticiaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Noticias_ListaNoticias_ListaNoticiaId",
                table: "Noticias",
                column: "ListaNoticiaId",
                principalTable: "ListaNoticias",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Noticias_ListaNoticias_ListaNoticiaId",
                table: "Noticias");

            migrationBuilder.DropTable(
                name: "Alertas");

            migrationBuilder.DropTable(
                name: "ListaNoticiaItems");

            migrationBuilder.DropTable(
                name: "Notificaciones");

            migrationBuilder.DropTable(
                name: "ListaNoticias");

            migrationBuilder.DropIndex(
                name: "IX_Noticias_ListaNoticiaId",
                table: "Noticias");

            migrationBuilder.DropColumn(
                name: "ListaNoticiaId",
                table: "Noticias");
        }
    }
}
