using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BDLosPanchos.Migrations
{
    /// <inheritdoc />
    public partial class TiqueteBD : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "asiento",
                table: "Tiquete",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "asiento",
                table: "Tiquete");
        }
    }
}
