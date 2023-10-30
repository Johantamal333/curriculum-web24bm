using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Curriculum.Migrations
{
    /// <inheritdoc />
    public partial class AgregarImagenPerfil : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "ImagenPerfil",
                table: "Usuario",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagenPerfil",
                table: "Usuario");
        }
    }
}
