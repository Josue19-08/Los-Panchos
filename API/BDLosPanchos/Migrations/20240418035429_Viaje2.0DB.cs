using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BDLosPanchos.Migrations
{
    /// <inheritdoc />
    public partial class Viaje20DB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Viaje_Ruta_rutaRamalID",
                table: "Viaje");

            migrationBuilder.AddForeignKey(
                name: "FK_Viaje_RutaRamal_rutaRamalID",
                table: "Viaje",
                column: "rutaRamalID",
                principalTable: "RutaRamal",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Viaje_RutaRamal_rutaRamalID",
                table: "Viaje");

            migrationBuilder.AddForeignKey(
                name: "FK_Viaje_Ruta_rutaRamalID",
                table: "Viaje",
                column: "rutaRamalID",
                principalTable: "Ruta",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
