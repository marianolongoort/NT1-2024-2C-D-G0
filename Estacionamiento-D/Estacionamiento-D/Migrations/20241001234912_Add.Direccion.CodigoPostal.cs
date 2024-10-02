using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Estacionamiento_D.Migrations
{
    /// <inheritdoc />
    public partial class AddDireccionCodigoPostal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CodigoPostal",
                table: "Direcciones",
                type: "nvarchar(max)",
                nullable: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CodigoPostal",
                table: "Direcciones");
        }
    }
}
