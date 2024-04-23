using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BDLosPanchos.Migrations
{
    /// <inheritdoc />
    public partial class NewEntityDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Asiento_Tiquete_Tiqueteid",
                table: "Asiento");

            migrationBuilder.DropForeignKey(
                name: "FK_Bus_RutaRamal_rutaRamalID",
                table: "Bus");

            migrationBuilder.DropTable(
                name: "TiqueteAsiento");

            migrationBuilder.DropIndex(
                name: "IX_Bus_rutaRamalID",
                table: "Bus");

            migrationBuilder.DropColumn(
                name: "fechaViaje",
                table: "Ruta");

            migrationBuilder.DropColumn(
                name: "horaSalida",
                table: "Ruta");

            migrationBuilder.DropColumn(
                name: "rutaRamalID",
                table: "Bus");

            migrationBuilder.RenameColumn(
                name: "Tiqueteid",
                table: "Asiento",
                newName: "tiqueteID");

            migrationBuilder.RenameIndex(
                name: "IX_Asiento_Tiqueteid",
                table: "Asiento",
                newName: "IX_Asiento_tiqueteID");

            migrationBuilder.AddColumn<int>(
                name: "viajeID",
                table: "Tiquete",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Viaje",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fechaViaje = table.Column<DateOnly>(type: "date", nullable: false),
                    horaViaje = table.Column<DateTime>(type: "datetime2", nullable: false),
                    costo = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    duracionMinutos = table.Column<int>(type: "int", nullable: false),
                    rutaRamalID = table.Column<int>(type: "int", nullable: false),
                    busID = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Viaje", x => x.id);
                    table.ForeignKey(
                        name: "FK_Viaje_Bus_busID",
                        column: x => x.busID,
                        principalTable: "Bus",
                        principalColumn: "placa",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Viaje_Ruta_rutaRamalID",
                        column: x => x.rutaRamalID,
                        principalTable: "Ruta",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tiquete_viajeID",
                table: "Tiquete",
                column: "viajeID");

            migrationBuilder.CreateIndex(
                name: "IX_Viaje_busID",
                table: "Viaje",
                column: "busID");

            migrationBuilder.CreateIndex(
                name: "IX_Viaje_rutaRamalID",
                table: "Viaje",
                column: "rutaRamalID");

            migrationBuilder.AddForeignKey(
                name: "FK_Asiento_Tiquete_tiqueteID",
                table: "Asiento",
                column: "tiqueteID",
                principalTable: "Tiquete",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tiquete_Viaje_viajeID",
                table: "Tiquete",
                column: "viajeID",
                principalTable: "Viaje",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Asiento_Tiquete_tiqueteID",
                table: "Asiento");

            migrationBuilder.DropForeignKey(
                name: "FK_Tiquete_Viaje_viajeID",
                table: "Tiquete");

            migrationBuilder.DropTable(
                name: "Viaje");

            migrationBuilder.DropIndex(
                name: "IX_Tiquete_viajeID",
                table: "Tiquete");

            migrationBuilder.DropColumn(
                name: "viajeID",
                table: "Tiquete");

            migrationBuilder.RenameColumn(
                name: "tiqueteID",
                table: "Asiento",
                newName: "Tiqueteid");

            migrationBuilder.RenameIndex(
                name: "IX_Asiento_tiqueteID",
                table: "Asiento",
                newName: "IX_Asiento_Tiqueteid");

            migrationBuilder.AddColumn<DateOnly>(
                name: "fechaViaje",
                table: "Ruta",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<DateTime>(
                name: "horaSalida",
                table: "Ruta",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "rutaRamalID",
                table: "Bus",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "TiqueteAsiento",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    asientoID = table.Column<int>(type: "int", nullable: false),
                    tiqueteID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiqueteAsiento", x => x.id);
                    table.ForeignKey(
                        name: "FK_TiqueteAsiento_Asiento_asientoID",
                        column: x => x.asientoID,
                        principalTable: "Asiento",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TiqueteAsiento_Tiquete_tiqueteID",
                        column: x => x.tiqueteID,
                        principalTable: "Tiquete",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bus_rutaRamalID",
                table: "Bus",
                column: "rutaRamalID");

            migrationBuilder.CreateIndex(
                name: "IX_TiqueteAsiento_asientoID",
                table: "TiqueteAsiento",
                column: "asientoID");

            migrationBuilder.CreateIndex(
                name: "IX_TiqueteAsiento_tiqueteID",
                table: "TiqueteAsiento",
                column: "tiqueteID");

            migrationBuilder.AddForeignKey(
                name: "FK_Asiento_Tiquete_Tiqueteid",
                table: "Asiento",
                column: "Tiqueteid",
                principalTable: "Tiquete",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Bus_RutaRamal_rutaRamalID",
                table: "Bus",
                column: "rutaRamalID",
                principalTable: "RutaRamal",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
