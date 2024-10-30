using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JosueValencia_EXAMPRIMERO.Migrations
{
    /// <inheritdoc />
    public partial class migracion1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Celulares",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Modelo = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Anio = table.Column<int>(type: "int", nullable: false),
                    Precio = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Celulares", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JValencia",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sueldo = table.Column<float>(type: "real", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Correo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClienteAntiguo = table.Column<bool>(type: "bit", nullable: false),
                    Pedido = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdCelular = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JValencia", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JValencia_Celulares_IdCelular",
                        column: x => x.IdCelular,
                        principalTable: "Celulares",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_JValencia_IdCelular",
                table: "JValencia",
                column: "IdCelular");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JValencia");

            migrationBuilder.DropTable(
                name: "Celulares");
        }
    }
}
