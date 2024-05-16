using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace proyecto.Migrations
{
    /// <inheritdoc />
    public partial class cambiotipoacceso : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "horaFin",
                table: "Accesos");

            migrationBuilder.DropColumn(
                name: "horaInicio",
                table: "Accesos");

            migrationBuilder.AddColumn<float>(
                name: "tiempoConsulta",
                table: "Accesos",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "tiempoConsulta",
                table: "Accesos");

            migrationBuilder.AddColumn<TimeSpan>(
                name: "horaFin",
                table: "Accesos",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<TimeSpan>(
                name: "horaInicio",
                table: "Accesos",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));
        }
    }
}
