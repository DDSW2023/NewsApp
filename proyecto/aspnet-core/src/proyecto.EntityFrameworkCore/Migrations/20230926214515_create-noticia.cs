using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace proyecto.Migrations
{
    /// <inheritdoc />
    public partial class createnoticia : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Noticias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    titulo = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    autor = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    encabezado = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    cuerpo = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Noticias", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Noticias");
        }
    }
}
