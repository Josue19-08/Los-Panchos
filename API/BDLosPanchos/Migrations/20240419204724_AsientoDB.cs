using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BDLosPanchos.Migrations
{
    /// <inheritdoc />
    public partial class AsientoDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "numAsiento",
                table: "Asiento",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "numAsiento",
                table: "Asiento");
        }
    }
}
