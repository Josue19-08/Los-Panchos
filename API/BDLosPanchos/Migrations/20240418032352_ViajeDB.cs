using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BDLosPanchos.Migrations
{
    /// <inheritdoc />
    public partial class ViajeDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "costo",
                table: "Viaje");

            migrationBuilder.AddColumn<float>(
                name: "costo",
                table: "Tiquete",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "costo",
                table: "Tiquete");

            migrationBuilder.AddColumn<float>(
                name: "costo",
                table: "Viaje",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }
    }
}
