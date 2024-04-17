using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BDLosPanchos.Migrations
{
    /// <inheritdoc />
    public partial class InitDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ramal",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    paradas = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ramal", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Ruta",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    origen = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    destino = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    km = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ruta", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Tiquete",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tiquete", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "RutaRamal",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    rutaID = table.Column<int>(type: "int", nullable: false),
                    ramalID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RutaRamal", x => x.id);
                    table.ForeignKey(
                        name: "FK_RutaRamal_Ramal_ramalID",
                        column: x => x.ramalID,
                        principalTable: "Ramal",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RutaRamal_Ruta_rutaID",
                        column: x => x.rutaID,
                        principalTable: "Ruta",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bus",
                columns: table => new
                {
                    placa = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    modelo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    rutaRamalID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bus", x => x.placa);
                    table.ForeignKey(
                        name: "FK_Bus_RutaRamal_rutaRamalID",
                        column: x => x.rutaRamalID,
                        principalTable: "RutaRamal",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Asiento",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    busID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Tiqueteid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Asiento", x => x.id);
                    table.ForeignKey(
                        name: "FK_Asiento_Bus_busID",
                        column: x => x.busID,
                        principalTable: "Bus",
                        principalColumn: "placa",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Asiento_Tiquete_Tiqueteid",
                        column: x => x.Tiqueteid,
                        principalTable: "Tiquete",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "TiqueteAsiento",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tiqueteID = table.Column<int>(type: "int", nullable: false),
                    asientoID = table.Column<int>(type: "int", nullable: false)
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
                name: "IX_Asiento_busID",
                table: "Asiento",
                column: "busID");

            migrationBuilder.CreateIndex(
                name: "IX_Asiento_Tiqueteid",
                table: "Asiento",
                column: "Tiqueteid");

            migrationBuilder.CreateIndex(
                name: "IX_Bus_rutaRamalID",
                table: "Bus",
                column: "rutaRamalID");

            migrationBuilder.CreateIndex(
                name: "IX_RutaRamal_ramalID",
                table: "RutaRamal",
                column: "ramalID");

            migrationBuilder.CreateIndex(
                name: "IX_RutaRamal_rutaID",
                table: "RutaRamal",
                column: "rutaID");

            migrationBuilder.CreateIndex(
                name: "IX_TiqueteAsiento_asientoID",
                table: "TiqueteAsiento",
                column: "asientoID");

            migrationBuilder.CreateIndex(
                name: "IX_TiqueteAsiento_tiqueteID",
                table: "TiqueteAsiento",
                column: "tiqueteID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TiqueteAsiento");

            migrationBuilder.DropTable(
                name: "Asiento");

            migrationBuilder.DropTable(
                name: "Bus");

            migrationBuilder.DropTable(
                name: "Tiquete");

            migrationBuilder.DropTable(
                name: "RutaRamal");

            migrationBuilder.DropTable(
                name: "Ramal");

            migrationBuilder.DropTable(
                name: "Ruta");
        }
    }
}
